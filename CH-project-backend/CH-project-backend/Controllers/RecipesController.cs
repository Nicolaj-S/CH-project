using Microsoft.AspNetCore.Mvc;

namespace CH_project_backend.Controllers
{
    public class RecipesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
