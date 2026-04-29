using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSAgro.DAO.Entidades;

[Table("umbral_accion_finca")]
public class UmbralAccionFinca
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("tenant_id")]
    public string? TenantId { get; set; }

    [Column("plaga_id")]
    public Guid? PlagaId { get; set; }

    [Column("incidencia_maxima")]
    public decimal? IncidenciaMaxima { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

}
