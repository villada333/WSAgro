using WSAgro.DTO.DTO;

namespace WSAgro.SERVICE.Interfaces;

public interface IEntregaEpp
{
    Task<SalidaDTO<List<EntregaEppDTO>>> ObtenerEntregaEppAsync();
    Task<SalidaDTO<List<EntregaEppDTO>>> ObtenerPorIdAsync(Guid id);
    Task<SalidaDTO<string>> CrearAsync(EntregaEppDTO dto);
    Task<SalidaDTO<string>> CrearVariosAsync(IEnumerable<EntregaEppDTO> dtos);
    Task<SalidaDTO<string>> ActualizarVariosAsync(IEnumerable<EntregaEppDTO> dtos);
    Task<SalidaDTO<string>> EliminarVariosAsync(IEnumerable<Guid> ids);
}
