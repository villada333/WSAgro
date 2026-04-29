using WSAgro.DAO.Entidades;

namespace WSAgro.DAO.Interfaces;

public interface IMonitoreoMipDAO
{
    // Operaciones de Lectura
    Task<List<MonitoreoMip>> ObtenerTodosAsync();
    Task<List<MonitoreoMip>> ObtenerPorIdAsync(Guid id);

    // Operaciones de Escritura
    Task CrearAsync(MonitoreoMip entidad);
    Task CrearVariosAsync(IEnumerable<MonitoreoMip> entidades);

    // Operaciones Masivas (Actualización y Eliminación)
    Task ActualizarVariosAsync(IEnumerable<MonitoreoMip> entidades);
    Task EliminarVariosAsync(IEnumerable<Guid> ids);
}
