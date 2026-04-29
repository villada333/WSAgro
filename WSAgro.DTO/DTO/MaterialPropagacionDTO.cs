namespace WSAgro.DTO.DTO;

public class MaterialPropagacionDTO
{
    public Guid id { get; set; }

    public string? TenantId { get; set; }

    public Guid? LoteId { get; set; }

    public string? ProveedorVivero { get; set; }

    public string? RegistroIcaVivero { get; set; }

    public DateTime? FechaSiembra { get; set; }

    public string? Variedad { get; set; }

    public DateTime? CreatedAt { get; set; }

}
