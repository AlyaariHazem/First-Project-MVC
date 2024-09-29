using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;

namespace FirstProjectWithMVC.ViewModels
{
    public class AddDivisionViewModel
    {
        public int DivisionID { get; set; }
        public string DivisionName { get; set; } = string.Empty;
        public bool Active { get; set; }=true;
        public int ClassID { get; set; }=1;
    }
}