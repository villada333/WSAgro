using Microsoft.EntityFrameworkCore;
using WSAgro.DAO.Entidades;
using WSAgro.DAO.Interfaces;

namespace WSAgro.DAO.Implementaciones;

public class AnalisisRecursoDAO : IAnalisisRecursoDAO
{
    #region Inyecciones y Constructor
    private readonly DbContexto _dbContext;
    public AnalisisRecursoDAO(DbContexto dbContexto)
    {
        _dbContext = dbContexto;
    }
    #endregion

    #region Obtener Todos
    public async Task<List<AnalisisRecurso>> ObtenerTodosAsync()
    {
        return await _dbContext.AnalisisRecurso.AsNoTracking().ToListAsync();
    }
    #endregion

    #region Obtener por Id
    public async Task<List<AnalisisRecurso>> ObtenerPorIdAsync(Guid id)
    {
        return await _dbContext.AnalisisRecurso.AsNoTracking()
            .Where(e => e.Id == id)
            .ToListAsync();
    }
    #endregion

    #region Crear
    public async Task CrearAsync(AnalisisRecurso entidad)
    {
        await _dbContext.AnalisisRecurso.AddAsync(entidad);
        await _dbContext.SaveChangesAsync();
    }
    #endregion

    #region Crear Varios
    public async Task CrearVariosAsync(IEnumerable<AnalisisRecurso> entidades)
    {
        await _dbContext.AnalisisRecurso.AddRangeAsync(entidades);
        await _dbContext.SaveChangesAsync();
    }
    #endregion

    #region Actualizar Varios
    public async Task ActualizarVariosAsync(IEnumerable<AnalisisRecurso> entidades)
    {
        _dbContext.AnalisisRecurso.UpdateRange(entidades);
        await _dbContext.SaveChangesAsync();
    }
    #endregion

    #region Eliminar Varios
    public async Task EliminarVariosAsync(IEnumerable<Guid> ids)
    {
        var entidades = await _dbContext.AnalisisRecurso
            .Where(e => ids.Contains(e.Id))
            .ToListAsync();
        _dbContext.AnalisisRecurso.RemoveRange(entidades);
        await _dbContext.SaveChangesAsync();
    }
    #endregion
}
