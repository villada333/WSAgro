using WSAgro.DTO.DTO;

namespace WSAgro.SERVICE.Interfaces;

public interface ILaborTransaccional
{
    Task<SalidaDTO<List<LaborTransaccionalDTO>>> ObtenerLaborTransaccionalAsync();
    Task<SalidaDTO<List<LaborTransaccionalDTO>>> ObtenerPorIdAsync(Guid id);
    Task<SalidaDTO<string>> CrearAsync(LaborTransaccionalDTO dto);
    Task<SalidaDTO<string>> CrearVariosAsync(IEnumerable<LaborTransaccionalDTO> dtos);
    Task<SalidaDTO<string>> ActualizarVariosAsync(IEnumerable<LaborTransaccionalDTO> dtos);
    Task<SalidaDTO<string>> EliminarVariosAsync(IEnumerable<Guid> ids);
}
