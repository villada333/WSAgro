namespace WSAgro.DTO.DTO;

public class LaborTransaccionalDTO
{
    public Guid id { get; set; }

    public string? TenantId { get; set; }

    public string? TipoLabor { get; set; }

    public Guid? LoteId { get; set; }

    public Guid? InsumoId { get; set; }

    public Guid? OperarioId { get; set; }

    public Guid? AgronomoId { get; set; }

    public string? TarjetaProfAgronomo { get; set; }

    public DateTime? FechaAplicacion { get; set; }

    public decimal? DosisAplicada { get; set; }

    public int? PCarencia { get; set; }

    public int? PReingreso { get; set; }

    public DateTime? CreatedAt { get; set; }

}
