using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using FirstProjectWithMVC.ViewModels;

namespace FirstProjectWithMVC.Repository.School
{
    public interface IDivisionRepository : IgenericRepository<Division>
    {
       public List<DivisionViewModel> DisplayDivisiones();
       public void ChangeState(int id, bool state);
       public void Add(DivisionViewModel model);
       public void Update(DivisionViewModel model);
    }
}