using Microsoft.EntityFrameworkCore;
using WSAgro.DAO.Entidades;
using WSAgro.DAO.Interfaces;

namespace WSAgro.DAO.Implementaciones;

public class MantenimientoCalibracionDAO : IMantenimientoCalibracionDAO
{
    #region Inyecciones y Constructor
    private readonly DbContexto _dbContext;
    public MantenimientoCalibracionDAO(DbContexto dbContexto)
    {
        _dbContext = dbContexto;
    }
    #endregion

    #region Obtener Todos
    public async Task<List<MantenimientoCalibracion>> ObtenerTodosAsync()
    {
        return await _dbContext.MantenimientoCalibracion.AsNoTracking().ToListAsync();
    }
    #endregion

    #region Obtener por Id
    public async Task<List<MantenimientoCalibracion>> ObtenerPorIdAsync(Guid id)
    {
        return await _dbContext.MantenimientoCalibracion.AsNoTracking()
            .Where(e => e.Id == id)
            .ToListAsync();
    }
    #endregion

    #region Crear
    public async Task CrearAsync(MantenimientoCalibracion entidad)
    {
        await _dbContext.MantenimientoCalibracion.AddAsync(entidad);
        await _dbContext.SaveChangesAsync();
    }
    #endregion

    #region Crear Varios
    public async Task CrearVariosAsync(IEnumerable<MantenimientoCalibracion> entidades)
    {
        await _dbContext.MantenimientoCalibracion.AddRangeAsync(entidades);
        await _dbContext.SaveChangesAsync();
    }
    #endregion

    #region Actualizar Varios
    public async Task ActualizarVariosAsync(IEnumerable<MantenimientoCalibracion> entidades)
    {
        _dbContext.MantenimientoCalibracion.UpdateRange(entidades);
        await _dbContext.SaveChangesAsync();
    }
    #endregion

    #region Eliminar Varios
    public async Task EliminarVariosAsync(IEnumerable<Guid> ids)
    {
        var entidades = await _dbContext.MantenimientoCalibracion
            .Where(e => ids.Contains(e.Id))
            .ToListAsync();
        _dbContext.MantenimientoCalibracion.RemoveRange(entidades);
        await _dbContext.SaveChangesAsync();
    }
    #endregion
}
