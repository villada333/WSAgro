using WSAgro.DAO.Entidades;

namespace WSAgro.DAO.Interfaces;

public interface ICatalogoPlagaEnfermedadDAO
{
    // Operaciones de Lectura
    Task<List<CatalogoPlagaEnfermedad>> ObtenerTodosAsync();
    Task<List<CatalogoPlagaEnfermedad>> ObtenerPorIdAsync(Guid id);

    // Operaciones de Escritura
    Task CrearAsync(CatalogoPlagaEnfermedad entidad);
    Task CrearVariosAsync(IEnumerable<CatalogoPlagaEnfermedad> entidades);

    // Operaciones Masivas (Actualización y Eliminación)
    Task ActualizarVariosAsync(IEnumerable<CatalogoPlagaEnfermedad> entidades);
    Task EliminarVariosAsync(IEnumerable<Guid> ids);
}
