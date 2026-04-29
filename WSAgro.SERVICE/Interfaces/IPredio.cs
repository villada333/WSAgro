using WSAgro.DTO.DTO;

namespace WSAgro.SERVICE.Interfaces;

public interface IPredio
{
    Task<SalidaDTO<List<PredioDTO>>> ObtenerPredioAsync();
    Task<SalidaDTO<List<PredioDTO>>> ObtenerPorIdAsync(Guid id);
    Task<SalidaDTO<string>> CrearAsync(PredioDTO dto);
    Task<SalidaDTO<string>> CrearVariosAsync(IEnumerable<PredioDTO> dtos);
    Task<SalidaDTO<string>> ActualizarVariosAsync(IEnumerable<PredioDTO> dtos);
    Task<SalidaDTO<string>> EliminarVariosAsync(IEnumerable<Guid> ids);
}
