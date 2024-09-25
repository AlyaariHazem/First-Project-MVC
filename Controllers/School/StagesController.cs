using Microsoft.AspNetCore.Mvc;

namespace FirstProjectWithMVC.Controllers.School
{
    public class StagesController : Controller
    {
        public IActionResult Index()
        {
            return View("ManageStages");
        }

        public IActionResult Stages()
        {
            // Logic to get stages data and pass to the view
            return PartialView("StagesTable");
        }

        public IActionResult Classes()
        {
            // Logic to get classes data and pass to the view
            return PartialView("ClassesTable");
        }

    }
}
