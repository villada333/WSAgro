using Microsoft.EntityFrameworkCore;
using WSAgro.DAO.Entidades;
using WSAgro.DAO.Interfaces;

namespace WSAgro.DAO.Implementaciones;

public class LaborTransaccionalDAO : ILaborTransaccionalDAO
{
    #region Inyecciones y Constructor
    private readonly DbContexto _dbContext;
    public LaborTransaccionalDAO(DbContexto dbContexto)
    {
        _dbContext = dbContexto;
    }
    #endregion

    #region Obtener Todos
    public async Task<List<LaborTransaccional>> ObtenerTodosAsync()
    {
        return await _dbContext.LaborTransaccional.AsNoTracking().ToListAsync();
    }
    #endregion

    #region Obtener por Id
    public async Task<List<LaborTransaccional>> ObtenerPorIdAsync(Guid id)
    {
        return await _dbContext.LaborTransaccional.AsNoTracking()
            .Where(e => e.Id == id)
            .ToListAsync();
    }
    #endregion

    #region Crear
    public async Task CrearAsync(LaborTransaccional entidad)
    {
        await _dbContext.LaborTransaccional.AddAsync(entidad);
        await _dbContext.SaveChangesAsync();
    }
    #endregion

    #region Crear Varios
    public async Task CrearVariosAsync(IEnumerable<LaborTransaccional> entidades)
    {
        await _dbContext.LaborTransaccional.AddRangeAsync(entidades);
        await _dbContext.SaveChangesAsync();
    }
    #endregion

    #region Actualizar Varios
    public async Task ActualizarVariosAsync(IEnumerable<LaborTransaccional> entidades)
    {
        _dbContext.LaborTransaccional.UpdateRange(entidades);
        await _dbContext.SaveChangesAsync();
    }
    #endregion

    #region Eliminar Varios
    public async Task EliminarVariosAsync(IEnumerable<Guid> ids)
    {
        var entidades = await _dbContext.LaborTransaccional
            .Where(e => ids.Contains(e.Id))
            .ToListAsync();
        _dbContext.LaborTransaccional.RemoveRange(entidades);
        await _dbContext.SaveChangesAsync();
    }
    #endregion
}
