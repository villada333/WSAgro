using WSAgro.DAO.Entidades;

namespace WSAgro.DAO.Interfaces;

public interface IEntregaEppDAO
{
    // Operaciones de Lectura
    Task<List<EntregaEpp>> ObtenerTodosAsync();
    Task<List<EntregaEpp>> ObtenerPorIdAsync(Guid id);

    // Operaciones de Escritura
    Task CrearAsync(EntregaEpp entidad);
    Task CrearVariosAsync(IEnumerable<EntregaEpp> entidades);

    // Operaciones Masivas (Actualización y Eliminación)
    Task ActualizarVariosAsync(IEnumerable<EntregaEpp> entidades);
    Task EliminarVariosAsync(IEnumerable<Guid> ids);
}
