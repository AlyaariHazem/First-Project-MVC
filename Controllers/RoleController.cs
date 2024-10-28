using FirstProjectWithMVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FirstProjectWithMVC.Controllers;
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
        return View("Create");
    }

    [HttpPost]
    public async Task<IActionResult> SaveRole(RoleViewModel roleViewModel)
    {
        if (ModelState.IsValid)
        {
            IdentityRole role = new IdentityRole();
            role.Name = roleViewModel.RoleName;

            IdentityResult result = await roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                ViewBag.Message = true;
                return View("Create");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }
        return View("Create", roleViewModel);
    }

}
