using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstProjectWithMVC.ViewModels.LoginRegister
{
    public class LoginViewModel
{
    [Required(ErrorMessage ="*")]
    public string UserName { get; set; }=string.Empty;

    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Display(Name ="Remember Me")]
    public bool RememberMe { get; set; }
}

}


