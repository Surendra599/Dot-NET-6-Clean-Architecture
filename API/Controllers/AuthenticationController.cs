using Application.Services.Authentication;
using Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        //https://localhost:7129/api/Authentication/Register
        [HttpPost]
        [Route("Register")]
        public IActionResult Register(RegisterRequest request)
        {
            var result = _authenticationService.Register(request.FirstName, request.LastName, request.Email, request.Password);

            var response = new AuthenticationResponse
            (
                result.User.Id,
                result.User.Email,
                result.User.FirstName,
                result.User.LastName,
                result.Token
            );

            return Ok(response);
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginRequest request)
        {
            var result = _authenticationService.Login(request.Email, request.Password);

            var response = new AuthenticationResponse
            (
                result.User.Id,
                result.User.Email,
                result.User.FirstName,
                result.User.LastName,
                result.Token
            );

            return Ok(response);
        }
    }
}