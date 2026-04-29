using WSAgro.DAO.Entidades;

namespace WSAgro.DAO.Interfaces;

public interface IUmbralAccionFincaDAO
{
    // Operaciones de Lectura
    Task<List<UmbralAccionFinca>> ObtenerTodosAsync();
    Task<List<UmbralAccionFinca>> ObtenerPorIdAsync(Guid id);

    // Operaciones de Escritura
    Task CrearAsync(UmbralAccionFinca entidad);
    Task CrearVariosAsync(IEnumerable<UmbralAccionFinca> entidades);

    // Operaciones Masivas (Actualización y Eliminación)
    Task ActualizarVariosAsync(IEnumerable<UmbralAccionFinca> entidades);
    Task EliminarVariosAsync(IEnumerable<Guid> ids);
}
