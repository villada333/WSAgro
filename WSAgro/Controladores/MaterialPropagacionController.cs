using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WSAgro.DTO.DTO;
using WSAgro.SERVICE.Interfaces;

namespace WSAgro.Controladores;

[Route("/[controller]")]
[ApiController]
public class MaterialPropagacionController : ControllerBase
{
    #region Inyecciones y Constructor
    private readonly IMaterialPropagacion _service;
    public MaterialPropagacionController(IMaterialPropagacion service)
    {
        _service = service;
    }
    #endregion

    #region ObtenerMaterialPropagacion
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<SalidaDTO<List<MaterialPropagacionDTO>>>> ObtenerMaterialPropagacionAsync()
    {
        SalidaDTO<List<MaterialPropagacionDTO>> vo_Salida = new SalidaDTO<List<MaterialPropagacionDTO>>();
        try
        {
            vo_Salida = await _service.ObtenerMaterialPropagacionAsync();
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
    public async Task<ActionResult<SalidaDTO<List<MaterialPropagacionDTO>>>> ObtenerPorIdAsync(Guid id)
    {
        SalidaDTO<List<MaterialPropagacionDTO>> vo_Salida = new SalidaDTO<List<MaterialPropagacionDTO>>();
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
    public async Task<ActionResult<SalidaDTO<string>>> CrearAsync([FromBody] MaterialPropagacionDTO dto)
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
    public async Task<ActionResult<SalidaDTO<string>>> CrearVariosAsync([FromBody] IEnumerable<MaterialPropagacionDTO> dtos)
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
    public async Task<ActionResult<SalidaDTO<string>>> ActualizarVariosAsync([FromBody] IEnumerable<MaterialPropagacionDTO> dtos)
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
