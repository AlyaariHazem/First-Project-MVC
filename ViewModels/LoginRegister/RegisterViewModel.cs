using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FirstProjectWithMVC.ViewModels.Register
{
    public class RegisterViewModel
    {
        
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
         [Display(Name = "Role")]
    public string Role { get; set; }
    
    public List<SelectListItem> Roles { get; set; } = new List<SelectListItem>();
    }
}