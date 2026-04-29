using WSAgro.DTO.DTO;

namespace WSAgro.SERVICE.Interfaces;

public interface IMonitoreoMip
{
    Task<SalidaDTO<List<MonitoreoMipDTO>>> ObtenerMonitoreoMipAsync();
    Task<SalidaDTO<List<MonitoreoMipDTO>>> ObtenerPorIdAsync(Guid id);
    Task<SalidaDTO<string>> CrearAsync(MonitoreoMipDTO dto);
    Task<SalidaDTO<string>> CrearVariosAsync(IEnumerable<MonitoreoMipDTO> dtos);
    Task<SalidaDTO<string>> ActualizarVariosAsync(IEnumerable<MonitoreoMipDTO> dtos);
    Task<SalidaDTO<string>> EliminarVariosAsync(IEnumerable<Guid> ids);
}
