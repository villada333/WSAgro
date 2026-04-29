using WSAgro.DTO.DTO;

namespace WSAgro.SERVICE.Interfaces;

public interface IRegistroCosecha
{
    Task<SalidaDTO<List<RegistroCosechaDTO>>> ObtenerRegistroCosechaAsync();
    Task<SalidaDTO<List<RegistroCosechaDTO>>> ObtenerPorIdAsync(Guid id);
    Task<SalidaDTO<string>> CrearAsync(RegistroCosechaDTO dto);
    Task<SalidaDTO<string>> CrearVariosAsync(IEnumerable<RegistroCosechaDTO> dtos);
    Task<SalidaDTO<string>> ActualizarVariosAsync(IEnumerable<RegistroCosechaDTO> dtos);
    Task<SalidaDTO<string>> EliminarVariosAsync(IEnumerable<Guid> ids);
}
