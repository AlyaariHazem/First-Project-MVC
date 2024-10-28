using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SchoolManagementSystem.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Common properties for all users
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        // Additional properties depending on the user's role
        public string? Role { get; set; } // Can be "Student", "Teacher", "Manager", or "Guardian"

        // Example of specific properties for each role
        // For students
        public string? StudentID { get; set; }
        public string? Grade { get; set; }

        // For teachers
        public string? TeacherID { get; set; }
        public string? Subject { get; set; }

        // For managers
        public string? ManagerID { get; set; }
        public string? Department { get; set; }

        // For guardians
        public string? GuardianID { get; set; }
        public string? RelationToStudent { get; set; }
    }
}
