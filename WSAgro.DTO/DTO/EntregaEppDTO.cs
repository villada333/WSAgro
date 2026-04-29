namespace WSAgro.DTO.DTO;

public class EntregaEppDTO
{
    public Guid id { get; set; }

    public string? TenantId { get; set; }

    public Guid? UsuarioId { get; set; }

    public DateTime? FechaEntrega { get; set; }

    public string? Elementos { get; set; }

    public DateTime? CreatedAt { get; set; }

}
