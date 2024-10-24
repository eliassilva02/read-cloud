using Application.Repositories;
using Application.Repositories.Interfaces;
using Application.Services;
using Application.Services.Interfaces;
using Hellang.Middleware.ProblemDetails;
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
        ProblemDetailsExtensions.AddProblemDetails(service, o => o.OnBeforeWriteDetails = (ctx, problem) =>
        {
            problem.Extensions["traceId"] = Activity.Current?.Id ?? ctx.TraceIdentifier;
        });

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
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(byteKey),
                    ValidateIssuer = true,
                    ValidateAudience = true
                };
            });

        return service;
    }

    public static IServiceCollection BuildDependencies(this IServiceCollection service, IConfiguration config)
    {
        service.AddScoped(sp => new DbSession(config.GetConnectionString("DefaultConnection")));
        service.AddTransient<IUnitOfWork, UnitOfWork>();
        service.AddTransient<IRepositoryBase, RepositoryBase>();
        service.AddTransient<IUserRepository, UserRepository>();
        service.AddTransient<IAuthService, AuthService>();

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

        app.UseProblemDetails();
        
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints => { 
            endpoints.MapControllers();
        });
    }
}
