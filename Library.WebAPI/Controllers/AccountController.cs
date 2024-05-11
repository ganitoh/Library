using Library.Application.CQRS.Users.Queries.GetUserByLogin;
using Library.Application.Common.Services.Application.Abstraction;
using Library.Application.CQRS.Users.Commands.CreateUser;
using Library.WebAPI.Contracts.Request;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Library.WebAPI.Contracts.Response;

namespace Library.WebAPI.Controllers
{
    [Route("account")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("registration")]
        public async Task<IActionResult> RegistrationAccount(
            [FromBody] RegistrationUserRequest request)
        {
            var command = new CreateUserCommand(request.Login, 2);
            await _accountService.RegistrationAccount(command, request.password);
            return Ok();
        }

        [HttpGet("login")]
        public async Task<IActionResult> Login([FromQuery] LoginUserRequest request)
        {
            var user = await _accountService.Login(
                new GetUserByLoginRequest(request.Login), request.password);

            Claim[] claims =[
                new Claim("login", user.Login),
                new Claim("id", user.Id.ToString())];

            var claimsIdentity = new ClaimsIdentity(claims);
            var claimPrincipal = new ClaimsPrincipal(claimsIdentity);
            await HttpContext.SignInAsync(
                scheme: CookieAuthenticationDefaults.AuthenticationScheme,
                principal: claimPrincipal);

            var userResponse = new UserDataResponse(user.Login);
            return Ok(userResponse);
        }

    }
}
