using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSAgro.DAO.Entidades;

[Table("inventario_bodega")]
public class InventarioBodega
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("tenant_id")]
    public string? TenantId { get; set; }

    [Column("catalogo_id")]
    public Guid? CatalogoId { get; set; }

    [Column("lote_fabricacion")]
    public string? LoteFabricacion { get; set; }

    [Column("fecha_vencimiento")]
    public DateTime? FechaVencimiento { get; set; }

    [Column("stock_actual")]
    public decimal? StockActual { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }

}
