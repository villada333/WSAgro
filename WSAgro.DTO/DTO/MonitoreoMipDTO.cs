namespace WSAgro.DTO.DTO;

public class MonitoreoMipDTO
{
    public Guid id { get; set; }

    public string? TenantId { get; set; }

    public Guid? LoteId { get; set; }

    public Guid? OperarioId { get; set; }

    public DateTime? FechaMonitoreo { get; set; }

    public string? EstFenologico { get; set; }

    public int? PlantasEvaluadas { get; set; }

    public DateTime? CreatedAt { get; set; }

}
