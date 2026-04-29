namespace WSAgro.DTO.DTO;

public class EquipoHerramientaDTO
{
    public Guid id { get; set; }

    public string? TenantId { get; set; }

    public string? Nombre { get; set; }

    public string? MarcaSerie { get; set; }

    public string? Estado { get; set; }

    public DateTime? CreatedAt { get; set; }

}
