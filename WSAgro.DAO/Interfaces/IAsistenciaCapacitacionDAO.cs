using WSAgro.DAO.Entidades;

namespace WSAgro.DAO.Interfaces;

public interface IAsistenciaCapacitacionDAO
{
    // Operaciones de Lectura
    Task<List<AsistenciaCapacitacion>> ObtenerTodosAsync();
    Task<List<AsistenciaCapacitacion>> ObtenerPorIdAsync(Guid id);

    // Operaciones de Escritura
    Task CrearAsync(AsistenciaCapacitacion entidad);
    Task CrearVariosAsync(IEnumerable<AsistenciaCapacitacion> entidades);

    // Operaciones Masivas (Actualización y Eliminación)
    Task ActualizarVariosAsync(IEnumerable<AsistenciaCapacitacion> entidades);
    Task EliminarVariosAsync(IEnumerable<Guid> ids);
}
