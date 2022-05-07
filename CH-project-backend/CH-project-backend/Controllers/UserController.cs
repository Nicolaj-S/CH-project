using AutoMapper;
using CH_project_backend.Domain;
using CH_project_backend.DTO.User_DTOModel;
using CH_project_backend.Services.UserServices;
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
        
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
        public async Task<IActionResult> GetallUsers()
        {
            var users = mapper.Map<List<UserModel>>(await userService.GetAllUsers());
            if (!ModelState.IsValid)
            {
                return NotFound(ModelState);
            }
            return Ok(users);
        }

        [HttpGet("Id/{Id}")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetUserById(int Id)
        {
            if(!await userService.UserExistsByID(Id))
            {
                return NoContent();
            }

            var User = mapper.Map<UserModel>(await userService.GetUserById(Id));
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
            if(!await userService.UserExistsByUsername(Username))
            {
                return NoContent();
            }

            var user = mapper.Map<UserModel>(await userService.GetUserByUsername(Username));
            if (!ModelState.IsValid)
            {
                return NotFound(ModelState);
            }
            return Ok(user);
        }

        [HttpPost()]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserModel createUser)
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
            if (await userService.UserExistsByUsername(User.Username))
            {
                return Conflict("Username is already in use");
            }
            if (await userService.UserExistsByEmail(User.Email))
            {
                return Conflict("Mail is already in use");
            }
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
        public async Task<IActionResult> UpdateUser(int Id, [FromBody] UpdateUserModel updateUser)
        {
            if(updateUser == null)
            {
                return NotFound(ModelState);
            }
            if(Id != updateUser.Id)
            {
                return NotFound(ModelState);
            }

            if(!await userService.UserExistsByID(Id))
            {
                return NotFound();
            }
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
            if(!await userService.UserExistsByID(Id))
            {
                return NotFound();
            }
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
