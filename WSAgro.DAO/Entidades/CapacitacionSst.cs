using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSAgro.DAO.Entidades;

[Table("capacitacion_sst")]
public class CapacitacionSst
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("tenant_id")]
    public string? TenantId { get; set; }

    [Column("tema")]
    public string? Tema { get; set; }

    [Column("fecha")]
    public DateTime? Fecha { get; set; }

    [Column("evidencia_url")]
    public string? EvidenciaUrl { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

}
