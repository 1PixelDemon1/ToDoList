using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManager.Application.Interface;
using TaskManager.Infrastructure.Data;
using TaskManager.Infrastructure.Repository;

namespace TaskManager.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<TaskManagerDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });

            // Fixes tiny bug with DateTime Postgres values.
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

    }
}
