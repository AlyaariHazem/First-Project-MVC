using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FirstProjectWithMVC.Models;

namespace FirstProjectWithMVC.Controllers
{
    public class EmployeeController : Controller
    {
        DataContext context = new DataContext();
        public EmployeeController()
        {

        }
        public IActionResult Details(int id)
        {
            string msg = "Hello From Action";
            int temp = 50;
            List<string> bracnches = new List<string>();

            bracnches.Add("Assiut");
            bracnches.Add("Alex");
            bracnches.Add("Cario");
            //Aditional info send to View from Action
            ViewData["Msg"] = msg;
            ViewData["Temp"] = temp;
            ViewData["brch"] = bracnches;


            ViewData["Color"] = "Blue";
            ViewBag.Color = "REd";
            //ViewData.Model=empMo
            Employee EmpMOdel = context.Employee.FirstOrDefault(e => e.Id == id);
            return View("Details", EmpMOdel);
        }


    }
}
