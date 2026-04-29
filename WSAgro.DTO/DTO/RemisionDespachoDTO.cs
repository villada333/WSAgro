namespace WSAgro.DTO.DTO;

public class RemisionDespachoDTO
{
    public Guid id { get; set; }

    public string? TenantId { get; set; }

    public int? Consecutivo { get; set; }

    public DateTime? FechaDespacho { get; set; }

    public string? Cliente { get; set; }

    public string? PlacaVehiculo { get; set; }

    public DateTime? CreatedAt { get; set; }

}
