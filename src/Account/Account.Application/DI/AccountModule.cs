using Acccount.Application.Services;
using Acccount.Infrastructure.dbcontext;
using Account.Application.Interfaces;
using Account.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;



namespace Account.Application.DI
{
    public static class AccountModule
    {
        public static IServiceCollection AddAccountModule(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
           options.UseSqlServer(config.GetConnectionString("DC")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
             .AddEntityFrameworkStores<ApplicationDbContext>()
             .AddDefaultTokenProviders();

            services.AddScoped<AuthService>();

            services.AddTransient<IEmailSender, EmailSender>();

            services.AddScoped<IPasswordResetTokenService, PasswordResetTokenService>();

            return services;
        }
    }
}
