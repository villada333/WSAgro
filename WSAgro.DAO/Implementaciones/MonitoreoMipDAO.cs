using Microsoft.EntityFrameworkCore;
using WSAgro.DAO.Entidades;
using WSAgro.DAO.Interfaces;

namespace WSAgro.DAO.Implementaciones;

public class MonitoreoMipDAO : IMonitoreoMipDAO
{
    #region Inyecciones y Constructor
    private readonly DbContexto _dbContext;
    public MonitoreoMipDAO(DbContexto dbContexto)
    {
        _dbContext = dbContexto;
    }
    #endregion

    #region Obtener Todos
    public async Task<List<MonitoreoMip>> ObtenerTodosAsync()
    {
        return await _dbContext.MonitoreoMip.AsNoTracking().ToListAsync();
    }
    #endregion

    #region Obtener por Id
    public async Task<List<MonitoreoMip>> ObtenerPorIdAsync(Guid id)
    {
        return await _dbContext.MonitoreoMip.AsNoTracking()
            .Where(e => e.Id == id)
            .ToListAsync();
    }
    #endregion

    #region Crear
    public async Task CrearAsync(MonitoreoMip entidad)
    {
        await _dbContext.MonitoreoMip.AddAsync(entidad);
        await _dbContext.SaveChangesAsync();
    }
    #endregion

    #region Crear Varios
    public async Task CrearVariosAsync(IEnumerable<MonitoreoMip> entidades)
    {
        await _dbContext.MonitoreoMip.AddRangeAsync(entidades);
        await _dbContext.SaveChangesAsync();
    }
    #endregion

    #region Actualizar Varios
    public async Task ActualizarVariosAsync(IEnumerable<MonitoreoMip> entidades)
    {
        _dbContext.MonitoreoMip.UpdateRange(entidades);
        await _dbContext.SaveChangesAsync();
    }
    #endregion

    #region Eliminar Varios
    public async Task EliminarVariosAsync(IEnumerable<Guid> ids)
    {
        var entidades = await _dbContext.MonitoreoMip
            .Where(e => ids.Contains(e.Id))
            .ToListAsync();
        _dbContext.MonitoreoMip.RemoveRange(entidades);
        await _dbContext.SaveChangesAsync();
    }
    #endregion
}
