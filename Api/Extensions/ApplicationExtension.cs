using Application.Repositories;
using Application.Repositories.Interfaces;
using Application.Services;
using Application.Services.Interfaces;
using Infra;
using Infra.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using System.Text;

namespace read_cloud.Extensions;

public static class ApplicationExtension
{
    public static IServiceCollection BuildControllers(this IServiceCollection service)
    {
        service.AddCors();
        service.AddControllers();
        service.AddHealthChecks();

        return service;
    }

    public static IServiceCollection BuildAuthentication(this IServiceCollection service, WebApplicationBuilder builder)
    {
        string key = builder.Configuration.GetSection("Jwt:Key").Value ?? string.Empty;

        if (string.IsNullOrEmpty(key))
            throw new ArgumentException("Nenhuma chave configurada");

        var byteKey = Encoding.ASCII.GetBytes(key);

        service
            .AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(byteKey),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });

        service.AddAuthorization();

        return service;
    }

    public static IServiceCollection BuildDependencies(this IServiceCollection service, IConfiguration config)
    {
        service.AddScoped(sp => new DbSession(config.GetConnectionString("DefaultConnection")));
        service.AddTransient<IUnitOfWork, UnitOfWork>();
        service.AddTransient<IRepositoryBase, RepositoryBase>();
        service.AddTransient<IUserRepository, UserRepository>();
        service.AddTransient<IAuthService, AuthService>();
        service.AddTransient<UserService>();

        return service;
    }

    public static IServiceCollection BuildLogger(this IServiceCollection service)
    {
        service.AddLogging(x =>
        {
            x.AddConsole();
        });

        return service;
    }

    public static void Configure(this IApplicationBuilder app)
    {
        app.UseHttpsRedirection();

        app.UseRouting();
        
        app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
        );
        
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints => { 
            endpoints.MapControllers();
        });
    }
}
