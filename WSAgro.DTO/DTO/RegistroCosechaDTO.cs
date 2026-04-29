namespace WSAgro.DTO.DTO;

public class RegistroCosechaDTO
{
    public Guid id { get; set; }

    public string? TenantId { get; set; }

    public Guid? LoteId { get; set; }

    public Guid? OperarioId { get; set; }

    public DateTime? FechaCosecha { get; set; }

    public decimal? Cantidad { get; set; }

    public string? LoteTrazInterno { get; set; }

    public bool? Liberado { get; set; }

    public DateTime? CreatedAt { get; set; }

}
