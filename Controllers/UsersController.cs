using JwtToken.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JwtToken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet("Public")]
        public IActionResult Public()
        {
            return Ok("Users API");
        }

        [HttpGet("/admin")]
        [Authorize(Roles = "Administrator")]
        public IActionResult Admin()
        {
            var currentUser = GetLoggedInUser();

            return Ok($"Hi {currentUser.Username}, you are logged in as an {currentUser.Role}");
        }

        private User GetLoggedInUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var userClaims = identity.Claims;
                return new User
                {
                    Username = userClaims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier)?.Value,
                    EmailAddress = userClaims.FirstOrDefault(u => u.Type == ClaimTypes.Email)?.Value,
                    GivenName = userClaims.FirstOrDefault(u => u.Type == ClaimTypes.GivenName)?.Value,
                    Role = userClaims.FirstOrDefault(u => u.Type == ClaimTypes.Role)?.Value,
                };
            }

            return null;
        }
    }
}
