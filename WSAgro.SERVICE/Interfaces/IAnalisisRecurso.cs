using WSAgro.DTO.DTO;

namespace WSAgro.SERVICE.Interfaces;

public interface IAnalisisRecurso
{
    Task<SalidaDTO<List<AnalisisRecursoDTO>>> ObtenerAnalisisRecursoAsync();
    Task<SalidaDTO<List<AnalisisRecursoDTO>>> ObtenerPorIdAsync(Guid id);
    Task<SalidaDTO<string>> CrearAsync(AnalisisRecursoDTO dto);
    Task<SalidaDTO<string>> CrearVariosAsync(IEnumerable<AnalisisRecursoDTO> dtos);
    Task<SalidaDTO<string>> ActualizarVariosAsync(IEnumerable<AnalisisRecursoDTO> dtos);
    Task<SalidaDTO<string>> EliminarVariosAsync(IEnumerable<Guid> ids);
}
