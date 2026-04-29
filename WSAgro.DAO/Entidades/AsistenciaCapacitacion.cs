using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSAgro.DAO.Entidades;

[Table("asistencia_capacitacion")]
public class AsistenciaCapacitacion
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("tenant_id")]
    public string? TenantId { get; set; }

    [Column("capacitacion_id")]
    public Guid? CapacitacionId { get; set; }

    [Column("usuario_id")]
    public Guid? UsuarioId { get; set; }

    [Column("firma_base64")]
    public string? FirmaBase64 { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

}
