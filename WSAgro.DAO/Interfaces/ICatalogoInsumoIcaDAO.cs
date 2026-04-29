using WSAgro.DAO.Entidades;

namespace WSAgro.DAO.Interfaces;

public interface ICatalogoInsumoIcaDAO
{
    // Operaciones de Lectura
    Task<List<CatalogoInsumoIca>> ObtenerTodosAsync();
    Task<List<CatalogoInsumoIca>> ObtenerPorIdAsync(Guid id);

    // Operaciones de Escritura
    Task CrearAsync(CatalogoInsumoIca entidad);
    Task CrearVariosAsync(IEnumerable<CatalogoInsumoIca> entidades);

    // Operaciones Masivas (Actualización y Eliminación)
    Task ActualizarVariosAsync(IEnumerable<CatalogoInsumoIca> entidades);
    Task EliminarVariosAsync(IEnumerable<Guid> ids);
}
