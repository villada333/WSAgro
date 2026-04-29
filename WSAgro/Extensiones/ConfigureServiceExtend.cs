using AspNetCoreRateLimit;
using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using WSAgro.DAO.Extensiones;
using WSAgro.SERVICE.Extensiones;
using System.Security.Cryptography;
using WSAgro.DAO.Interfaces;
using WSAgro.SERVICE.Implementaciones;

namespace WSAgro.Extensiones;

public static class ServiceExtensions
{
    public static void InitConfigAPI(this IHostApplicationBuilder builder)
    {
        // Swagger
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1.0.0", new OpenApiInfo
            {
                Title = "WSAgro v1.0.0",
                Version = "v1.0.0"
            });
        });

        // JWT desde configuración (RS256 Asimétrico)
        var publicKeyPem = builder.Configuration["JwtPublicKeyPem"]?.Replace("\\n", "\n")
            ?? throw new InvalidOperationException("La clave pública JWT (JwtPublicKeyPem) no está configurada.");

        // Procesar la clave pública PEM
        var rsa = RSA.Create();
        rsa.ImportFromPem(publicKeyPem.Trim());
        var key = new RsaSecurityKey(rsa);

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key,
                    ValidateIssuer = true,
                    ValidIssuer = builder.Configuration["JwtSettingsIssuer"],
                    ValidateAudience = true,
                    ValidAudience = builder.Configuration["JwtSettingsAudience"],
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(1)
                };
            });

        builder.Services.AddAuthorization();

        // Rate Limiting
        builder.Services.AddMemoryCache();
        builder.Services.Configure<IpRateLimitOptions>(builder.Configuration.GetSection("IpRateLimiting"));
        builder.Services.AddInMemoryRateLimiting();
        builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();

        // Hangfire (orquestación de tareas)
        builder.Services.AddHangfire(config => config.UseMemoryStorage());
        builder.Services.AddHangfireServer();

        // Persistencia y servicios
        builder.Services.AddPersistencia(builder.Configuration);
        builder.Services.AddServices();

        // Multi-Tenant
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddScoped<ITenantProvider, TenantProvider>();

        // Controladores
        builder.Services.AddControllers();

        // CORS
        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                policy.AllowAnyOrigin()
                      .AllowAnyHeader()
                      .AllowAnyMethod();
            });
        });
    }
}
