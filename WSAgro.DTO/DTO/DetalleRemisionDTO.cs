namespace WSAgro.DTO.DTO;

public class DetalleRemisionDTO
{
    public Guid id { get; set; }

    public string? TenantId { get; set; }

    public Guid? RemisionId { get; set; }

    public Guid? CosechaId { get; set; }

    public decimal? CantidadDesp { get; set; }

    public DateTime? CreatedAt { get; set; }

}
