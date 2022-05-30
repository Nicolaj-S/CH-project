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
    }
}
