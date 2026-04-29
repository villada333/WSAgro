using WSAgro.DTO.DTO;

namespace WSAgro.SERVICE.Interfaces;

public interface IEquipoHerramienta
{
    Task<SalidaDTO<List<EquipoHerramientaDTO>>> ObtenerEquipoHerramientaAsync();
    Task<SalidaDTO<List<EquipoHerramientaDTO>>> ObtenerPorIdAsync(Guid id);
    Task<SalidaDTO<string>> CrearAsync(EquipoHerramientaDTO dto);
    Task<SalidaDTO<string>> CrearVariosAsync(IEnumerable<EquipoHerramientaDTO> dtos);
    Task<SalidaDTO<string>> ActualizarVariosAsync(IEnumerable<EquipoHerramientaDTO> dtos);
    Task<SalidaDTO<string>> EliminarVariosAsync(IEnumerable<Guid> ids);
}
