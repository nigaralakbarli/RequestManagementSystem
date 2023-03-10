using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RequestManagementSystem.Data.DataContext;
using RequestManagementSystem.Data.Models;
using RequestManagementSystem.DataAccess.Interfaces;
using RequestManagementSystem.DataAccess.Models;
using RequestManagementSystem.Dtos.Response;

namespace RequestManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly IAuthService _authService;
        private readonly AppDbContext _dbContext;

        public LoginController(IAuthService authService, AppDbContext dbContext)
        {
            _authService = authService;
            _dbContext = dbContext;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromQuery] UserLogin userLogin)
        {
            var user = _authService.Authenticate(userLogin);

            if (user != null)
            {
                var token = _authService.Generate(user);
                var refreshToken = _authService.GenerateRefreshToken(user);
                SetRefreshToken(refreshToken, user);
                return Ok(token);

            }

            return NotFound("User not found");
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<string>> RefreshToken()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = _authService.GetCurrentUser();
                var refreshToken = Request.Cookies["refreshToken"];

                if (user.RefreshToken.Token != refreshToken)
                {
                    return Unauthorized("Invalid Refresh Token.");
                }
                else if (user.RefreshToken.Expires < DateTime.Now)
                {
                    return Unauthorized("Token expired.");
                }

                string token = _authService.Generate(user);
                var newRefreshToken = _authService.GenerateRefreshToken(user);
                SetRefreshToken(newRefreshToken, user);
                return Ok(token);
            }
            return Unauthorized();
        }


        private void SetRefreshToken(RefreshToken newRefreshToken, User user)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = newRefreshToken.Expires
            };
            Response.Cookies.Append("refreshToken", newRefreshToken.Token, cookieOptions);

            user.RefreshToken.Token = newRefreshToken.Token;
            user.RefreshToken.Created = newRefreshToken.Created;
            user.RefreshToken.Expires = newRefreshToken.Expires;
        }
    }
}

