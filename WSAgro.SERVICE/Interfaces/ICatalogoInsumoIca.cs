using WSAgro.DTO.DTO;

namespace WSAgro.SERVICE.Interfaces;

public interface ICatalogoInsumoIca
{
    Task<SalidaDTO<List<CatalogoInsumoIcaDTO>>> ObtenerCatalogoInsumoIcaAsync();
    Task<SalidaDTO<List<CatalogoInsumoIcaDTO>>> ObtenerPorIdAsync(Guid id);
    Task<SalidaDTO<string>> CrearAsync(CatalogoInsumoIcaDTO dto);
    Task<SalidaDTO<string>> CrearVariosAsync(IEnumerable<CatalogoInsumoIcaDTO> dtos);
    Task<SalidaDTO<string>> ActualizarVariosAsync(IEnumerable<CatalogoInsumoIcaDTO> dtos);
    Task<SalidaDTO<string>> EliminarVariosAsync(IEnumerable<Guid> ids);
}
