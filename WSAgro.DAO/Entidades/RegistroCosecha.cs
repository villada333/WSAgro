using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSAgro.DAO.Entidades;

[Table("registro_cosecha")]
public class RegistroCosecha
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

    [Column("fecha_cosecha")]
    public DateTime? FechaCosecha { get; set; }

    [Column("cantidad")]
    public decimal? Cantidad { get; set; }

    [Column("lote_traz_interno")]
    public string? LoteTrazInterno { get; set; }

    [Column("liberado")]
    public bool? Liberado { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

}
