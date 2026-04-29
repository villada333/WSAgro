using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSAgro.DAO.Entidades;

[Table("entrega_epp")]
public class EntregaEpp
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("tenant_id")]
    public string? TenantId { get; set; }

    [Column("usuario_id")]
    public Guid? UsuarioId { get; set; }

    [Column("fecha_entrega")]
    public DateTime? FechaEntrega { get; set; }

    [Column("elementos")]
    public string? Elementos { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

}
