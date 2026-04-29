using WSAgro.DTO.DTO;

namespace WSAgro.SERVICE.Interfaces;

public interface IMaterialPropagacion
{
    Task<SalidaDTO<List<MaterialPropagacionDTO>>> ObtenerMaterialPropagacionAsync();
    Task<SalidaDTO<List<MaterialPropagacionDTO>>> ObtenerPorIdAsync(Guid id);
    Task<SalidaDTO<string>> CrearAsync(MaterialPropagacionDTO dto);
    Task<SalidaDTO<string>> CrearVariosAsync(IEnumerable<MaterialPropagacionDTO> dtos);
    Task<SalidaDTO<string>> ActualizarVariosAsync(IEnumerable<MaterialPropagacionDTO> dtos);
    Task<SalidaDTO<string>> EliminarVariosAsync(IEnumerable<Guid> ids);
}
