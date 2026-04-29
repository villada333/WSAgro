using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSAgro.DAO.Entidades;

[Table("analisis_recurso")]
public class AnalisisRecurso
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("tenant_id")]
    public string? TenantId { get; set; }

    [Column("predio_id")]
    public Guid? PredioId { get; set; }

    [Column("tipo_analisis")]
    public string? TipoAnalisis { get; set; }

    [Column("fecha_muestreo")]
    public DateTime? FechaMuestreo { get; set; }

    [Column("fecha_vencimiento")]
    public DateTime? FechaVencimiento { get; set; }

    [Column("documento_url")]
    public string? DocumentoUrl { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

}
