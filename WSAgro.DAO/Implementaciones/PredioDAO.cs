using Microsoft.EntityFrameworkCore;
using WSAgro.DAO.Entidades;
using WSAgro.DAO.Interfaces;

namespace WSAgro.DAO.Implementaciones;

public class PredioDAO : IPredioDAO
{
    #region Inyecciones y Constructor
    private readonly DbContexto _dbContext;
    public PredioDAO(DbContexto dbContexto)
    {
        _dbContext = dbContexto;
    }
    #endregion

    #region Obtener Todos
    public async Task<List<Predio>> ObtenerTodosAsync()
    {
        return await _dbContext.Predio.AsNoTracking().ToListAsync();
    }
    #endregion

    #region Obtener por Id
    public async Task<List<Predio>> ObtenerPorIdAsync(Guid id)
    {
        return await _dbContext.Predio.AsNoTracking()
            .Where(e => e.Id == id)
            .ToListAsync();
    }
    #endregion

    #region Crear
    public async Task CrearAsync(Predio entidad)
    {
        await _dbContext.Predio.AddAsync(entidad);
        await _dbContext.SaveChangesAsync();
    }
    #endregion

    #region Crear Varios
    public async Task CrearVariosAsync(IEnumerable<Predio> entidades)
    {
        await _dbContext.Predio.AddRangeAsync(entidades);
        await _dbContext.SaveChangesAsync();
    }
    #endregion

    #region Actualizar Varios
    public async Task ActualizarVariosAsync(IEnumerable<Predio> entidades)
    {
        _dbContext.Predio.UpdateRange(entidades);
        await _dbContext.SaveChangesAsync();
    }
    #endregion

    #region Eliminar Varios
    public async Task EliminarVariosAsync(IEnumerable<Guid> ids)
    {
        var entidades = await _dbContext.Predio
            .Where(e => ids.Contains(e.Id))
            .ToListAsync();
        _dbContext.Predio.RemoveRange(entidades);
        await _dbContext.SaveChangesAsync();
    }
    #endregion
}
