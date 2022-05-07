using Microsoft.AspNetCore.Mvc;

namespace CH_project_backend.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
