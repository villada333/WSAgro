namespace WSAgro.DTO.DTO;

public class InventarioBodegaDTO
{
    public Guid id { get; set; }

    public string? TenantId { get; set; }

    public Guid? CatalogoId { get; set; }

    public string? LoteFabricacion { get; set; }

    public DateTime? FechaVencimiento { get; set; }

    public decimal? StockActual { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

}
