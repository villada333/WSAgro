using WSAgro.DTO.DTO;

namespace WSAgro.SERVICE.Interfaces;

public interface IUmbralAccionFinca
{
    Task<SalidaDTO<List<UmbralAccionFincaDTO>>> ObtenerUmbralAccionFincaAsync();
    Task<SalidaDTO<List<UmbralAccionFincaDTO>>> ObtenerPorIdAsync(Guid id);
    Task<SalidaDTO<string>> CrearAsync(UmbralAccionFincaDTO dto);
    Task<SalidaDTO<string>> CrearVariosAsync(IEnumerable<UmbralAccionFincaDTO> dtos);
    Task<SalidaDTO<string>> ActualizarVariosAsync(IEnumerable<UmbralAccionFincaDTO> dtos);
    Task<SalidaDTO<string>> EliminarVariosAsync(IEnumerable<Guid> ids);
}
