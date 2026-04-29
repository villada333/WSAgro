using WSAgro.DAO.Entidades;

namespace WSAgro.DAO.Interfaces;

public interface IMaterialPropagacionDAO
{
    // Operaciones de Lectura
    Task<List<MaterialPropagacion>> ObtenerTodosAsync();
    Task<List<MaterialPropagacion>> ObtenerPorIdAsync(Guid id);

    // Operaciones de Escritura
    Task CrearAsync(MaterialPropagacion entidad);
    Task CrearVariosAsync(IEnumerable<MaterialPropagacion> entidades);

    // Operaciones Masivas (Actualización y Eliminación)
    Task ActualizarVariosAsync(IEnumerable<MaterialPropagacion> entidades);
    Task EliminarVariosAsync(IEnumerable<Guid> ids);
}
