using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstProjectWithMVC.ViewModels;

public class RoleViewModel
{
    [Display(Name="Role Name")]
    public string RoleName { get; set; }
}
