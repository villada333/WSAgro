using WSAgro.DTO.DTO;

namespace WSAgro.SERVICE.Interfaces;

public interface IDetalleRemision
{
    Task<SalidaDTO<List<DetalleRemisionDTO>>> ObtenerDetalleRemisionAsync();
    Task<SalidaDTO<List<DetalleRemisionDTO>>> ObtenerPorIdAsync(Guid id);
    Task<SalidaDTO<string>> CrearAsync(DetalleRemisionDTO dto);
    Task<SalidaDTO<string>> CrearVariosAsync(IEnumerable<DetalleRemisionDTO> dtos);
    Task<SalidaDTO<string>> ActualizarVariosAsync(IEnumerable<DetalleRemisionDTO> dtos);
    Task<SalidaDTO<string>> EliminarVariosAsync(IEnumerable<Guid> ids);
}
