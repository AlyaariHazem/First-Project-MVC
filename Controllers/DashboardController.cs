using Microsoft.AspNetCore.Mvc;

namespace FirstProjectWithMVC.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View("Dashboard");
        }
    }
}
