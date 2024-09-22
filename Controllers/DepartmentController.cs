using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FirstProjectWithMVC.Models;

namespace FirstProjectWithMVC.Controllers
{
    public class DepartmentController : Controller
    {
        DataContext context = new DataContext();
        public IActionResult Index()
        {
            bool sidebarState = true; // Set based on your logic
            return View(new { Sidebar = sidebarState });
        }
        public IActionResult add()
        {
            return View("Add");
        }
    }
}
