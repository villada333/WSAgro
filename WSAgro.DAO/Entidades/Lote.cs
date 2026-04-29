using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSAgro.DAO.Entidades;

[Table("lote")]
public class Lote
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("tenant_id")]
    public string? TenantId { get; set; }

    [Column("predio_id")]
    public Guid? PredioId { get; set; }

    [Column("nombre_numero")]
    public string? NombreNumero { get; set; }

    [Column("cultivo")]
    public string? Cultivo { get; set; }

    [Column("area_ha")]
    public decimal? AreaHa { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

}
