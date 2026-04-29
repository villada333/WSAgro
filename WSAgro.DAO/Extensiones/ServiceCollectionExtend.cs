using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WSAgro.DAO.Extensiones;

public static class ServiceCollectionExtend
{
    public static void AddPersistencia(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration["Connection"]
            ?? throw new InvalidOperationException("La cadena de conexión 'Connection' no está configurada.");

        services.AddDbContext<DbContexto>(options =>
            options.UseNpgsql(connectionString));
    }
}
