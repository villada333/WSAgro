using Microsoft.EntityFrameworkCore;
using WSAgro.DAO.Entidades;
using WSAgro.DAO.Interfaces;

namespace WSAgro.DAO.Implementaciones;

public class EquipoHerramientaDAO : IEquipoHerramientaDAO
{
    #region Inyecciones y Constructor
    private readonly DbContexto _dbContext;
    public EquipoHerramientaDAO(DbContexto dbContexto)
    {
        _dbContext = dbContexto;
    }
    #endregion

    #region Obtener Todos
    public async Task<List<EquipoHerramienta>> ObtenerTodosAsync()
    {
        return await _dbContext.EquipoHerramienta.AsNoTracking().ToListAsync();
    }
    #endregion

    #region Obtener por Id
    public async Task<List<EquipoHerramienta>> ObtenerPorIdAsync(Guid id)
    {
        return await _dbContext.EquipoHerramienta.AsNoTracking()
            .Where(e => e.Id == id)
            .ToListAsync();
    }
    #endregion

    #region Crear
    public async Task CrearAsync(EquipoHerramienta entidad)
    {
        await _dbContext.EquipoHerramienta.AddAsync(entidad);
        await _dbContext.SaveChangesAsync();
    }
    #endregion

    #region Crear Varios
    public async Task CrearVariosAsync(IEnumerable<EquipoHerramienta> entidades)
    {
        await _dbContext.EquipoHerramienta.AddRangeAsync(entidades);
        await _dbContext.SaveChangesAsync();
    }
    #endregion

    #region Actualizar Varios
    public async Task ActualizarVariosAsync(IEnumerable<EquipoHerramienta> entidades)
    {
        _dbContext.EquipoHerramienta.UpdateRange(entidades);
        await _dbContext.SaveChangesAsync();
    }
    #endregion

    #region Eliminar Varios
    public async Task EliminarVariosAsync(IEnumerable<Guid> ids)
    {
        var entidades = await _dbContext.EquipoHerramienta
            .Where(e => ids.Contains(e.Id))
            .ToListAsync();
        _dbContext.EquipoHerramienta.RemoveRange(entidades);
        await _dbContext.SaveChangesAsync();
    }
    #endregion
}
