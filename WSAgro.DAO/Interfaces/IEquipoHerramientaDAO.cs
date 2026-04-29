using WSAgro.DAO.Entidades;

namespace WSAgro.DAO.Interfaces;

public interface IEquipoHerramientaDAO
{
    // Operaciones de Lectura
    Task<List<EquipoHerramienta>> ObtenerTodosAsync();
    Task<List<EquipoHerramienta>> ObtenerPorIdAsync(Guid id);

    // Operaciones de Escritura
    Task CrearAsync(EquipoHerramienta entidad);
    Task CrearVariosAsync(IEnumerable<EquipoHerramienta> entidades);

    // Operaciones Masivas (Actualización y Eliminación)
    Task ActualizarVariosAsync(IEnumerable<EquipoHerramienta> entidades);
    Task EliminarVariosAsync(IEnumerable<Guid> ids);
}
