using Microsoft.AspNetCore.Mvc;


namespace FirstProjectWithMVC.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View("Dashboard");
        }
        public IActionResult dashboard()
        {
            return View("Dashboard");
        }
    }
}
