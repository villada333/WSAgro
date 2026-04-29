using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSAgro.DAO.Entidades;

[Table("catalogo_insumo_ica")]
public class CatalogoInsumoIca
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("registro_ica")]
    public string? RegistroIca { get; set; }

    [Column("nombre_comercial")]
    public string? NombreComercial { get; set; }

    [Column("ingrediente_activo")]
    public string? IngredienteActivo { get; set; }

    [Column("categoria_tox")]
    public string? CategoriaTox { get; set; }

    [Column("tipo_insumo")]
    public string? TipoInsumo { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

}
