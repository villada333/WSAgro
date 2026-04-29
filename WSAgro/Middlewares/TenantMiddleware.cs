using System.Security.Claims;
using WSAgro.DAO.Interfaces;

namespace WSAgro.Middlewares;

public class TenantMiddleware
{
    private readonly RequestDelegate _next;

    public TenantMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, ITenantProvider tenantProvider)
    {
        // El claim Company_ID es inyectado en el JWT desde WS_Auth
        var tenantId = context.User.FindFirst("Company_ID")?.Value;

        // Fallback: Si el Gateway decide enviarlo como Header en lugar de dejar que WSAgro decodifique el JWT
        if (string.IsNullOrEmpty(tenantId) && context.Request.Headers.TryGetValue("X-Company-ID", out var headerTenant))
        {
            tenantId = headerTenant.ToString();
        }

        if (!string.IsNullOrEmpty(tenantId))
        {
            tenantProvider.SetTenantId(tenantId);
        }

        await _next(context);
    }
}
