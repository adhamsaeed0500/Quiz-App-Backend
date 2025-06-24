using Exam.Domain.Entities;
using Microsoft.EntityFrameworkCore;



namespace Exam.Infrastructure.dbcontext
{       
        public class ExamDbContext : DbContext
        {
            public ExamDbContext(DbContextOptions<ExamDbContext> options)
                : base(options)
            {
            }

        public DbSet<ExamEntity> Exams => Set<ExamEntity>();
        public DbSet<Questions> Questions => Set<Questions>();
        public DbSet<UserDegree> UserDegrees => Set<UserDegree>();
        }
    
}
