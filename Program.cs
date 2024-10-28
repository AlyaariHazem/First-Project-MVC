using FirstProjectWithMVC.Models;
using FirstProjectWithMVC.Repository;
using FirstProjectWithMVC.Repository.School;
using Microsoft.AspNetCore.Identity;
using SchoolManagementSystem.Models;

namespace FirstProjectWithMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews(
            // conf=>conf.Filters.Add("", ""); //piple line Filter
            );

            //connection with Database 
            builder.Services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            }
            );

            builder.Services.AddScoped<IStagesRepository, StagesRepository>();
            builder.Services.AddScoped<IClassesRepository, ClassesRepository>();
            builder.Services.AddScoped<IDivisionRepository, DivisionRepository>();
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(option =>
            {
                option.Password.RequiredLength = 4;
                option.Password.RequireDigit = false;
                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequireUppercase = false;
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

            app.MapControllerRoute(
              name: "default",
              pattern: "{controller=Account}/{action=Index}");


            app.Run();

        }

    }
}
