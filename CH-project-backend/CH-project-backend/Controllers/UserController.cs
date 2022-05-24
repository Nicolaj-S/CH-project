using AutoMapper;
using CH_project_backend.Domain;
using CH_project_backend.Model.Users;
using CH_project_backend.Services.UserServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CH_project_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public UserController(IUserService _UserService, IMapper _mapper)
        {
            userService = _UserService;
            mapper = _mapper;
        }

        [Authorize]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
        public async Task<IActionResult> GetallUsers()
        {
            var users = mapper.Map<List<User>>(await userService.GetAllUsers());
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
            // get source ip address for the current request
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            else
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }

        [HttpGet("Id/{Id}")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetUserById(int Id)
        {
            //if(!await userService.UserExistsByID(Id))
            //{
            //    return NoContent();
            //}

            var User = mapper.Map<User>(await userService.GetUserById(Id));
            if (!ModelState.IsValid)
            {
                return NotFound(ModelState);
            }
            return Ok(User);
        }

        [HttpGet("Username/{Username}")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetUserByUsername(string Username)
        {
            //if(!await userService.UserExistsByUsername(Username))
            //{
            //    return NoContent();
            //}

            var user = mapper.Map<User>(await userService.GetUserByUsername(Username));
            if (!ModelState.IsValid)
            {
                return NotFound(ModelState);
            }
            return Ok(user);
        }

        [HttpPost()]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateUser([FromBody] User createUser)
        {

            if (createUser == null)
            {
                ModelState.AddModelError("", "Plase insert data to create a user");
                return StatusCode(409, ModelState);
            }
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Invaild create tpye plase try again");
                return StatusCode(409, ModelState);
            }

            var User = mapper.Map<User>(createUser);
            //if (await userService.UserExistsByUsername(User.Username))
            //{
            //    return Conflict("Username is already in use");
            //}
            //if (await userService.UserExistsByEmail(User.Email))
            //{
            //    return Conflict("Mail is already in use");
            //}
            if (!await userService.CreateUser(User))
            {
                ModelState.AddModelError("", "Something went wrong while Saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully Created");
        }

        [HttpPut("Update/{Id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateUser(int Id, [FromBody] User updateUser)
        {
            if(updateUser == null)
            {
                return NotFound(ModelState);
            }
            if(Id != updateUser.Id)
            {
                return NotFound(ModelState);
            }

            //if(!await userService.UserExistsByID(Id))
            //{
            //    return NotFound();
            //}
            if (!ModelState.IsValid)
            {
                return NotFound(ModelState);
            }

            var User = mapper.Map<User>(updateUser);
            if (!await userService.UpdateUser(User))
            {
                ModelState.AddModelError("", "something went wrong updating user");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        [HttpDelete("Delete/{Id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteUser(int Id)
        {
            //if(!await userService.UserExistsByID(Id))
            //{
            //    return NotFound();
            //}
            var UserToDelete = await userService.GetUserById(Id);
            if (!ModelState.IsValid)
            {
                return NotFound(ModelState);
            }
            if(!await userService.DeleteUser(UserToDelete))
            {
                ModelState.AddModelError("", "something went wrong deleting user");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}
