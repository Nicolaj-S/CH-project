using Microsoft.AspNetCore.Mvc;

namespace CH_project_backend.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
