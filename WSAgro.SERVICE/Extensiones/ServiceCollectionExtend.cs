using Microsoft.Extensions.DependencyInjection;
using WSAgro.SERVICE.Mapping;

namespace WSAgro.SERVICE.Extensiones;

public static class ServiceCollectionExtend
{
    public static void AddServices(this IServiceCollection services)
    {
        IoC.Register(services);
        services.AddAutoMapper(typeof(MappingProfile));
    }
}
