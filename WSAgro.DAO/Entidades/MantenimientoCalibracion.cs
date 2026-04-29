using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSAgro.DAO.Entidades;

[Table("mantenimiento_calibracion")]
public class MantenimientoCalibracion
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("tenant_id")]
    public string? TenantId { get; set; }

    [Column("equipo_id")]
    public Guid? EquipoId { get; set; }

    [Column("tipo_actividad")]
    public string? TipoActividad { get; set; }

    [Column("fecha_labor")]
    public DateTime? FechaLabor { get; set; }

    [Column("prox_fecha")]
    public DateTime? ProxFecha { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

}
