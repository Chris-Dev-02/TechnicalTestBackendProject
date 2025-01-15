using AutoMapper;
using MediatR;
using StackExchange.Redis;
using System.Data;
using TechnicalTestBackendProject.CQRS.Commands;
using TechnicalTestBackendProject.CQRS.Queries;
using TechnicalTestBackendProject.DTOs;
using TechnicalTestBackendProject.Models;
using TechnicalTestBackendProject.Repository;
using TechnicalTestBackendProject.Services.Interfaces;

namespace TechnicalTestBackendProject.Services.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenService _jwtTokenService;
        private readonly IPasswordHasherService _passwordHasherService;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public AuthenticationService(
            IJwtTokenService jwtTokenService, 
            IPasswordHasherService passwordHasherService, 
            IMediator mediator,
            IMapper mapper
            )
        {
            _jwtTokenService = jwtTokenService;
            _passwordHasherService = passwordHasherService;
            _mediator = mediator;
            _mapper = mapper;
        }
        public async Task AssignRole(AssignRoleDTO assignRoleDTO)
        {
            var user = await _mediator.Send(new GetUserByIdQuery(assignRoleDTO.UserId));
            if (user == null)
            {
                throw new KeyNotFoundException("Usur not found.");
            }

            if (!Enum.IsDefined(typeof(RoleEnum), assignRoleDTO.UserRole))
            {
                throw new ArgumentException("Role not valid.");
            }

            user.UserRole = assignRoleDTO.UserRole;

            var userUpdated = _mapper.Map<UserUpdateDTO>(user);

            await _mediator.Send(new UpdateUserCommand(userUpdated));
        }

        public async Task<string[]> GetAllRoles()
        {
            return Enum.GetNames(typeof(RoleEnum));
        }

        public async Task<bool> IsValidToken(string token)
        {
            return await _mediator.Send(new IsValidTokenQuery(token));
        }

        public async Task<LoginResponseDTO> Login(LoginDTO userLoginDTO)
        {
            //userLoginDTO.Password = _passwordHasherService.HashPassword(userLoginDTO.Password);
            userLoginDTO.Password = userLoginDTO.Password.Trim();
            var user = await _mediator.Send(new GetUserByEmailQuery((userLoginDTO.Email)));

            if (user == null || !_passwordHasherService.VerifyPassword(userLoginDTO.Password, user.Password))
            {
                throw new UnauthorizedAccessException("Invalid credentials.");
            }

            var userRead = await _mediator.Send(new GetUserByIdQuery(user.Id));
            string token = _jwtTokenService.GenerateJwtToken(user);

            return new LoginResponseDTO {
                User = userRead,
                Token = token
            };
        }

        public async Task<bool> Logout(string token)
        {
            return await _mediator.Send(new InvalidateTokenCommand(token));
        }

        public async Task<UserReadDTO> Signup(UserCreateDTO userCreateDTO)
        {
            userCreateDTO.Password = userCreateDTO.Password.Trim();
            userCreateDTO.Password = _passwordHasherService.HashPassword(userCreateDTO.Password);

            return await _mediator.Send(new CreateUserCommand(userCreateDTO));
        }
    }
}
