using Microsoft.EntityFrameworkCore;
using WSAgro.DAO.Entidades;
using WSAgro.DAO.Interfaces;

namespace WSAgro.DAO.Implementaciones;

public class CatalogoInsumoIcaDAO : ICatalogoInsumoIcaDAO
{
    #region Inyecciones y Constructor
    private readonly DbContexto _dbContext;
    public CatalogoInsumoIcaDAO(DbContexto dbContexto)
    {
        _dbContext = dbContexto;
    }
    #endregion

    #region Obtener Todos
    public async Task<List<CatalogoInsumoIca>> ObtenerTodosAsync()
    {
        return await _dbContext.CatalogoInsumoIca.AsNoTracking().ToListAsync();
    }
    #endregion

    #region Obtener por Id
    public async Task<List<CatalogoInsumoIca>> ObtenerPorIdAsync(Guid id)
    {
        return await _dbContext.CatalogoInsumoIca.AsNoTracking()
            .Where(e => e.Id == id)
            .ToListAsync();
    }
    #endregion

    #region Crear
    public async Task CrearAsync(CatalogoInsumoIca entidad)
    {
        await _dbContext.CatalogoInsumoIca.AddAsync(entidad);
        await _dbContext.SaveChangesAsync();
    }
    #endregion

    #region Crear Varios
    public async Task CrearVariosAsync(IEnumerable<CatalogoInsumoIca> entidades)
    {
        await _dbContext.CatalogoInsumoIca.AddRangeAsync(entidades);
        await _dbContext.SaveChangesAsync();
    }
    #endregion

    #region Actualizar Varios
    public async Task ActualizarVariosAsync(IEnumerable<CatalogoInsumoIca> entidades)
    {
        _dbContext.CatalogoInsumoIca.UpdateRange(entidades);
        await _dbContext.SaveChangesAsync();
    }
    #endregion

    #region Eliminar Varios
    public async Task EliminarVariosAsync(IEnumerable<Guid> ids)
    {
        var entidades = await _dbContext.CatalogoInsumoIca
            .Where(e => ids.Contains(e.Id))
            .ToListAsync();
        _dbContext.CatalogoInsumoIca.RemoveRange(entidades);
        await _dbContext.SaveChangesAsync();
    }
    #endregion
}
