using WSAgro.DTO.DTO;

namespace WSAgro.SERVICE.Interfaces;

public interface IInventarioBodega
{
    Task<SalidaDTO<List<InventarioBodegaDTO>>> ObtenerInventarioBodegaAsync();
    Task<SalidaDTO<List<InventarioBodegaDTO>>> ObtenerPorIdAsync(Guid id);
    Task<SalidaDTO<string>> CrearAsync(InventarioBodegaDTO dto);
    Task<SalidaDTO<string>> CrearVariosAsync(IEnumerable<InventarioBodegaDTO> dtos);
    Task<SalidaDTO<string>> ActualizarVariosAsync(IEnumerable<InventarioBodegaDTO> dtos);
    Task<SalidaDTO<string>> EliminarVariosAsync(IEnumerable<Guid> ids);
}
