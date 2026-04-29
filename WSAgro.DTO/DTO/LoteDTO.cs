namespace WSAgro.DTO.DTO;

public class LoteDTO
{
    public Guid id { get; set; }

    public string? TenantId { get; set; }

    public Guid? PredioId { get; set; }

    public string? NombreNumero { get; set; }

    public string? Cultivo { get; set; }

    public decimal? AreaHa { get; set; }

    public DateTime? CreatedAt { get; set; }

}
