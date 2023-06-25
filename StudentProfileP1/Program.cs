using Microsoft.EntityFrameworkCore;
using StudentProfileP1.Data;
using StudentProfileP1.Manager.ManagerImplenentation;
using StudentProfileP1.Manager.ManagerInterface;
using StudentProfileP1.Repository.RepositoryImplementation;
using StudentProfileP1.Repository.RepositoryInterface;

namespace StudentProfileP1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<StudentDbContext>(Options => Options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")
                ));
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddScoped<IStudentsManager, StudentsManager>();
            builder.Services.AddScoped<IStudentsRepository, StudentsRepository>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}