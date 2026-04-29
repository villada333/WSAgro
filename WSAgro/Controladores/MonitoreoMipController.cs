using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WSAgro.DTO.DTO;
using WSAgro.SERVICE.Interfaces;

namespace WSAgro.Controladores;

[Route("/[controller]")]
[ApiController]
public class MonitoreoMipController : ControllerBase
{
    #region Inyecciones y Constructor
    private readonly IMonitoreoMip _service;
    public MonitoreoMipController(IMonitoreoMip service)
    {
        _service = service;
    }
    #endregion

    #region ObtenerMonitoreoMip
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<SalidaDTO<List<MonitoreoMipDTO>>>> ObtenerMonitoreoMipAsync()
    {
        SalidaDTO<List<MonitoreoMipDTO>> vo_Salida = new SalidaDTO<List<MonitoreoMipDTO>>();
        try
        {
            vo_Salida = await _service.ObtenerMonitoreoMipAsync();
            return vo_Salida;
        }
        catch (Exception)
        {
            vo_Salida.Mensaje = $"Ocurrio un error";
            vo_Salida.Codigo = 0;
            return vo_Salida;
        }
    }
    #endregion

    #region ObtenerPorId
    [HttpGet("{id}")]
    [Authorize]
    public async Task<ActionResult<SalidaDTO<List<MonitoreoMipDTO>>>> ObtenerPorIdAsync(Guid id)
    {
        SalidaDTO<List<MonitoreoMipDTO>> vo_Salida = new SalidaDTO<List<MonitoreoMipDTO>>();
        try
        {
            vo_Salida = await _service.ObtenerPorIdAsync(id);
            return vo_Salida;
        }
        catch (Exception)
        {
            vo_Salida.Mensaje = $"Ocurrio un error";
            vo_Salida.Codigo = 0;
            return vo_Salida;
        }
    }
    #endregion

    #region Crear
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<SalidaDTO<string>>> CrearAsync([FromBody] MonitoreoMipDTO dto)
    {
        SalidaDTO<string> vo_Salida = new SalidaDTO<string>();
        try
        {
            vo_Salida = await _service.CrearAsync(dto);
            return vo_Salida;
        }
        catch (Exception)
        {
            vo_Salida.Mensaje = $"Ocurrio un error";
            vo_Salida.Codigo = 0;
            return vo_Salida;
        }
    }
    #endregion

    #region CrearVarios
    [HttpPost("varios")]
    [Authorize]
    public async Task<ActionResult<SalidaDTO<string>>> CrearVariosAsync([FromBody] IEnumerable<MonitoreoMipDTO> dtos)
    {
        SalidaDTO<string> vo_Salida = new SalidaDTO<string>();
        try
        {
            vo_Salida = await _service.CrearVariosAsync(dtos);
            return vo_Salida;
        }
        catch (Exception)
        {
            vo_Salida.Mensaje = $"Ocurrio un error";
            vo_Salida.Codigo = 0;
            return vo_Salida;
        }
    }
    #endregion

    #region ActualizarVarios
    [HttpPut]
    [Authorize]
    public async Task<ActionResult<SalidaDTO<string>>> ActualizarVariosAsync([FromBody] IEnumerable<MonitoreoMipDTO> dtos)
    {
        SalidaDTO<string> vo_Salida = new SalidaDTO<string>();
        try
        {
            vo_Salida = await _service.ActualizarVariosAsync(dtos);
            return vo_Salida;
        }
        catch (Exception)
        {
            vo_Salida.Mensaje = $"Ocurrio un error";
            vo_Salida.Codigo = 0;
            return vo_Salida;
        }
    }
    #endregion

    #region EliminarVarios
    [HttpDelete]
    [Authorize]
    public async Task<ActionResult<SalidaDTO<string>>> EliminarVariosAsync([FromBody] IEnumerable<Guid> ids)
    {
        SalidaDTO<string> vo_Salida = new SalidaDTO<string>();
        try
        {
            vo_Salida = await _service.EliminarVariosAsync(ids);
            return vo_Salida;
        }
        catch (Exception)
        {
            vo_Salida.Mensaje = $"Ocurrio un error";
            vo_Salida.Codigo = 0;
            return vo_Salida;
        }
    }
    #endregion
}
