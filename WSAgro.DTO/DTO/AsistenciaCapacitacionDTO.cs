namespace WSAgro.DTO.DTO;

public class AsistenciaCapacitacionDTO
{
    public Guid id { get; set; }

    public string? TenantId { get; set; }

    public Guid? CapacitacionId { get; set; }

    public Guid? UsuarioId { get; set; }

    public string? FirmaBase64 { get; set; }

    public DateTime? CreatedAt { get; set; }

}
