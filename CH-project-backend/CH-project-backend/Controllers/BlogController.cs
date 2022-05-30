using CH_project_backend.Services.BolgServices;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CH_project_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAllCors")]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService services;

        public BlogController(IBlogService _services)
        {
            services = _services;
        }
    }
}
