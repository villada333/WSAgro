using WSAgro.DAO.Entidades;

namespace WSAgro.DAO.Interfaces;

public interface IDetalleRemisionDAO
{
    // Operaciones de Lectura
    Task<List<DetalleRemision>> ObtenerTodosAsync();
    Task<List<DetalleRemision>> ObtenerPorIdAsync(Guid id);

    // Operaciones de Escritura
    Task CrearAsync(DetalleRemision entidad);
    Task CrearVariosAsync(IEnumerable<DetalleRemision> entidades);

    // Operaciones Masivas (Actualización y Eliminación)
    Task ActualizarVariosAsync(IEnumerable<DetalleRemision> entidades);
    Task EliminarVariosAsync(IEnumerable<Guid> ids);
}
