using AspNetCoreRateLimit;
using Hangfire;
using WSAgro.Middlewares;

namespace WSAgro.Extensiones;

public static class AppBuilderExtend
{
    public static void InitConfigAPI(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1.0.0/swagger.json", "WSAgro v1.0.0");
        });

        app.UseRouting();

        app.UseIpRateLimiting();

        app.UseCors();

        app.UseAuthentication();

        app.UseAuthorization();

        app.UseMiddleware<TenantMiddleware>();

        app.UseHangfireDashboard();

        app.MapGet("/estado", () => Results.Ok(new { estado = "En línea", servicio = "WSAgro", timestamp = DateTime.UtcNow }));

        app.MapControllers();
    }
}
