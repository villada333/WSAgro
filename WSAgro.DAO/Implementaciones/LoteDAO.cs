using Microsoft.EntityFrameworkCore;
using WSAgro.DAO.Entidades;
using WSAgro.DAO.Interfaces;

namespace WSAgro.DAO.Implementaciones;

public class LoteDAO : ILoteDAO
{
    #region Inyecciones y Constructor
    private readonly DbContexto _dbContext;
    public LoteDAO(DbContexto dbContexto)
    {
        _dbContext = dbContexto;
    }
    #endregion

    #region Obtener Todos
    public async Task<List<Lote>> ObtenerTodosAsync()
    {
        return await _dbContext.Lote.AsNoTracking().ToListAsync();
    }
    #endregion

    #region Obtener por Id
    public async Task<List<Lote>> ObtenerPorIdAsync(Guid id)
    {
        return await _dbContext.Lote.AsNoTracking()
            .Where(e => e.Id == id)
            .ToListAsync();
    }
    #endregion

    #region Crear
    public async Task CrearAsync(Lote entidad)
    {
        await _dbContext.Lote.AddAsync(entidad);
        await _dbContext.SaveChangesAsync();
    }
    #endregion

    #region Crear Varios
    public async Task CrearVariosAsync(IEnumerable<Lote> entidades)
    {
        await _dbContext.Lote.AddRangeAsync(entidades);
        await _dbContext.SaveChangesAsync();
    }
    #endregion

    #region Actualizar Varios
    public async Task ActualizarVariosAsync(IEnumerable<Lote> entidades)
    {
        _dbContext.Lote.UpdateRange(entidades);
        await _dbContext.SaveChangesAsync();
    }
    #endregion

    #region Eliminar Varios
    public async Task EliminarVariosAsync(IEnumerable<Guid> ids)
    {
        var entidades = await _dbContext.Lote
            .Where(e => ids.Contains(e.Id))
            .ToListAsync();
        _dbContext.Lote.RemoveRange(entidades);
        await _dbContext.SaveChangesAsync();
    }
    #endregion
}
