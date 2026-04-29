using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSAgro.DAO.Entidades;

[Table("detalle_monitoreo_mip")]
public class DetalleMonitoreoMip
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("tenant_id")]
    public string? TenantId { get; set; }

    [Column("monitoreo_id")]
    public Guid? MonitoreoId { get; set; }

    [Column("plaga_id")]
    public Guid? PlagaId { get; set; }

    [Column("plantas_afectadas")]
    public int? PlantasAfectadas { get; set; }

    [Column("incidencia_calc")]
    public decimal? IncidenciaCalc { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

}
