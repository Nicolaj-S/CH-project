using CH_project_backend.Domain;
using CH_project_backend.Model.Users;
using CH_project_backend.Services.UserServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CH_project_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAllCors")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService _UserService)
        {
            userService = _UserService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetallUsers()
        {
            var users = await userService.GetAllUsers();
            if (!ModelState.IsValid)
            {
                return NotFound(ModelState);
            }
            return Ok(users);
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = userService.Authenticate(model, ipAddress());
            setTokenCookie(response.RefreshToken);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("refresh-token")]
        public IActionResult RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            var response = userService.RefreshToken(refreshToken, ipAddress());
            setTokenCookie(response.RefreshToken);
            return Ok(response);
        }


        [HttpPost("revoke-token")]
        public IActionResult RevokeToken(RevokeTokenRequest model)
        {
            // accept refresh token in request body or cookie
            var token = model.Token ?? Request.Cookies["refreshToken"];

            if (string.IsNullOrEmpty(token))
                return BadRequest(new { message = "Token is required" });

            userService.RevokeToken(token, ipAddress());
            return Ok(new { message = "Token revoked" });
        }

        [HttpGet("{id}/refresh-tokens")]
        public IActionResult GetRefreshTokens(int id)
        {
            var user = userService.GetUserById(id);
            return Ok(user);
        }

        private void setTokenCookie(string token)
        {
            // append cookie with refresh token to the http response
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(7)
            };
            Response.Cookies.Append("refreshToken", token, cookieOptions);
        }

        private string ipAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            else
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }

        [AllowAnonymous]
        [HttpGet("Id/{Id}")]
        public async Task<IActionResult> GetUserById(int Id)
        {
            var User = await userService.GetUserById(Id);
            if (!ModelState.IsValid)
            {
                return NotFound(ModelState);
            }
            return Ok(User);
        }

        [HttpGet("Username/{Username}")]
        public async Task<IActionResult> GetUserByUsername(string Username)
        {
            var user = await userService.GetUserByUsername(Username);
            if (!ModelState.IsValid)
            {
                return NotFound(ModelState);
            }
            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost()]
        public async Task<IActionResult> CreateUser(User createUser)
        {
            var result = await userService.CreateUser(createUser);
            return result ? Ok(createUser) : BadRequest();
        }

        [HttpPut("Update/{Id}")]
        public async Task<IActionResult> UpdateUser(int Id, [FromBody] User updateUser)
        {
            if (updateUser == null)
            {
                return NotFound(ModelState);
            }
            if (Id != updateUser.Id)
            {
                return NotFound(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return NotFound(ModelState);
            }

            var User = updateUser;
            if (!await userService.UpdateUser(User))
            {
                ModelState.AddModelError("", "something went wrong updating user");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> DeleteUser(int Id)
        {

            var UserToDelete = await userService.GetUserById(Id);
            if (!ModelState.IsValid)
            {
                return NotFound(ModelState);
            }
            if (!await userService.DeleteUser(UserToDelete))
            {
                ModelState.AddModelError("", "something went wrong deleting user");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}
