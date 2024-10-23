using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FirstProjectWithMVC.Repository;
using FirstProjectWithMVC.Repository.School;
using FirstProjectWithMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FirstProjectWithMVC.Controllers.School
{
    public class DivisionController : Controller
    {

        IDivisionRepository divisionRepo;
        IClassesRepository classRepo;

        public DivisionController(IDivisionRepository _divisionRepo, IClassesRepository _classRepo)
        {
            divisionRepo = _divisionRepo;
            classRepo = _classRepo;
        }

        [HttpPost]
        public IActionResult AddDivision(DivisionViewModel model)
        {

            divisionRepo.Add(model); // Add the new Class

            List<DivisionViewModel> divisions = divisionRepo.DisplayDivisiones();
            List<AddClassViewModel> classes = classRepo.DisplayClasses(); // Fetch stages

            ViewBag.ClassesInfo = classes;
            ViewBag.DivisionInfo = divisions;

            return RedirectToAction("index", "Stages"); // Redirect to the stages index to see the updated list

        }

        [HttpPost]
        public IActionResult UpdateDivision(DivisionViewModel model)
        {

            divisionRepo.Update(model);


            List<AddClassViewModel> Classes = classRepo.DisplayClasses();
            ViewBag.ClassInfo = Classes;

            return RedirectToAction("index", "Stages"); // Redirect to the stages index to see the updated list
        }

        [Route("Division/DisplayDivisioinInfo")]
        public IActionResult DisplayDivisioinInfo()

        {
            List<DivisionViewModel> divisions = divisionRepo.DisplayDivisiones();
            List<AddClassViewModel> classes = classRepo.DisplayClasses(); // Fetch stages

            ViewBag.ClassesInfo = classes;
            ViewBag.DivisionInfo = divisions;

            return PartialView("~/Views/Stages/_DivisionPartial.cshtml");
        }
        [HttpPost]
        public IActionResult DeleteDivisionByID(int id)
        {
            var Class = divisionRepo.GetById(id);

            if (Class == null)
            {
                return Json(new { success = false, message = "الصـف غير موجود" }); // Return JSON if not found
            }

            divisionRepo.Delete(id);

            // Reload classes and stages after deletion
            List<DivisionViewModel> viewModels = divisionRepo.DisplayDivisiones();
            List<AddClassViewModel> Classes = classRepo.DisplayClasses(); // Fetch stages

            ViewBag.Classes = viewModels;
            ViewBag.ClassesInfo = Classes; // Pass stages to the view

            return PartialView("~/Views/Stages/_ClassPartial.cshtml"); // Return updated partial view
        }


        [HttpPost]
        public IActionResult ChangeState(int id, bool state)
        {

            divisionRepo.ChangeState(id, state);
            return PartialView("~/Views/Stages/_DivisionPartial.cshtml");
        }

    }
}