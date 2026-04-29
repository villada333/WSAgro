using WSAgro.DTO.DTO;

namespace WSAgro.SERVICE.Interfaces;

public interface IAsistenciaCapacitacion
{
    Task<SalidaDTO<List<AsistenciaCapacitacionDTO>>> ObtenerAsistenciaCapacitacionAsync();
    Task<SalidaDTO<List<AsistenciaCapacitacionDTO>>> ObtenerPorIdAsync(Guid id);
    Task<SalidaDTO<string>> CrearAsync(AsistenciaCapacitacionDTO dto);
    Task<SalidaDTO<string>> CrearVariosAsync(IEnumerable<AsistenciaCapacitacionDTO> dtos);
    Task<SalidaDTO<string>> ActualizarVariosAsync(IEnumerable<AsistenciaCapacitacionDTO> dtos);
    Task<SalidaDTO<string>> EliminarVariosAsync(IEnumerable<Guid> ids);
}
