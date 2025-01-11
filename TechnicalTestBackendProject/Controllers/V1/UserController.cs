using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TechnicalTestBackendProject.Controllers.V1
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserController() { }

        [HttpPost]
        [Route("signup")]
        public IActionResult SignUp()
        {
            return Ok();
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login()
        {
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
