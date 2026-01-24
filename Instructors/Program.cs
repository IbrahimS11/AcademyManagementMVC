using Instructors.Repository;
using Microsoft.AspNetCore.Identity;

namespace Instructors
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddSession(builder=>
            {
                builder.IdleTimeout = TimeSpan.FromMinutes(5);
                builder.Cookie.HttpOnly = true;
                builder.Cookie.IsEssential = true;
            });
            //AddScoped Means that the service will be created once per client request (connection).
            //but AddTransient means that the service will be created each time it is requested.
            //and AddSingleton means that the service will be created only once and shared throughout the application's lifetime.
            builder.Services.AddScoped<ICourseRepository, CourseRepository>();
            builder.Services.AddScoped<ICrsResultRepository, CrsResultRepository>();

            builder.Services.AddScoped<IInstructorRepository, InstructorRepository>();
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
           // builder.Services.AddScoped<IRepository<Trainee>,TraineeRepository>();
            builder.Services.AddScoped<ITraineeRepository, TraineeRepository>();

            builder.Services.AddDbContext<AppDbContext>(
               option => option.UseSqlServer(builder.Configuration.GetConnectionString("CS")));

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            })
                .AddEntityFrameworkStores<AppDbContext>();

            var app = builder.Build();

           
            
            
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseSession();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            

            app.MapStaticAssets();
            
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Course}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
