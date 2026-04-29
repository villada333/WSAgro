namespace WSAgro.DTO.DTO;

public class MantenimientoCalibracionDTO
{
    public Guid id { get; set; }

    public string? TenantId { get; set; }

    public Guid? EquipoId { get; set; }

    public string? TipoActividad { get; set; }

    public DateTime? FechaLabor { get; set; }

    public DateTime? ProxFecha { get; set; }

    public DateTime? CreatedAt { get; set; }

}
