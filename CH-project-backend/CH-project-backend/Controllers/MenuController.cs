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
    }
}
