using FirstProjectWithMVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace FirstProjectWithMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        public IActionResult AddRole()
        {
            var model = new RoleViewModel
            {
                Roles = roleManager.Roles.Select(r => r.Name).ToList()
            };
            return View("Create", model);
        }

        [HttpPost]
        public async Task<IActionResult> SaveRole(RoleViewModel roleViewModel)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole { Name = roleViewModel.RoleName };
                IdentityResult result = await roleManager.CreateAsync(role);
                
                if (result.Succeeded)
                {
                    roleViewModel.Roles = roleManager.Roles.Select(r => r.Name).ToList(); // Refresh roles list
                    ViewBag.Message = "Role created successfully!";
                    return View("Create", roleViewModel);
                }
                
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            roleViewModel.Roles = roleManager.Roles.Select(r => r.Name).ToList();
            return View("Create", roleViewModel);
        }
    }
}
