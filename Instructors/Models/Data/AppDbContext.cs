using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Instructors.ViewModel;
namespace Instructors.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser> 
    {
        public AppDbContext() : base()
        {
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Instructor> Instructors { get; set; } = null!;
        public DbSet<Department> Departments { get; set; } = null!;
        public DbSet<Course> Courses { get; set; } = null!;
        public DbSet<Trainee> Trainees { get; set; } = null!;
        public DbSet<CrsResult> CrsResults { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.;Database=InstructorsDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
        }
    }
}
