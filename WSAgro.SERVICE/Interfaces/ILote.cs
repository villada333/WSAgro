using WSAgro.DTO.DTO;

namespace WSAgro.SERVICE.Interfaces;

public interface ILote
{
    Task<SalidaDTO<List<LoteDTO>>> ObtenerLoteAsync();
    Task<SalidaDTO<List<LoteDTO>>> ObtenerPorIdAsync(Guid id);
    Task<SalidaDTO<string>> CrearAsync(LoteDTO dto);
    Task<SalidaDTO<string>> CrearVariosAsync(IEnumerable<LoteDTO> dtos);
    Task<SalidaDTO<string>> ActualizarVariosAsync(IEnumerable<LoteDTO> dtos);
    Task<SalidaDTO<string>> EliminarVariosAsync(IEnumerable<Guid> ids);
}
