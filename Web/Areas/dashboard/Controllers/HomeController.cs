using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.dashboard.Controllers
{
    [Area("dashboard")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
