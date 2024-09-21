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
            List<Department> departmentList = 
                context.Department.Include(d=>d.Emps)
                .ToList();
            return View("Index",departmentList);//Model List<department>
        }
    }
}
