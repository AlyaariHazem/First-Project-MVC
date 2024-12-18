﻿using System.Data;
using Backend.Models;
using FirstProjectWithMVC.Models;
using FirstProjectWithMVC.Repository;
using FirstProjectWithMVC.Repository.School;
using FirstProjectWithMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FirstProjectWithMVC.Controllers.School
{
    public class StagesController : Controller
    {
        IStagesRepository stageRepo;
        IClassesRepository classRepo;
        IDivisionRepository divisionRepo;
        
        public StagesController(IStagesRepository _stageRepo, IClassesRepository _classRepo,IDivisionRepository _divisionRepo)
        {
            stageRepo = _stageRepo;
            classRepo = _classRepo;
            divisionRepo = _divisionRepo;
        }
        public IActionResult DisplayDivisioinInfo()

        {
            List<DivisionViewModel> divisions = divisionRepo.DisplayDivisiones();
            ViewBag.DivisionInfo = divisions;

            return PartialView("~/Views/Stages/_DivisionPartial.cshtml");
        }
        public IActionResult index()
        {
            DisplayStagesInfo();
            DisplayDivisioinInfo();
            return View("ManageStages");
        }
        public IActionResult DisplayStagesInfo()
        {
            List<StagesViewModel> stages = stageRepo.DisplayStages();
            ViewBag.StagesInfo = stages;

            List<AddClassViewModel> viewModels = classRepo.DisplayClasses();
            ViewBag.Classes = viewModels;

            return PartialView("~/Views/Stages/_StagePartial.cshtml");
        }


        [HttpPost]
        public IActionResult AddStage(AddStageViewModel model)
        {

            if (ModelState.IsValid)
            {
                stageRepo.Add(model); // Add the new stage

                return RedirectToAction("Index"); // Redirect to show the updated list
            }

            List<StagesViewModel> stages = stageRepo.DisplayStages();
            ViewBag.StagesInfo = stages;

            return View("ManageStages"); // Return the form with the current stages if invalid
        }

        [HttpPost]
        public IActionResult UpdateStage(AddStageViewModel model)
        {
            if (ModelState.IsValid)
            {
                stageRepo.Update(model); // Ensure that the repo's Update method is called
                return RedirectToAction("Index"); // Redirect after a successful update
            }

            List<StagesViewModel> stages = stageRepo.DisplayStages();
            ViewBag.StagesInfo = stages;

            return View("ManageStages"); // Return the form with the current stages if invalid
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

            return Json(new { success = true, message = "" });
        }
    }
}
