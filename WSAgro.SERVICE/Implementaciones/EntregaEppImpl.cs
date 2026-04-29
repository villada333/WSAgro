using AutoMapper;
using WSAgro.DAO.Entidades;
using WSAgro.DAO.Interfaces;
using WSAgro.DTO.DTO;
using WSAgro.SERVICE.Interfaces;

namespace WSAgro.SERVICE.Implementaciones;

public class EntregaEppImpl : IEntregaEpp
{
    #region Inyecciones y Constructor
    private readonly IEntregaEppDAO _dao;
    private readonly IMapper _mapper;

    public EntregaEppImpl(IEntregaEppDAO dao, IMapper mapper)
    {
        _dao = dao;
        _mapper = mapper;
    }
    #endregion

    #region ObtenerEntregaEpp
    public async Task<SalidaDTO<List<EntregaEppDTO>>> ObtenerEntregaEppAsync()
    {
        SalidaDTO<List<EntregaEppDTO>> vo_Salida = new();
        try
        {
            var vo_Lista = await _dao.ObtenerTodosAsync();
            vo_Salida.Data = _mapper.Map<List<EntregaEppDTO>>(vo_Lista);
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
    public async Task<SalidaDTO<List<EntregaEppDTO>>> ObtenerPorIdAsync(Guid id)
    {
        SalidaDTO<List<EntregaEppDTO>> vo_Salida = new();
        try
        {
            var vo_Lista = await _dao.ObtenerPorIdAsync(id);
            vo_Salida.Data = _mapper.Map<List<EntregaEppDTO>>(vo_Lista);
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
    public async Task<SalidaDTO<string>> CrearAsync(EntregaEppDTO dto)
    {
        SalidaDTO<string> vo_Salida = new();
        try
        {
            var vo_Entidad = _mapper.Map<EntregaEpp>(dto);
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
    public async Task<SalidaDTO<string>> CrearVariosAsync(IEnumerable<EntregaEppDTO> dtos)
    {
        SalidaDTO<string> vo_Salida = new();
        try
        {
            var vo_Entidades = _mapper.Map<IEnumerable<EntregaEpp>>(dtos);
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
    public async Task<SalidaDTO<string>> ActualizarVariosAsync(IEnumerable<EntregaEppDTO> dtos)
    {
        SalidaDTO<string> vo_Salida = new();
        try
        {
            var vo_Entidades = _mapper.Map<IEnumerable<EntregaEpp>>(dtos);
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
