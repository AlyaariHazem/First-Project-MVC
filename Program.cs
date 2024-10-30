using FirstProjectWithMVC.Models;
using FirstProjectWithMVC.Repository;
using FirstProjectWithMVC.Repository.School;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Models;

namespace FirstProjectWithMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Connection with Database
            builder.Services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
            );

            // Register custom repositories
            builder.Services.AddScoped<IStagesRepository, StagesRepository>();
            builder.Services.AddScoped<IClassesRepository, ClassesRepository>();
            builder.Services.AddScoped<IDivisionRepository, DivisionRepository>();

            // Configure Identity services
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 4;
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<DataContext>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseDeveloperExceptionPage();


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Account}/{action=Index}");

            app.Run();
        }
    }
}
