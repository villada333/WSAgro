using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WSAgro.DTO.DTO;
using WSAgro.SERVICE.Interfaces;

namespace WSAgro.Controladores;

[Route("/[controller]")]
[ApiController]
public class RemisionDespachoController : ControllerBase
{
    #region Inyecciones y Constructor
    private readonly IRemisionDespacho _service;
    public RemisionDespachoController(IRemisionDespacho service)
    {
        _service = service;
    }
    #endregion

    #region ObtenerRemisionDespacho
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<SalidaDTO<List<RemisionDespachoDTO>>>> ObtenerRemisionDespachoAsync()
    {
        SalidaDTO<List<RemisionDespachoDTO>> vo_Salida = new SalidaDTO<List<RemisionDespachoDTO>>();
        try
        {
            vo_Salida = await _service.ObtenerRemisionDespachoAsync();
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
    public async Task<ActionResult<SalidaDTO<List<RemisionDespachoDTO>>>> ObtenerPorIdAsync(Guid id)
    {
        SalidaDTO<List<RemisionDespachoDTO>> vo_Salida = new SalidaDTO<List<RemisionDespachoDTO>>();
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
    public async Task<ActionResult<SalidaDTO<string>>> CrearAsync([FromBody] RemisionDespachoDTO dto)
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
    public async Task<ActionResult<SalidaDTO<string>>> CrearVariosAsync([FromBody] IEnumerable<RemisionDespachoDTO> dtos)
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
    public async Task<ActionResult<SalidaDTO<string>>> ActualizarVariosAsync([FromBody] IEnumerable<RemisionDespachoDTO> dtos)
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
