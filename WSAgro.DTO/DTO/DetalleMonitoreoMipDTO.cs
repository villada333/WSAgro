namespace WSAgro.DTO.DTO;

public class DetalleMonitoreoMipDTO
{
    public Guid id { get; set; }

    public string? TenantId { get; set; }

    public Guid? MonitoreoId { get; set; }

    public Guid? PlagaId { get; set; }

    public int? PlantasAfectadas { get; set; }

    public decimal? IncidenciaCalc { get; set; }

    public DateTime? CreatedAt { get; set; }

}
