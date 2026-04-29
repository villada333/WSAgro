using Microsoft.EntityFrameworkCore;
using WSAgro.DAO.Entidades;
using WSAgro.DAO.Interfaces;

namespace WSAgro.DAO.Implementaciones;

public class EntregaEppDAO : IEntregaEppDAO
{
    #region Inyecciones y Constructor
    private readonly DbContexto _dbContext;
    public EntregaEppDAO(DbContexto dbContexto)
    {
        _dbContext = dbContexto;
    }
    #endregion

    #region Obtener Todos
    public async Task<List<EntregaEpp>> ObtenerTodosAsync()
    {
        return await _dbContext.EntregaEpp.AsNoTracking().ToListAsync();
    }
    #endregion

    #region Obtener por Id
    public async Task<List<EntregaEpp>> ObtenerPorIdAsync(Guid id)
    {
        return await _dbContext.EntregaEpp.AsNoTracking()
            .Where(e => e.Id == id)
            .ToListAsync();
    }
    #endregion

    #region Crear
    public async Task CrearAsync(EntregaEpp entidad)
    {
        await _dbContext.EntregaEpp.AddAsync(entidad);
        await _dbContext.SaveChangesAsync();
    }
    #endregion

    #region Crear Varios
    public async Task CrearVariosAsync(IEnumerable<EntregaEpp> entidades)
    {
        await _dbContext.EntregaEpp.AddRangeAsync(entidades);
        await _dbContext.SaveChangesAsync();
    }
    #endregion

    #region Actualizar Varios
    public async Task ActualizarVariosAsync(IEnumerable<EntregaEpp> entidades)
    {
        _dbContext.EntregaEpp.UpdateRange(entidades);
        await _dbContext.SaveChangesAsync();
    }
    #endregion

    #region Eliminar Varios
    public async Task EliminarVariosAsync(IEnumerable<Guid> ids)
    {
        var entidades = await _dbContext.EntregaEpp
            .Where(e => ids.Contains(e.Id))
            .ToListAsync();
        _dbContext.EntregaEpp.RemoveRange(entidades);
        await _dbContext.SaveChangesAsync();
    }
    #endregion
}
