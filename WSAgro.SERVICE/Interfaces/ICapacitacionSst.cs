using WSAgro.DTO.DTO;

namespace WSAgro.SERVICE.Interfaces;

public interface ICapacitacionSst
{
    Task<SalidaDTO<List<CapacitacionSstDTO>>> ObtenerCapacitacionSstAsync();
    Task<SalidaDTO<List<CapacitacionSstDTO>>> ObtenerPorIdAsync(Guid id);
    Task<SalidaDTO<string>> CrearAsync(CapacitacionSstDTO dto);
    Task<SalidaDTO<string>> CrearVariosAsync(IEnumerable<CapacitacionSstDTO> dtos);
    Task<SalidaDTO<string>> ActualizarVariosAsync(IEnumerable<CapacitacionSstDTO> dtos);
    Task<SalidaDTO<string>> EliminarVariosAsync(IEnumerable<Guid> ids);
}
