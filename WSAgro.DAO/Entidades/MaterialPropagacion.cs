using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSAgro.DAO.Entidades;

[Table("material_propagacion")]
public class MaterialPropagacion
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("tenant_id")]
    public string? TenantId { get; set; }

    [Column("lote_id")]
    public Guid? LoteId { get; set; }

    [Column("proveedor_vivero")]
    public string? ProveedorVivero { get; set; }

    [Column("registro_ica_vivero")]
    public string? RegistroIcaVivero { get; set; }

    [Column("fecha_siembra")]
    public DateTime? FechaSiembra { get; set; }

    [Column("variedad")]
    public string? Variedad { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

}
