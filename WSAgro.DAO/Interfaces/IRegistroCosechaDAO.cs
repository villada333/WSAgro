using WSAgro.DAO.Entidades;

namespace WSAgro.DAO.Interfaces;

public interface IRegistroCosechaDAO
{
    // Operaciones de Lectura
    Task<List<RegistroCosecha>> ObtenerTodosAsync();
    Task<List<RegistroCosecha>> ObtenerPorIdAsync(Guid id);

    // Operaciones de Escritura
    Task CrearAsync(RegistroCosecha entidad);
    Task CrearVariosAsync(IEnumerable<RegistroCosecha> entidades);

    // Operaciones Masivas (Actualización y Eliminación)
    Task ActualizarVariosAsync(IEnumerable<RegistroCosecha> entidades);
    Task EliminarVariosAsync(IEnumerable<Guid> ids);
}
