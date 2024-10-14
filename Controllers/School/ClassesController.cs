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
        IStagesRepository stageRepo;
        public ClassesController(IClassesRepository _classRepo,IStagesRepository _stageRepo)
        {
            classRepo = _classRepo;
            stageRepo = _stageRepo;
        }

        [HttpPost]
        public IActionResult AddClass(AddClassViewModel model)
        {
            
                classRepo.Add(model); // Add the new Class
            

            // If the model state is invalid, load classes and stages again
            List<AddClassViewModel> viewModels = classRepo.DisplayClasses();
            List<StagesViewModel> stages = stageRepo.DisplayStages(); // Fetch stages

            ViewBag.Classes = viewModels;
            ViewBag.StagesInfo = stages; // Pass stages to the view
                return RedirectToAction("index", "Stages"); // Redirect to the stages index to see the updated list

        }



        public IActionResult DisplayClassesInfo()
        {
            List<AddClassViewModel> viewModels = classRepo.DisplayClasses();
            List<StagesViewModel> stages = stageRepo.DisplayStages(); // Fetch stages

            ViewBag.Classes = viewModels;
            ViewBag.StagesInfo = stages; // Pass stages to the view

            return PartialView("~/Views/Stages/_ClassPartial.cshtml");
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

            // Reload classes and stages after deletion
            List<AddClassViewModel> viewModels = classRepo.DisplayClasses();
            List<StagesViewModel> stages = stageRepo.DisplayStages(); // Fetch stages

            ViewBag.Classes = viewModels;
            ViewBag.StagesInfo = stages; // Pass stages to the view

            return PartialView("~/Views/Stages/_ClassPartial.cshtml"); // Return updated partial view
        }

    }
}
