using WSAgro.DAO.Entidades;

namespace WSAgro.DAO.Interfaces;

public interface IMantenimientoCalibracionDAO
{
    // Operaciones de Lectura
    Task<List<MantenimientoCalibracion>> ObtenerTodosAsync();
    Task<List<MantenimientoCalibracion>> ObtenerPorIdAsync(Guid id);

    // Operaciones de Escritura
    Task CrearAsync(MantenimientoCalibracion entidad);
    Task CrearVariosAsync(IEnumerable<MantenimientoCalibracion> entidades);

    // Operaciones Masivas (Actualización y Eliminación)
    Task ActualizarVariosAsync(IEnumerable<MantenimientoCalibracion> entidades);
    Task EliminarVariosAsync(IEnumerable<Guid> ids);
}
