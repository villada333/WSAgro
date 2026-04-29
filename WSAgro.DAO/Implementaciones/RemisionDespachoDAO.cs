using Microsoft.EntityFrameworkCore;
using WSAgro.DAO.Entidades;
using WSAgro.DAO.Interfaces;

namespace WSAgro.DAO.Implementaciones;

public class RemisionDespachoDAO : IRemisionDespachoDAO
{
    #region Inyecciones y Constructor
    private readonly DbContexto _dbContext;
    public RemisionDespachoDAO(DbContexto dbContexto)
    {
        _dbContext = dbContexto;
    }
    #endregion

    #region Obtener Todos
    public async Task<List<RemisionDespacho>> ObtenerTodosAsync()
    {
        return await _dbContext.RemisionDespacho.AsNoTracking().ToListAsync();
    }
    #endregion

    #region Obtener por Id
    public async Task<List<RemisionDespacho>> ObtenerPorIdAsync(Guid id)
    {
        return await _dbContext.RemisionDespacho.AsNoTracking()
            .Where(e => e.Id == id)
            .ToListAsync();
    }
    #endregion

    #region Crear
    public async Task CrearAsync(RemisionDespacho entidad)
    {
        await _dbContext.RemisionDespacho.AddAsync(entidad);
        await _dbContext.SaveChangesAsync();
    }
    #endregion

    #region Crear Varios
    public async Task CrearVariosAsync(IEnumerable<RemisionDespacho> entidades)
    {
        await _dbContext.RemisionDespacho.AddRangeAsync(entidades);
        await _dbContext.SaveChangesAsync();
    }
    #endregion

    #region Actualizar Varios
    public async Task ActualizarVariosAsync(IEnumerable<RemisionDespacho> entidades)
    {
        _dbContext.RemisionDespacho.UpdateRange(entidades);
        await _dbContext.SaveChangesAsync();
    }
    #endregion

    #region Eliminar Varios
    public async Task EliminarVariosAsync(IEnumerable<Guid> ids)
    {
        var entidades = await _dbContext.RemisionDespacho
            .Where(e => ids.Contains(e.Id))
            .ToListAsync();
        _dbContext.RemisionDespacho.RemoveRange(entidades);
        await _dbContext.SaveChangesAsync();
    }
    #endregion
}
