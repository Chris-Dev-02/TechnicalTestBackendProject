using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TechnicalTestBackendProject.DTOs;
using TechnicalTestBackendProject.Validators;

namespace TechnicalTestBackendProject.Controllers.V1
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IValidator<UserCreateDTO> _createUserValidator;
        private readonly IValidator<LoginDTO> _loginValidator;
        public UserController(IValidator<UserCreateDTO> createUserValidator, IValidator<LoginDTO> loginValidator) 
        {
            _createUserValidator = createUserValidator;
            _loginValidator = loginValidator;
        }

        [HttpPost]
        [Route("signup")]
        public IActionResult SignUp([FromBody] UserCreateDTO SignupData)
        {
            var validationResult = _createUserValidator.Validate(SignupData);

            if(!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            return Ok();
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] LoginDTO LoginData)
        {
            var validationResult = _loginValidator.Validate(LoginData);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            return Ok();
        }

        [HttpPost]
        [Route("logout")]
        public IActionResult Logout()
        {
            return Ok();
        }
    }
}
