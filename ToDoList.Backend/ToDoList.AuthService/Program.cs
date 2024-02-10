
using Microsoft.AspNetCore.Identity;
using ToDoList.AuthService.Data;
using ToDoList.AuthService.Models;
using ToDoList.AuthService.Service.IService;
using ToDoList.AuthService.Service;
using Microsoft.EntityFrameworkCore;

namespace ToDoList.AuthService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddDbContext<AuthenticationDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DbConnection")));

            var allowedOrigins = "AllowedOrigins";
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: allowedOrigins,
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:3000", "http://localhost:4200", "http://localhost:8080", "http://localhost:80", "http://localhost").AllowAnyMethod().AllowAnyHeader();
                    });
            });

            // Populating JwtOptions class with
            // information from appsettings.json.
            builder.Services.Configure<JwtOptions>(
                builder.Configuration.GetSection("ApiSettings:JwtOptions"));

            // Registring ApplicationUser as our Identity User model
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<AuthenticationDbContext>().AddDefaultTokenProviders();

            builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors(allowedOrigins);

            // This api is managing authentication, so we add this.
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            ApplyMigration(app);
            app.Run();
        }

        public static void ApplyMigration(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var _db = scope.ServiceProvider.GetRequiredService<AuthenticationDbContext>();

                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
        }
    }
}
