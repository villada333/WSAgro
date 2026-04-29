using Microsoft.EntityFrameworkCore;
using WSAgro.DAO.Entidades;
using WSAgro.DAO.Interfaces;

namespace WSAgro.DAO.Implementaciones;

public class CapacitacionSstDAO : ICapacitacionSstDAO
{
    #region Inyecciones y Constructor
    private readonly DbContexto _dbContext;
    public CapacitacionSstDAO(DbContexto dbContexto)
    {
        _dbContext = dbContexto;
    }
    #endregion

    #region Obtener Todos
    public async Task<List<CapacitacionSst>> ObtenerTodosAsync()
    {
        return await _dbContext.CapacitacionSst.AsNoTracking().ToListAsync();
    }
    #endregion

    #region Obtener por Id
    public async Task<List<CapacitacionSst>> ObtenerPorIdAsync(Guid id)
    {
        return await _dbContext.CapacitacionSst.AsNoTracking()
            .Where(e => e.Id == id)
            .ToListAsync();
    }
    #endregion

    #region Crear
    public async Task CrearAsync(CapacitacionSst entidad)
    {
        await _dbContext.CapacitacionSst.AddAsync(entidad);
        await _dbContext.SaveChangesAsync();
    }
    #endregion

    #region Crear Varios
    public async Task CrearVariosAsync(IEnumerable<CapacitacionSst> entidades)
    {
        await _dbContext.CapacitacionSst.AddRangeAsync(entidades);
        await _dbContext.SaveChangesAsync();
    }
    #endregion

    #region Actualizar Varios
    public async Task ActualizarVariosAsync(IEnumerable<CapacitacionSst> entidades)
    {
        _dbContext.CapacitacionSst.UpdateRange(entidades);
        await _dbContext.SaveChangesAsync();
    }
    #endregion

    #region Eliminar Varios
    public async Task EliminarVariosAsync(IEnumerable<Guid> ids)
    {
        var entidades = await _dbContext.CapacitacionSst
            .Where(e => ids.Contains(e.Id))
            .ToListAsync();
        _dbContext.CapacitacionSst.RemoveRange(entidades);
        await _dbContext.SaveChangesAsync();
    }
    #endregion
}
