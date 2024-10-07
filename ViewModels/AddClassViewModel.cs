using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;

namespace FirstProjectWithMVC.ViewModels
{
    public class AddClassViewModel
    {
        public int ClassID { get; set; }
        public string ClassName { get; set;}=string.Empty;
        public string ClassYear { get; set; }=Convert.ToString(DateTime.Now);
        public int StageID { get; set; }
        public int StudentCount { get; set; }
        public virtual ICollection<Division> Divisions { get; set; } = new List<Division>();
        public virtual ICollection<Student> Students { get; set; } = new List<Student>();
    }
}