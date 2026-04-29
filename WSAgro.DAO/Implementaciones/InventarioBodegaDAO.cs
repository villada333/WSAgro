using Microsoft.EntityFrameworkCore;
using WSAgro.DAO.Entidades;
using WSAgro.DAO.Interfaces;

namespace WSAgro.DAO.Implementaciones;

public class InventarioBodegaDAO : IInventarioBodegaDAO
{
    #region Inyecciones y Constructor
    private readonly DbContexto _dbContext;
    public InventarioBodegaDAO(DbContexto dbContexto)
    {
        _dbContext = dbContexto;
    }
    #endregion

    #region Obtener Todos
    public async Task<List<InventarioBodega>> ObtenerTodosAsync()
    {
        return await _dbContext.InventarioBodega.AsNoTracking().ToListAsync();
    }
    #endregion

    #region Obtener por Id
    public async Task<List<InventarioBodega>> ObtenerPorIdAsync(Guid id)
    {
        return await _dbContext.InventarioBodega.AsNoTracking()
            .Where(e => e.Id == id)
            .ToListAsync();
    }
    #endregion

    #region Crear
    public async Task CrearAsync(InventarioBodega entidad)
    {
        await _dbContext.InventarioBodega.AddAsync(entidad);
        await _dbContext.SaveChangesAsync();
    }
    #endregion

    #region Crear Varios
    public async Task CrearVariosAsync(IEnumerable<InventarioBodega> entidades)
    {
        await _dbContext.InventarioBodega.AddRangeAsync(entidades);
        await _dbContext.SaveChangesAsync();
    }
    #endregion

    #region Actualizar Varios
    public async Task ActualizarVariosAsync(IEnumerable<InventarioBodega> entidades)
    {
        _dbContext.InventarioBodega.UpdateRange(entidades);
        await _dbContext.SaveChangesAsync();
    }
    #endregion

    #region Eliminar Varios
    public async Task EliminarVariosAsync(IEnumerable<Guid> ids)
    {
        var entidades = await _dbContext.InventarioBodega
            .Where(e => ids.Contains(e.Id))
            .ToListAsync();
        _dbContext.InventarioBodega.RemoveRange(entidades);
        await _dbContext.SaveChangesAsync();
    }
    #endregion
}
