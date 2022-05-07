using Microsoft.AspNetCore.Mvc;

namespace CH_project_backend.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
