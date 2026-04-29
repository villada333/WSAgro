using WSAgro.DAO.Entidades;

namespace WSAgro.DAO.Interfaces;

public interface IRemisionDespachoDAO
{
    // Operaciones de Lectura
    Task<List<RemisionDespacho>> ObtenerTodosAsync();
    Task<List<RemisionDespacho>> ObtenerPorIdAsync(Guid id);

    // Operaciones de Escritura
    Task CrearAsync(RemisionDespacho entidad);
    Task CrearVariosAsync(IEnumerable<RemisionDespacho> entidades);

    // Operaciones Masivas (Actualización y Eliminación)
    Task ActualizarVariosAsync(IEnumerable<RemisionDespacho> entidades);
    Task EliminarVariosAsync(IEnumerable<Guid> ids);
}
