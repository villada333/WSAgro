using Microsoft.EntityFrameworkCore;
using WSAgro.DAO.Entidades;
using WSAgro.DAO.Interfaces;

namespace WSAgro.DAO.Implementaciones;

public class UmbralAccionFincaDAO : IUmbralAccionFincaDAO
{
    #region Inyecciones y Constructor
    private readonly DbContexto _dbContext;
    public UmbralAccionFincaDAO(DbContexto dbContexto)
    {
        _dbContext = dbContexto;
    }
    #endregion

    #region Obtener Todos
    public async Task<List<UmbralAccionFinca>> ObtenerTodosAsync()
    {
        return await _dbContext.UmbralAccionFinca.AsNoTracking().ToListAsync();
    }
    #endregion

    #region Obtener por Id
    public async Task<List<UmbralAccionFinca>> ObtenerPorIdAsync(Guid id)
    {
        return await _dbContext.UmbralAccionFinca.AsNoTracking()
            .Where(e => e.Id == id)
            .ToListAsync();
    }
    #endregion

    #region Crear
    public async Task CrearAsync(UmbralAccionFinca entidad)
    {
        await _dbContext.UmbralAccionFinca.AddAsync(entidad);
        await _dbContext.SaveChangesAsync();
    }
    #endregion

    #region Crear Varios
    public async Task CrearVariosAsync(IEnumerable<UmbralAccionFinca> entidades)
    {
        await _dbContext.UmbralAccionFinca.AddRangeAsync(entidades);
        await _dbContext.SaveChangesAsync();
    }
    #endregion

    #region Actualizar Varios
    public async Task ActualizarVariosAsync(IEnumerable<UmbralAccionFinca> entidades)
    {
        _dbContext.UmbralAccionFinca.UpdateRange(entidades);
        await _dbContext.SaveChangesAsync();
    }
    #endregion

    #region Eliminar Varios
    public async Task EliminarVariosAsync(IEnumerable<Guid> ids)
    {
        var entidades = await _dbContext.UmbralAccionFinca
            .Where(e => ids.Contains(e.Id))
            .ToListAsync();
        _dbContext.UmbralAccionFinca.RemoveRange(entidades);
        await _dbContext.SaveChangesAsync();
    }
    #endregion
}
