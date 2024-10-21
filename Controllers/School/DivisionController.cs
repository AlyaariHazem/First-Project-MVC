using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FirstProjectWithMVC.Repository.School;
using FirstProjectWithMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FirstProjectWithMVC.Controllers.School
{
    public class DivisionController : Controller
    {

        IDivisionRepository divisionRepo;

        public DivisionController(IDivisionRepository _divisionRepo)
        {
            divisionRepo = _divisionRepo;
        }


        [Route("Division/DisplayDivisioinInfo")]
        public IActionResult DisplayDivisioinInfo()

        {
            List<DivisionViewModel> divisions = divisionRepo.DisplayDivisiones();
            ViewBag.DivisionInfo = divisions;

            return PartialView("~/Views/Stages/_DivisionPartial.cshtml");
        }


    }
}