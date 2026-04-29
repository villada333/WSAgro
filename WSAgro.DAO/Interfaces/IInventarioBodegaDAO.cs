using WSAgro.DAO.Entidades;

namespace WSAgro.DAO.Interfaces;

public interface IInventarioBodegaDAO
{
    // Operaciones de Lectura
    Task<List<InventarioBodega>> ObtenerTodosAsync();
    Task<List<InventarioBodega>> ObtenerPorIdAsync(Guid id);

    // Operaciones de Escritura
    Task CrearAsync(InventarioBodega entidad);
    Task CrearVariosAsync(IEnumerable<InventarioBodega> entidades);

    // Operaciones Masivas (Actualización y Eliminación)
    Task ActualizarVariosAsync(IEnumerable<InventarioBodega> entidades);
    Task EliminarVariosAsync(IEnumerable<Guid> ids);
}
