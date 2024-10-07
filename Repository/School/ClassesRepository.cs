using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using FirstProjectWithMVC.Models;
using FirstProjectWithMVC.ViewModels;

namespace FirstProjectWithMVC.Repository.School;

public class ClassesRepository : IClassesRepository
{
    DataContext context;
    public ClassesRepository(DataContext _context)
    {
        context = _context;
    }

    public void Add(AddClassViewModel obj)
    {
        Class newClass = new Class
        {
            ClassName = obj.ClassName,
            ClassYear = obj.ClassYear,
            StageID = obj.StageID,
            Divisions = obj.Divisions // Add if necessary
        };

        context.Add(newClass);
        context.SaveChanges();
    }


    public void Delete(int id)
    {
        var Class = GetById(id);
        if (Class != null)
        {
            context.Classes.Remove(Class);
            context.SaveChanges();
        }
    }

    public List<Class> GetAll()
    {
        throw new NotImplementedException();
    }

    public Class GetById(int id)
    {
        return context.Classes.FirstOrDefault(c => c.ClassID == id);
    }

    public void Update(Class entity)
    {
        throw new NotImplementedException();
    }

    public List<AddClassViewModel> DisplayClasses()
    {
        var classes = context.Classes
            .Select(Class => new AddClassViewModel
            {
                ClassID = Class.ClassID,
                ClassName = Class.ClassName,
                ClassYear = Class.ClassYear,
                Divisions = Class.Divisions != null ? Class.Divisions.ToList() : new List<Division>(), // Manual null check
                StudentCount = Class.StudentClass != null ? Class.StudentClass.Count() : 0 // Manual null check
            }).ToList();

        return classes;
    }



}
