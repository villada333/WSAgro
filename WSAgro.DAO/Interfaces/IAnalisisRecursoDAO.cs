using WSAgro.DAO.Entidades;

namespace WSAgro.DAO.Interfaces;

public interface IAnalisisRecursoDAO
{
    // Operaciones de Lectura
    Task<List<AnalisisRecurso>> ObtenerTodosAsync();
    Task<List<AnalisisRecurso>> ObtenerPorIdAsync(Guid id);

    // Operaciones de Escritura
    Task CrearAsync(AnalisisRecurso entidad);
    Task CrearVariosAsync(IEnumerable<AnalisisRecurso> entidades);

    // Operaciones Masivas (Actualización y Eliminación)
    Task ActualizarVariosAsync(IEnumerable<AnalisisRecurso> entidades);
    Task EliminarVariosAsync(IEnumerable<Guid> ids);
}
