using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Quiz_App.Models
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }

        public DbSet<Exam> Exams { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<UserDegree> UserDegrees { get; set; }

    }
}
