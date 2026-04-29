using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSAgro.DAO.Entidades;

[Table("equipo_herramienta")]
public class EquipoHerramienta
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("tenant_id")]
    public string? TenantId { get; set; }

    [Column("nombre")]
    public string? Nombre { get; set; }

    [Column("marca_serie")]
    public string? MarcaSerie { get; set; }

    [Column("estado")]
    public string? Estado { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

}
