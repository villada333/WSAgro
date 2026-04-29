using WSAgro.DAO.Entidades;

namespace WSAgro.DAO.Interfaces;

public interface IPredioDAO
{
    // Operaciones de Lectura
    Task<List<Predio>> ObtenerTodosAsync();
    Task<List<Predio>> ObtenerPorIdAsync(Guid id);

    // Operaciones de Escritura
    Task CrearAsync(Predio entidad);
    Task CrearVariosAsync(IEnumerable<Predio> entidades);

    // Operaciones Masivas (Actualización y Eliminación)
    Task ActualizarVariosAsync(IEnumerable<Predio> entidades);
    Task EliminarVariosAsync(IEnumerable<Guid> ids);
}
