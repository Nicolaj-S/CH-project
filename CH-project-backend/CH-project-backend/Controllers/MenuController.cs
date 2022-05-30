using CH_project_backend.Domain;
using CH_project_backend.Services.MenuServices;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CH_project_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAllCors")]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService services;

        public MenuController(IMenuService _services)
        {
            services = _services;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMenus()
        {
            var menus = await services.GetAllMenus();
            if (!ModelState.IsValid)
            {
                return NotFound(ModelState);
            }
            return Ok(menus);
        }

        [HttpGet("Id/{Id}")]
        public async Task<IActionResult> GetMenuById(int Id)
        {
            var menu = await services.GetMenuById(Id);
            if (!ModelState.IsValid)
            {
                return NotFound(ModelState);
            }
            return Ok(menu);
        }

        [HttpPost()]
        public async Task<IActionResult> CreateMenu(Menu createMenu)
        {
            var result = await services.CreateMenu(createMenu);
            return result ? Ok(createMenu) : BadRequest();
        }

        [HttpPut("Update/{Id}")]
        public async Task<IActionResult> UpdateMenu(int Id, [FromBody] Menu updateMenu)
        {
            if (updateMenu == null)
            {
                return NotFound(ModelState);
            }
            if (Id != updateMenu.Id)
            {
                return NotFound(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return NotFound(ModelState);
            }

            var Menu = updateMenu;
            if (!await services.UpdateMenu(Menu))
            {
                ModelState.AddModelError("", "something went wrong updating menu");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> DeleteMenu(int Id)
        {

            var MenuToDelete = await services.GetMenuById(Id);
            if (!ModelState.IsValid)
            {
                return NotFound(ModelState);
            }
            if (!await services.DeleteMenu(MenuToDelete))
            {
                ModelState.AddModelError("", "something went wrong deleting menu");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}
