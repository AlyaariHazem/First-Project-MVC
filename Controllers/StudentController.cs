using Microsoft.AspNetCore.Mvc;
using FirstProjectWithMVC.Models;

namespace FirstProjectWithMVC.Controllers
{
    public class StudentController : Controller
    {
        //Student/ShowAll
        public IActionResult ShowAll()
        {
            return Content("Content");
        }
    }
}
