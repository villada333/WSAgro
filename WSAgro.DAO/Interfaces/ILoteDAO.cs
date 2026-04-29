using WSAgro.DAO.Entidades;

namespace WSAgro.DAO.Interfaces;

public interface ILoteDAO
{
    // Operaciones de Lectura
    Task<List<Lote>> ObtenerTodosAsync();
    Task<List<Lote>> ObtenerPorIdAsync(Guid id);

    // Operaciones de Escritura
    Task CrearAsync(Lote entidad);
    Task CrearVariosAsync(IEnumerable<Lote> entidades);

    // Operaciones Masivas (Actualización y Eliminación)
    Task ActualizarVariosAsync(IEnumerable<Lote> entidades);
    Task EliminarVariosAsync(IEnumerable<Guid> ids);
}
