using System;
using System.Collections.Generic;
using System.Linq;
using Backend.Models;
using FirstProjectWithMVC.Models;
using FirstProjectWithMVC.ViewModels;

namespace FirstProjectWithMVC.Repository.School
{
    public class ClassesRepository : IClassesRepository
    {
        private readonly DataContext context;

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
                StageID = obj.StageID
            };

            try
            {
                context.Classes.Add(newClass);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                // Log the exception (you can use any logging library here)
                Console.WriteLine($"Error adding class: {ex.Message}");
                throw; // Re-throw or handle as needed
            }
        }

        public void Delete(int id)
        {
            var existingClass = GetById(id);
            if (existingClass != null)
            {
                context.Classes.Remove(existingClass);
                context.SaveChanges();
            }
        }

        public List<Class> GetAll()
        {
            return context.Classes.ToList(); // Implemented to fetch all classes
        }

        public Class GetById(int id)
        {
            return context.Classes.FirstOrDefault(c => c.ClassID == id);
        }

        public void Update(Class entity)
        {
            var existingClass = GetById(entity.ClassID);
            if (existingClass != null)
            {
                existingClass.ClassName = entity.ClassName;
                existingClass.ClassYear = entity.ClassYear;
                existingClass.StageID = entity.StageID;
                // Update other properties as needed
                context.SaveChanges();
            }
        }

        public List<AddClassViewModel> DisplayClasses()
        {
            var classes = context.Classes
                .Select(c => new AddClassViewModel
                {
                    ClassID = c.ClassID,
                    ClassName = c.ClassName,
                    ClassYear = c.ClassYear,
                    StageID = c.StageID, // Include StageID for the view
                    Stage = c.Stage,  // Fetch the single Stage object
                    Divisions = c.Divisions.ToList(),
                    StudentCount = c.StudentClass != null ? c.StudentClass.Count() : 0 // Manual null check
                }).ToList();

            return classes;
        }



    }
}
