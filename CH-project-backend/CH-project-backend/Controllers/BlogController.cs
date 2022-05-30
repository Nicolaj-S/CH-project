using CH_project_backend.Domain;
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

        [HttpGet]
        public async Task<IActionResult> GetAllBlogs()
        {
            var blogs = await services.GetAllBlogs();
            if (!ModelState.IsValid)
            {
                return NotFound(ModelState);
            }
            return Ok(blogs);
        }

        [HttpGet("Id/{Id}")]
        public async Task<IActionResult> GetBlogById(int Id)
        {
            var blog = await services.GetBlogById(Id);
            if (!ModelState.IsValid)
            {
                return NotFound(ModelState);
            }
            return Ok(blog);
        }

        [HttpPost()]
        public async Task<IActionResult> CreateBlog(Blog createBlog)
        {
            var result = await services.CreateBlog(createBlog);
            return result ? Ok(createBlog) : BadRequest();
        }

        [HttpPut("Update/{Id}")]
        public async Task<IActionResult> UpdateBlog(int Id, [FromBody] Blog updateBlog)
        {
            if (updateBlog == null)
            {
                return NotFound(ModelState);
            }
            if (Id != updateBlog.Id)
            {
                return NotFound(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return NotFound(ModelState);
            }

            var Blog = updateBlog;
            if (!await services.UpdateBlog(Blog))
            {
                ModelState.AddModelError("", "something went wrong updating blog");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> DeleteBlog(int Id)
        {

            var BlogToDelete = await services.GetBlogById(Id);
            if (!ModelState.IsValid)
            {
                return NotFound(ModelState);
            }
            if (!await services.DeleteBlog(BlogToDelete))
            {
                ModelState.AddModelError("", "something went wrong deleting blog");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}
