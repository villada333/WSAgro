using Microsoft.EntityFrameworkCore;
using WSAgro.DAO.Entidades;
using WSAgro.DAO.Interfaces;

namespace WSAgro.DAO.Implementaciones;

public class DetalleRemisionDAO : IDetalleRemisionDAO
{
    #region Inyecciones y Constructor
    private readonly DbContexto _dbContext;
    public DetalleRemisionDAO(DbContexto dbContexto)
    {
        _dbContext = dbContexto;
    }
    #endregion

    #region Obtener Todos
    public async Task<List<DetalleRemision>> ObtenerTodosAsync()
    {
        return await _dbContext.DetalleRemision.AsNoTracking().ToListAsync();
    }
    #endregion

    #region Obtener por Id
    public async Task<List<DetalleRemision>> ObtenerPorIdAsync(Guid id)
    {
        return await _dbContext.DetalleRemision.AsNoTracking()
            .Where(e => e.Id == id)
            .ToListAsync();
    }
    #endregion

    #region Crear
    public async Task CrearAsync(DetalleRemision entidad)
    {
        await _dbContext.DetalleRemision.AddAsync(entidad);
        await _dbContext.SaveChangesAsync();
    }
    #endregion

    #region Crear Varios
    public async Task CrearVariosAsync(IEnumerable<DetalleRemision> entidades)
    {
        await _dbContext.DetalleRemision.AddRangeAsync(entidades);
        await _dbContext.SaveChangesAsync();
    }
    #endregion

    #region Actualizar Varios
    public async Task ActualizarVariosAsync(IEnumerable<DetalleRemision> entidades)
    {
        _dbContext.DetalleRemision.UpdateRange(entidades);
        await _dbContext.SaveChangesAsync();
    }
    #endregion

    #region Eliminar Varios
    public async Task EliminarVariosAsync(IEnumerable<Guid> ids)
    {
        var entidades = await _dbContext.DetalleRemision
            .Where(e => ids.Contains(e.Id))
            .ToListAsync();
        _dbContext.DetalleRemision.RemoveRange(entidades);
        await _dbContext.SaveChangesAsync();
    }
    #endregion
}
