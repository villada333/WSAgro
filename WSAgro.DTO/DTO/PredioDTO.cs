namespace WSAgro.DTO.DTO;

public class PredioDTO
{
    public Guid id { get; set; }

    public string? TenantId { get; set; }

    public string? Nombre { get; set; }

    public string? CodigoIca { get; set; }

    public decimal? UbicacionLat { get; set; }

    public decimal? UbicacionLon { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

}
