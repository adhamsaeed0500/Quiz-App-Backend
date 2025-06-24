using Exam.Application.Interfaces;
using Exam.Application.Services;
using Exam.Infrastructure.dbcontext;
using Exam.Infrastructure.Repositories;
using Exam.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;



namespace Exam.Application.DI
{
    public static class ExamModule
    {
        public static IServiceCollection AddExamModule(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IExamsService, ExamsService>();
            services.AddScoped<ICreateExamAsync, ExamRepository>();

            services.AddDbContext<ExamDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DC")));
            return services;
        }
    }
}
