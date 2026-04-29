using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSAgro.DAO.Entidades;

[Table("monitoreo_mip")]
public class MonitoreoMip
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("tenant_id")]
    public string? TenantId { get; set; }

    [Column("lote_id")]
    public Guid? LoteId { get; set; }

    [Column("operario_id")]
    public Guid? OperarioId { get; set; }

    [Column("fecha_monitoreo")]
    public DateTime? FechaMonitoreo { get; set; }

    [Column("est_fenologico")]
    public string? EstFenologico { get; set; }

    [Column("plantas_evaluadas")]
    public int? PlantasEvaluadas { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

}
