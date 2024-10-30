using System.Security.Claims;
using FirstProjectWithMVC.ViewModels.LoginRegister;
using FirstProjectWithMVC.ViewModels.Register;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolManagementSystem.Models;

namespace FirstProjectWithMVC.Controllers.Account
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManagare;
        private readonly RoleManager<IdentityRole> roleManager; // Add this line

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManagare,
            RoleManager<IdentityRole> roleManager) // Add roleManager here
        {
            this.userManager = userManager;
            this.signInManagare = signInManagare;
            this.roleManager = roleManager; // Assign it here
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View("Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveRegister(RegisterViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                var appUser = new ApplicationUser { UserName = userViewModel.UserName };

                IdentityResult result = await userManager.CreateAsync(appUser, userViewModel.Password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(appUser, userViewModel.Role); // Use selected role
                    await signInManagare.SignInAsync(appUser, false);

                    return RedirectToAction("Index", "Account");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            // Reload roles if model state is invalid
            var roles = await roleManager.Roles.ToListAsync();
            userViewModel.Roles = roles.Select(r => new SelectListItem
            {
                Value = r.Name,
                Text = r.Name
            }).ToList();

            return View("Register", userViewModel);
        }


        [HttpGet]
        public async Task<IActionResult> Register()
        {
            var model = new RegisterViewModel();
            var roles = await roleManager.Roles.ToListAsync(); // Ensure roleManager is injected

            model.Roles = roles.Select(r => new SelectListItem
            {
                Value = r.Name,
                Text = r.Name
            }).ToList();

            return View("Register", model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveLogin(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser appUser = await userManager.FindByNameAsync(loginViewModel.UserName);
                if (appUser != null)
                {
                    bool found = await userManager.CheckPasswordAsync(appUser, loginViewModel.Password);
                    if (found)
                    {
                        // Create claims to display the user name
                        var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, appUser.UserName)
                };
                        var authProperties = new AuthenticationProperties
                        {
                            IsPersistent = loginViewModel.RememberMe
                        };

                        await signInManagare.SignInWithClaimsAsync(appUser, authProperties, claims);
                        return RedirectToAction("Index", "Admin");
                    }
                }

                ModelState.AddModelError("", "UserName or Password is wrong");
            }
            return View("Login", loginViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManagare.SignOutAsync();
            return RedirectToAction("Index", "Account");
        }

    }
}
