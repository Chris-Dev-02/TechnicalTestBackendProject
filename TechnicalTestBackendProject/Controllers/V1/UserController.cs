using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnicalTestBackendProject.DTOs;
using TechnicalTestBackendProject.Services.Interfaces;

namespace TechnicalTestBackendProject.Controllers.V1
{
    [Route("api/v1/[controller]")]
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

        [AllowAnonymous]
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

        [AllowAnonymous]
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
                var LoginResponse = await _authenticationService.Login(LoginData);
                return Ok(LoginResponse);
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
        public async Task<IActionResult> Logout()
        {
            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            var result = await _authenticationService.Logout(token);
            if (result)
            {
                return Ok("Token invalidated successfully");
            }
            else
            {
                return BadRequest("Invalid token.");
            }
        }

        [Authorize]
        [HttpGet("protected-resource")]
        public IActionResult GetProtectedResource()
        {
            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized("Token not provided.");
            }

            // Puedes procesar el token aquí.
            return Ok("Allowed access.");
        }
    }
}
