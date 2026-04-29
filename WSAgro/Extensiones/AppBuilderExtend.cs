using AspNetCoreRateLimit;
using Hangfire;

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

        app.UseHangfireDashboard();

        app.MapControllers();
    }
}
