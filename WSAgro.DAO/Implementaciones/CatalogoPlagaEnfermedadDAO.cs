using Microsoft.EntityFrameworkCore;
using WSAgro.DAO.Entidades;
using WSAgro.DAO.Interfaces;

namespace WSAgro.DAO.Implementaciones;

public class CatalogoPlagaEnfermedadDAO : ICatalogoPlagaEnfermedadDAO
{
    #region Inyecciones y Constructor
    private readonly DbContexto _dbContext;
    public CatalogoPlagaEnfermedadDAO(DbContexto dbContexto)
    {
        _dbContext = dbContexto;
    }
    #endregion

    #region Obtener Todos
    public async Task<List<CatalogoPlagaEnfermedad>> ObtenerTodosAsync()
    {
        return await _dbContext.CatalogoPlagaEnfermedad.AsNoTracking().ToListAsync();
    }
    #endregion

    #region Obtener por Id
    public async Task<List<CatalogoPlagaEnfermedad>> ObtenerPorIdAsync(Guid id)
    {
        return await _dbContext.CatalogoPlagaEnfermedad.AsNoTracking()
            .Where(e => e.Id == id)
            .ToListAsync();
    }
    #endregion

    #region Crear
    public async Task CrearAsync(CatalogoPlagaEnfermedad entidad)
    {
        await _dbContext.CatalogoPlagaEnfermedad.AddAsync(entidad);
        await _dbContext.SaveChangesAsync();
    }
    #endregion

    #region Crear Varios
    public async Task CrearVariosAsync(IEnumerable<CatalogoPlagaEnfermedad> entidades)
    {
        await _dbContext.CatalogoPlagaEnfermedad.AddRangeAsync(entidades);
        await _dbContext.SaveChangesAsync();
    }
    #endregion

    #region Actualizar Varios
    public async Task ActualizarVariosAsync(IEnumerable<CatalogoPlagaEnfermedad> entidades)
    {
        _dbContext.CatalogoPlagaEnfermedad.UpdateRange(entidades);
        await _dbContext.SaveChangesAsync();
    }
    #endregion

    #region Eliminar Varios
    public async Task EliminarVariosAsync(IEnumerable<Guid> ids)
    {
        var entidades = await _dbContext.CatalogoPlagaEnfermedad
            .Where(e => ids.Contains(e.Id))
            .ToListAsync();
        _dbContext.CatalogoPlagaEnfermedad.RemoveRange(entidades);
        await _dbContext.SaveChangesAsync();
    }
    #endregion
}
