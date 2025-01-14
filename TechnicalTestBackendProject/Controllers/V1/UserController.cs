using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TechnicalTestBackendProject.DTOs;
using TechnicalTestBackendProject.Services.Interfaces;
using TechnicalTestBackendProject.Validators;

namespace TechnicalTestBackendProject.Controllers.V1
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IValidator<UserCreateDTO> _createUserValidator;
        private readonly IValidator<LoginDTO> _loginValidator;
        private readonly IAuthenticationService _authenticationService;
        public UserController(IValidator<UserCreateDTO> createUserValidator, 
            IValidator<LoginDTO> loginValidator,
            IAuthenticationService authenticationService) 
        {
            _createUserValidator = createUserValidator;
            _loginValidator = loginValidator;
            _authenticationService = authenticationService;
        }

        [HttpPost]
        [Route("signup")]
        public async Task<IActionResult> SignUp([FromBody] UserCreateDTO SignupData)
        {
            var validationResult = _createUserValidator.Validate(SignupData);

            if(!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            try
            {
                await _authenticationService.Signup(SignupData);
                return Ok("User registered successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO LoginData)
        {
            var validationResult = _loginValidator.Validate(LoginData);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            try
            {
                var token = await _authenticationService.Login(LoginData);
                return Ok(new { Token = token });
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized("Invalid credentials.");
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("assign-role")]
        public async Task<IActionResult> AssignRole([FromBody] AssignRoleDTO assignRoleDTO)
        {
            try
            {
                await _authenticationService.AssignRole(assignRoleDTO);
                return Ok($"Role: '{assignRoleDTO.UserRole}' asigned to user with ID: {assignRoleDTO.UserId}.");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Authorize]
        [Route("logout")]
        public IActionResult Logout()
        {
            return Ok();
        }
    }
}
