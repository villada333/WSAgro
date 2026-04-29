namespace WSAgro.DTO.DTO;

public class AnalisisRecursoDTO
{
    public Guid id { get; set; }

    public string? TenantId { get; set; }

    public Guid? PredioId { get; set; }

    public string? TipoAnalisis { get; set; }

    public DateTime? FechaMuestreo { get; set; }

    public DateTime? FechaVencimiento { get; set; }

    public string? DocumentoUrl { get; set; }

    public DateTime? CreatedAt { get; set; }

}
