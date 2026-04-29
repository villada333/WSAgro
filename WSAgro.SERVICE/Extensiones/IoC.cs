using Microsoft.Extensions.DependencyInjection;
using WSAgro.DAO.Interfaces;
using WSAgro.DAO.Implementaciones;
using WSAgro.SERVICE.Interfaces;
using WSAgro.SERVICE.Implementaciones;

namespace WSAgro.SERVICE.Extensiones;

public static class IoC
{
    public static void Register(IServiceCollection services)
    {
        services.AddScoped<IAnalisisRecursoDAO, AnalisisRecursoDAO>();
        services.AddScoped<IAnalisisRecurso, AnalisisRecursoImpl>();
        services.AddScoped<IAsistenciaCapacitacionDAO, AsistenciaCapacitacionDAO>();
        services.AddScoped<IAsistenciaCapacitacion, AsistenciaCapacitacionImpl>();
        services.AddScoped<ICapacitacionSstDAO, CapacitacionSstDAO>();
        services.AddScoped<ICapacitacionSst, CapacitacionSstImpl>();
        services.AddScoped<ICatalogoInsumoIcaDAO, CatalogoInsumoIcaDAO>();
        services.AddScoped<ICatalogoInsumoIca, CatalogoInsumoIcaImpl>();
        services.AddScoped<ICatalogoPlagaEnfermedadDAO, CatalogoPlagaEnfermedadDAO>();
        services.AddScoped<ICatalogoPlagaEnfermedad, CatalogoPlagaEnfermedadImpl>();
        services.AddScoped<IDetalleMonitoreoMipDAO, DetalleMonitoreoMipDAO>();
        services.AddScoped<IDetalleMonitoreoMip, DetalleMonitoreoMipImpl>();
        services.AddScoped<IDetalleRemisionDAO, DetalleRemisionDAO>();
        services.AddScoped<IDetalleRemision, DetalleRemisionImpl>();
        services.AddScoped<IEntregaEppDAO, EntregaEppDAO>();
        services.AddScoped<IEntregaEpp, EntregaEppImpl>();
        services.AddScoped<IEquipoHerramientaDAO, EquipoHerramientaDAO>();
        services.AddScoped<IEquipoHerramienta, EquipoHerramientaImpl>();
        services.AddScoped<IInventarioBodegaDAO, InventarioBodegaDAO>();
        services.AddScoped<IInventarioBodega, InventarioBodegaImpl>();
        services.AddScoped<ILaborTransaccionalDAO, LaborTransaccionalDAO>();
        services.AddScoped<ILaborTransaccional, LaborTransaccionalImpl>();
        services.AddScoped<ILoteDAO, LoteDAO>();
        services.AddScoped<ILote, LoteImpl>();
        services.AddScoped<IMantenimientoCalibracionDAO, MantenimientoCalibracionDAO>();
        services.AddScoped<IMantenimientoCalibracion, MantenimientoCalibracionImpl>();
        services.AddScoped<IMaterialPropagacionDAO, MaterialPropagacionDAO>();
        services.AddScoped<IMaterialPropagacion, MaterialPropagacionImpl>();
        services.AddScoped<IMonitoreoMipDAO, MonitoreoMipDAO>();
        services.AddScoped<IMonitoreoMip, MonitoreoMipImpl>();
        services.AddScoped<IPredioDAO, PredioDAO>();
        services.AddScoped<IPredio, PredioImpl>();
        services.AddScoped<IRegistroCosechaDAO, RegistroCosechaDAO>();
        services.AddScoped<IRegistroCosecha, RegistroCosechaImpl>();
        services.AddScoped<IRemisionDespachoDAO, RemisionDespachoDAO>();
        services.AddScoped<IRemisionDespacho, RemisionDespachoImpl>();
        services.AddScoped<IUmbralAccionFincaDAO, UmbralAccionFincaDAO>();
        services.AddScoped<IUmbralAccionFinca, UmbralAccionFincaImpl>();
    }
}
