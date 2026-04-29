using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSAgro.DAO.Entidades;

[Table("remision_despacho")]
public class RemisionDespacho
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("tenant_id")]
    public string? TenantId { get; set; }

    [Column("consecutivo")]
    public int? Consecutivo { get; set; }

    [Column("fecha_despacho")]
    public DateTime? FechaDespacho { get; set; }

    [Column("cliente")]
    public string? Cliente { get; set; }

    [Column("placa_vehiculo")]
    public string? PlacaVehiculo { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

}
