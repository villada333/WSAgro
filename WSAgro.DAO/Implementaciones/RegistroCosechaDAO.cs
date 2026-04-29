using Microsoft.EntityFrameworkCore;
using WSAgro.DAO.Entidades;
using WSAgro.DAO.Interfaces;

namespace WSAgro.DAO.Implementaciones;

public class RegistroCosechaDAO : IRegistroCosechaDAO
{
    #region Inyecciones y Constructor
    private readonly DbContexto _dbContext;
    public RegistroCosechaDAO(DbContexto dbContexto)
    {
        _dbContext = dbContexto;
    }
    #endregion

    #region Obtener Todos
    public async Task<List<RegistroCosecha>> ObtenerTodosAsync()
    {
        return await _dbContext.RegistroCosecha.AsNoTracking().ToListAsync();
    }
    #endregion

    #region Obtener por Id
    public async Task<List<RegistroCosecha>> ObtenerPorIdAsync(Guid id)
    {
        return await _dbContext.RegistroCosecha.AsNoTracking()
            .Where(e => e.Id == id)
            .ToListAsync();
    }
    #endregion

    #region Crear
    public async Task CrearAsync(RegistroCosecha entidad)
    {
        await _dbContext.RegistroCosecha.AddAsync(entidad);
        await _dbContext.SaveChangesAsync();
    }
    #endregion

    #region Crear Varios
    public async Task CrearVariosAsync(IEnumerable<RegistroCosecha> entidades)
    {
        await _dbContext.RegistroCosecha.AddRangeAsync(entidades);
        await _dbContext.SaveChangesAsync();
    }
    #endregion

    #region Actualizar Varios
    public async Task ActualizarVariosAsync(IEnumerable<RegistroCosecha> entidades)
    {
        _dbContext.RegistroCosecha.UpdateRange(entidades);
        await _dbContext.SaveChangesAsync();
    }
    #endregion

    #region Eliminar Varios
    public async Task EliminarVariosAsync(IEnumerable<Guid> ids)
    {
        var entidades = await _dbContext.RegistroCosecha
            .Where(e => ids.Contains(e.Id))
            .ToListAsync();
        _dbContext.RegistroCosecha.RemoveRange(entidades);
        await _dbContext.SaveChangesAsync();
    }
    #endregion
}
