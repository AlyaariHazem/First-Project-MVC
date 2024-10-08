using System.Data;
using Backend.Models;
using FirstProjectWithMVC.Models;
using FirstProjectWithMVC.Repository;
using FirstProjectWithMVC.Repository.School;
using FirstProjectWithMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FirstProjectWithMVC.Controllers.School
{
    public class ClassesController : Controller
    {
        IClassesRepository classRepo;
        public ClassesController(IClassesRepository _classRepo)
        {
            classRepo = _classRepo;
        }

        [HttpPost]
        public IActionResult AddClass(AddClassViewModel model)
        {
            if (ModelState.IsValid)
            {
                classRepo.Add(model); // Add the new Class
                return RedirectToAction("DisplayClassesInfo"); // Redirect to show the updated list
            }
            List<AddClassViewModel> viewModels = classRepo.DisplayClasses();
            ViewBag.Classes = viewModels;
            
            return View("~/Views/Stages/ManageStages.cshtml");
        }
        public IActionResult DisplayClassesInfo()
        {
            List<AddClassViewModel> viewModels = classRepo.DisplayClasses();
            ViewBag.Classes = viewModels;

            return View("~/Views/Stages/ManageStages.cshtml");
        }


        [HttpPost]
        public IActionResult DeleteClassByID(int id)
        {
            var Class = classRepo.GetById(id);
            if (Class == null)
            {
                return Json(new { success = false, message = "الصـف غير موجود" }); // Return JSON if not found
            }

            classRepo.Delete(id);

            return Json(new { success = true, message = "تم الحذف بنجاح" });
        }
    }
}
