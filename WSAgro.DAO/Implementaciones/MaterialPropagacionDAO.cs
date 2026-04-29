using Microsoft.EntityFrameworkCore;
using WSAgro.DAO.Entidades;
using WSAgro.DAO.Interfaces;

namespace WSAgro.DAO.Implementaciones;

public class MaterialPropagacionDAO : IMaterialPropagacionDAO
{
    #region Inyecciones y Constructor
    private readonly DbContexto _dbContext;
    public MaterialPropagacionDAO(DbContexto dbContexto)
    {
        _dbContext = dbContexto;
    }
    #endregion

    #region Obtener Todos
    public async Task<List<MaterialPropagacion>> ObtenerTodosAsync()
    {
        return await _dbContext.MaterialPropagacion.AsNoTracking().ToListAsync();
    }
    #endregion

    #region Obtener por Id
    public async Task<List<MaterialPropagacion>> ObtenerPorIdAsync(Guid id)
    {
        return await _dbContext.MaterialPropagacion.AsNoTracking()
            .Where(e => e.Id == id)
            .ToListAsync();
    }
    #endregion

    #region Crear
    public async Task CrearAsync(MaterialPropagacion entidad)
    {
        await _dbContext.MaterialPropagacion.AddAsync(entidad);
        await _dbContext.SaveChangesAsync();
    }
    #endregion

    #region Crear Varios
    public async Task CrearVariosAsync(IEnumerable<MaterialPropagacion> entidades)
    {
        await _dbContext.MaterialPropagacion.AddRangeAsync(entidades);
        await _dbContext.SaveChangesAsync();
    }
    #endregion

    #region Actualizar Varios
    public async Task ActualizarVariosAsync(IEnumerable<MaterialPropagacion> entidades)
    {
        _dbContext.MaterialPropagacion.UpdateRange(entidades);
        await _dbContext.SaveChangesAsync();
    }
    #endregion

    #region Eliminar Varios
    public async Task EliminarVariosAsync(IEnumerable<Guid> ids)
    {
        var entidades = await _dbContext.MaterialPropagacion
            .Where(e => ids.Contains(e.Id))
            .ToListAsync();
        _dbContext.MaterialPropagacion.RemoveRange(entidades);
        await _dbContext.SaveChangesAsync();
    }
    #endregion
}
