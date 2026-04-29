using Microsoft.EntityFrameworkCore;
using WSAgro.DAO.Entidades;
using WSAgro.DAO.Interfaces;

namespace WSAgro.DAO.Implementaciones;

public class DetalleMonitoreoMipDAO : IDetalleMonitoreoMipDAO
{
    #region Inyecciones y Constructor
    private readonly DbContexto _dbContext;
    public DetalleMonitoreoMipDAO(DbContexto dbContexto)
    {
        _dbContext = dbContexto;
    }
    #endregion

    #region Obtener Todos
    public async Task<List<DetalleMonitoreoMip>> ObtenerTodosAsync()
    {
        return await _dbContext.DetalleMonitoreoMip.AsNoTracking().ToListAsync();
    }
    #endregion

    #region Obtener por Id
    public async Task<List<DetalleMonitoreoMip>> ObtenerPorIdAsync(Guid id)
    {
        return await _dbContext.DetalleMonitoreoMip.AsNoTracking()
            .Where(e => e.Id == id)
            .ToListAsync();
    }
    #endregion

    #region Crear
    public async Task CrearAsync(DetalleMonitoreoMip entidad)
    {
        await _dbContext.DetalleMonitoreoMip.AddAsync(entidad);
        await _dbContext.SaveChangesAsync();
    }
    #endregion

    #region Crear Varios
    public async Task CrearVariosAsync(IEnumerable<DetalleMonitoreoMip> entidades)
    {
        await _dbContext.DetalleMonitoreoMip.AddRangeAsync(entidades);
        await _dbContext.SaveChangesAsync();
    }
    #endregion

    #region Actualizar Varios
    public async Task ActualizarVariosAsync(IEnumerable<DetalleMonitoreoMip> entidades)
    {
        _dbContext.DetalleMonitoreoMip.UpdateRange(entidades);
        await _dbContext.SaveChangesAsync();
    }
    #endregion

    #region Eliminar Varios
    public async Task EliminarVariosAsync(IEnumerable<Guid> ids)
    {
        var entidades = await _dbContext.DetalleMonitoreoMip
            .Where(e => ids.Contains(e.Id))
            .ToListAsync();
        _dbContext.DetalleMonitoreoMip.RemoveRange(entidades);
        await _dbContext.SaveChangesAsync();
    }
    #endregion
}
