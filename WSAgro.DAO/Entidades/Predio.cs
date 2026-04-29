using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSAgro.DAO.Entidades;

[Table("predio")]
public class Predio
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("tenant_id")]
    public string? TenantId { get; set; }

    [Column("nombre")]
    public string? Nombre { get; set; }

    [Column("codigo_ica")]
    public string? CodigoIca { get; set; }

    [Column("ubicacion_lat")]
    public decimal? UbicacionLat { get; set; }

    [Column("ubicacion_lon")]
    public decimal? UbicacionLon { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }

}
