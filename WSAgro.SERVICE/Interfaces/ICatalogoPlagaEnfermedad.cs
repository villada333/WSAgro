using WSAgro.DTO.DTO;

namespace WSAgro.SERVICE.Interfaces;

public interface ICatalogoPlagaEnfermedad
{
    Task<SalidaDTO<List<CatalogoPlagaEnfermedadDTO>>> ObtenerCatalogoPlagaEnfermedadAsync();
    Task<SalidaDTO<List<CatalogoPlagaEnfermedadDTO>>> ObtenerPorIdAsync(Guid id);
    Task<SalidaDTO<string>> CrearAsync(CatalogoPlagaEnfermedadDTO dto);
    Task<SalidaDTO<string>> CrearVariosAsync(IEnumerable<CatalogoPlagaEnfermedadDTO> dtos);
    Task<SalidaDTO<string>> ActualizarVariosAsync(IEnumerable<CatalogoPlagaEnfermedadDTO> dtos);
    Task<SalidaDTO<string>> EliminarVariosAsync(IEnumerable<Guid> ids);
}
