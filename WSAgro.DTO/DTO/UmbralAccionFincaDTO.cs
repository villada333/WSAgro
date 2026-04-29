namespace WSAgro.DTO.DTO;

public class UmbralAccionFincaDTO
{
    public Guid id { get; set; }

    public string? TenantId { get; set; }

    public Guid? PlagaId { get; set; }

    public decimal? IncidenciaMaxima { get; set; }

    public DateTime? CreatedAt { get; set; }

}
