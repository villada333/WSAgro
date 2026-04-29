using WSAgro.DTO.DTO;

namespace WSAgro.SERVICE.Interfaces;

public interface IDetalleMonitoreoMip
{
    Task<SalidaDTO<List<DetalleMonitoreoMipDTO>>> ObtenerDetalleMonitoreoMipAsync();
    Task<SalidaDTO<List<DetalleMonitoreoMipDTO>>> ObtenerPorIdAsync(Guid id);
    Task<SalidaDTO<string>> CrearAsync(DetalleMonitoreoMipDTO dto);
    Task<SalidaDTO<string>> CrearVariosAsync(IEnumerable<DetalleMonitoreoMipDTO> dtos);
    Task<SalidaDTO<string>> ActualizarVariosAsync(IEnumerable<DetalleMonitoreoMipDTO> dtos);
    Task<SalidaDTO<string>> EliminarVariosAsync(IEnumerable<Guid> ids);
}
