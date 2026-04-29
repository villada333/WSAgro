using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSAgro.DAO.Entidades;

[Table("catalogo_plaga_enfermedad")]
public class CatalogoPlagaEnfermedad
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("nombre_comun")]
    public string? NombreComun { get; set; }

    [Column("nombre_cientifico")]
    public string? NombreCientifico { get; set; }

    [Column("tipo_agente")]
    public string? TipoAgente { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

}
