using System.Data;
using Backend.Models;
using FirstProjectWithMVC.Models;
using FirstProjectWithMVC.Repository;
using FirstProjectWithMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FirstProjectWithMVC.Controllers.School
{
    public class StagesController : Controller
    {
        IStagesRepository stageRepo;
        public StagesController(IStagesRepository _stageRepo)
        {
            stageRepo = _stageRepo;
            
        }
       public IActionResult index(){
        DisplayStagesInfo();
           return View("ManageStages");
       }
        public IActionResult DisplayStagesInfo()
        {
            List<StagesViewModel> stagesInfo = stageRepo.DisplayStages();
             return PartialView("~/Views/Stages/_StagePartial.cshtml", stagesInfo);
        }

       
        [HttpPost]
        public IActionResult AddStage(AddStageViewModel model)
        {
            if (ModelState.IsValid)
            {
                stageRepo.Add(model); // Add the new stage
                return RedirectToAction("DisplayStagesInfo"); // Redirect to show the updated list
            }

            return PartialView("~/Views/Stages/_StagePartial.cshtml", stageRepo.DisplayStages()); // Return the form with the current stages if invalid
        }

        [HttpPost]
        public IActionResult DeleteStage(int id)
        {
            var stage = stageRepo.GetById(id);
            if (stage == null)
            {
                return Json(new { success = false, message = "المرحلة غير موجودة" }); // Return JSON if not found
            }

            stageRepo.Delete(id);

            return Json(new { success = true, message = "تم الحذف بنجاح" });
        }
    }
}
