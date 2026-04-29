using WSAgro.DTO.DTO;

namespace WSAgro.SERVICE.Interfaces;

public interface IMantenimientoCalibracion
{
    Task<SalidaDTO<List<MantenimientoCalibracionDTO>>> ObtenerMantenimientoCalibracionAsync();
    Task<SalidaDTO<List<MantenimientoCalibracionDTO>>> ObtenerPorIdAsync(Guid id);
    Task<SalidaDTO<string>> CrearAsync(MantenimientoCalibracionDTO dto);
    Task<SalidaDTO<string>> CrearVariosAsync(IEnumerable<MantenimientoCalibracionDTO> dtos);
    Task<SalidaDTO<string>> ActualizarVariosAsync(IEnumerable<MantenimientoCalibracionDTO> dtos);
    Task<SalidaDTO<string>> EliminarVariosAsync(IEnumerable<Guid> ids);
}
