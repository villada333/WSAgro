using AutoMapper;
using WSAgro.DAO.Entidades;
using WSAgro.DAO.Interfaces;
using WSAgro.DTO.DTO;
using WSAgro.SERVICE.Interfaces;

namespace WSAgro.SERVICE.Implementaciones;

public class MaterialPropagacionImpl : IMaterialPropagacion
{
    #region Inyecciones y Constructor
    private readonly IMaterialPropagacionDAO _dao;
    private readonly IMapper _mapper;

    public MaterialPropagacionImpl(IMaterialPropagacionDAO dao, IMapper mapper)
    {
        _dao = dao;
        _mapper = mapper;
    }
    #endregion

    #region ObtenerMaterialPropagacion
    public async Task<SalidaDTO<List<MaterialPropagacionDTO>>> ObtenerMaterialPropagacionAsync()
    {
        SalidaDTO<List<MaterialPropagacionDTO>> vo_Salida = new();
        try
        {
            var vo_Lista = await _dao.ObtenerTodosAsync();
            vo_Salida.Data = _mapper.Map<List<MaterialPropagacionDTO>>(vo_Lista);
            vo_Salida.Codigo = 1;
        }
        catch (Exception ex)
        {
            vo_Salida.Codigo = 0;
            vo_Salida.Mensaje = ex.Message;
        }
        return vo_Salida;
    }
    #endregion

    #region ObtenerPorId
    public async Task<SalidaDTO<List<MaterialPropagacionDTO>>> ObtenerPorIdAsync(Guid id)
    {
        SalidaDTO<List<MaterialPropagacionDTO>> vo_Salida = new();
        try
        {
            var vo_Lista = await _dao.ObtenerPorIdAsync(id);
            vo_Salida.Data = _mapper.Map<List<MaterialPropagacionDTO>>(vo_Lista);
            vo_Salida.Codigo = 1;
        }
        catch (Exception ex)
        {
            vo_Salida.Codigo = 0;
            vo_Salida.Mensaje = ex.Message;
        }
        return vo_Salida;
    }
    #endregion

    #region Crear
    public async Task<SalidaDTO<string>> CrearAsync(MaterialPropagacionDTO dto)
    {
        SalidaDTO<string> vo_Salida = new();
        try
        {
            var vo_Entidad = _mapper.Map<MaterialPropagacion>(dto);
            await _dao.CrearAsync(vo_Entidad);
            vo_Salida.Codigo = 1;
        }
        catch (Exception ex)
        {
            vo_Salida.Codigo = 0;
            vo_Salida.Mensaje = ex.Message;
        }
        return vo_Salida;
    }
    #endregion

    #region CrearVarios
    public async Task<SalidaDTO<string>> CrearVariosAsync(IEnumerable<MaterialPropagacionDTO> dtos)
    {
        SalidaDTO<string> vo_Salida = new();
        try
        {
            var vo_Entidades = _mapper.Map<IEnumerable<MaterialPropagacion>>(dtos);
            await _dao.CrearVariosAsync(vo_Entidades);
            vo_Salida.Codigo = 1;
        }
        catch (Exception ex)
        {
            vo_Salida.Codigo = 0;
            vo_Salida.Mensaje = ex.Message;
        }
        return vo_Salida;
    }
    #endregion

    #region ActualizarVarios
    public async Task<SalidaDTO<string>> ActualizarVariosAsync(IEnumerable<MaterialPropagacionDTO> dtos)
    {
        SalidaDTO<string> vo_Salida = new();
        try
        {
            var vo_Entidades = _mapper.Map<IEnumerable<MaterialPropagacion>>(dtos);
            await _dao.ActualizarVariosAsync(vo_Entidades);
            vo_Salida.Codigo = 1;
        }
        catch (Exception ex)
        {
            vo_Salida.Codigo = 0;
            vo_Salida.Mensaje = ex.Message;
        }
        return vo_Salida;
    }
    #endregion

    #region EliminarVarios
    public async Task<SalidaDTO<string>> EliminarVariosAsync(IEnumerable<Guid> ids)
    {
        SalidaDTO<string> vo_Salida = new();
        try
        {
            await _dao.EliminarVariosAsync(ids);
            vo_Salida.Codigo = 1;
        }
        catch (Exception ex)
        {
            vo_Salida.Codigo = 0;
            vo_Salida.Mensaje = ex.Message;
        }
        return vo_Salida;
    }
    #endregion
}
