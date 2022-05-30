using CH_project_backend.Domain;
using CH_project_backend.Services.RecipesServices;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CH_project_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAllCors")]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipesService services;

        public RecipesController(IRecipesService _services)
        {
            services = _services;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRecipes()
        {
            var recipes = await services.GetAllRecipes();
            if (!ModelState.IsValid)
            {
                return NotFound(ModelState);
            }
            return Ok(recipes);
        }

        [HttpGet("Id/{Id}")]
        public async Task<IActionResult> GetRecipesById(int Id)
        {
            var recipe = await services.GetRecipesById(Id);
            if (!ModelState.IsValid)
            {
                return NotFound(ModelState);
            }
            return Ok(recipe);
        }

        [HttpPost()]
        public async Task<IActionResult> CreateRecipes(Recipes createRecipes)
        {
            var result = await services.CreateRecipes(createRecipes);
            return result ? Ok(createRecipes) : BadRequest();
        }

        [HttpPut("Update/{Id}")]
        public async Task<IActionResult> UpdateRecipes(int Id, [FromBody] Recipes updateRecipes)
        {
            if (updateRecipes == null)
            {
                return NotFound(ModelState);
            }
            if (Id != updateRecipes.Id)
            {
                return NotFound(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return NotFound(ModelState);
            }

            var Recipes = updateRecipes;
            if (!await services.UpdateRecipes(Recipes))
            {
                ModelState.AddModelError("", "something went wrong updating recipe");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> DeleteRecipes(int Id)
        {

            var RecipesToDelete = await services.GetRecipesById(Id);
            if (!ModelState.IsValid)
            {
                return NotFound(ModelState);
            }
            if (!await services.DeleteRecipes(RecipesToDelete))
            {
                ModelState.AddModelError("", "something went wrong deleting recipe");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}
