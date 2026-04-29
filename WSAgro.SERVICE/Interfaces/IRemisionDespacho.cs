using WSAgro.DTO.DTO;

namespace WSAgro.SERVICE.Interfaces;

public interface IRemisionDespacho
{
    Task<SalidaDTO<List<RemisionDespachoDTO>>> ObtenerRemisionDespachoAsync();
    Task<SalidaDTO<List<RemisionDespachoDTO>>> ObtenerPorIdAsync(Guid id);
    Task<SalidaDTO<string>> CrearAsync(RemisionDespachoDTO dto);
    Task<SalidaDTO<string>> CrearVariosAsync(IEnumerable<RemisionDespachoDTO> dtos);
    Task<SalidaDTO<string>> ActualizarVariosAsync(IEnumerable<RemisionDespachoDTO> dtos);
    Task<SalidaDTO<string>> EliminarVariosAsync(IEnumerable<Guid> ids);
}
