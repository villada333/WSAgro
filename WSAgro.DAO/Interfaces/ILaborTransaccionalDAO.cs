using WSAgro.DAO.Entidades;

namespace WSAgro.DAO.Interfaces;

public interface ILaborTransaccionalDAO
{
    // Operaciones de Lectura
    Task<List<LaborTransaccional>> ObtenerTodosAsync();
    Task<List<LaborTransaccional>> ObtenerPorIdAsync(Guid id);

    // Operaciones de Escritura
    Task CrearAsync(LaborTransaccional entidad);
    Task CrearVariosAsync(IEnumerable<LaborTransaccional> entidades);

    // Operaciones Masivas (Actualización y Eliminación)
    Task ActualizarVariosAsync(IEnumerable<LaborTransaccional> entidades);
    Task EliminarVariosAsync(IEnumerable<Guid> ids);
}
