using Microsoft.EntityFrameworkCore;
using WSAgro.DAO.Entidades;
using WSAgro.DAO.Interfaces;

namespace WSAgro.DAO.Implementaciones;

public class AsistenciaCapacitacionDAO : IAsistenciaCapacitacionDAO
{
    #region Inyecciones y Constructor
    private readonly DbContexto _dbContext;
    public AsistenciaCapacitacionDAO(DbContexto dbContexto)
    {
        _dbContext = dbContexto;
    }
    #endregion

    #region Obtener Todos
    public async Task<List<AsistenciaCapacitacion>> ObtenerTodosAsync()
    {
        return await _dbContext.AsistenciaCapacitacion.AsNoTracking().ToListAsync();
    }
    #endregion

    #region Obtener por Id
    public async Task<List<AsistenciaCapacitacion>> ObtenerPorIdAsync(Guid id)
    {
        return await _dbContext.AsistenciaCapacitacion.AsNoTracking()
            .Where(e => e.Id == id)
            .ToListAsync();
    }
    #endregion

    #region Crear
    public async Task CrearAsync(AsistenciaCapacitacion entidad)
    {
        await _dbContext.AsistenciaCapacitacion.AddAsync(entidad);
        await _dbContext.SaveChangesAsync();
    }
    #endregion

    #region Crear Varios
    public async Task CrearVariosAsync(IEnumerable<AsistenciaCapacitacion> entidades)
    {
        await _dbContext.AsistenciaCapacitacion.AddRangeAsync(entidades);
        await _dbContext.SaveChangesAsync();
    }
    #endregion

    #region Actualizar Varios
    public async Task ActualizarVariosAsync(IEnumerable<AsistenciaCapacitacion> entidades)
    {
        _dbContext.AsistenciaCapacitacion.UpdateRange(entidades);
        await _dbContext.SaveChangesAsync();
    }
    #endregion

    #region Eliminar Varios
    public async Task EliminarVariosAsync(IEnumerable<Guid> ids)
    {
        var entidades = await _dbContext.AsistenciaCapacitacion
            .Where(e => ids.Contains(e.Id))
            .ToListAsync();
        _dbContext.AsistenciaCapacitacion.RemoveRange(entidades);
        await _dbContext.SaveChangesAsync();
    }
    #endregion
}
