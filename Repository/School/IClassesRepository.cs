using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using FirstProjectWithMVC.ViewModels;

namespace FirstProjectWithMVC.Repository.School
{
    public interface IClassesRepository:IgenericRepository<Class>
    {
        public void Add(AddClassViewModel obj);
        public List<AddClassViewModel> DisplayClasses();
    }
}