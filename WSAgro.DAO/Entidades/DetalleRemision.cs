using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSAgro.DAO.Entidades;

[Table("detalle_remision")]
public class DetalleRemision
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("tenant_id")]
    public string? TenantId { get; set; }

    [Column("remision_id")]
    public Guid? RemisionId { get; set; }

    [Column("cosecha_id")]
    public Guid? CosechaId { get; set; }

    [Column("cantidad_desp")]
    public decimal? CantidadDesp { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

}
