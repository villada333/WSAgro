using WSAgro.DAO.Entidades;

namespace WSAgro.DAO.Interfaces;

public interface IDetalleMonitoreoMipDAO
{
    // Operaciones de Lectura
    Task<List<DetalleMonitoreoMip>> ObtenerTodosAsync();
    Task<List<DetalleMonitoreoMip>> ObtenerPorIdAsync(Guid id);

    // Operaciones de Escritura
    Task CrearAsync(DetalleMonitoreoMip entidad);
    Task CrearVariosAsync(IEnumerable<DetalleMonitoreoMip> entidades);

    // Operaciones Masivas (Actualización y Eliminación)
    Task ActualizarVariosAsync(IEnumerable<DetalleMonitoreoMip> entidades);
    Task EliminarVariosAsync(IEnumerable<Guid> ids);
}
