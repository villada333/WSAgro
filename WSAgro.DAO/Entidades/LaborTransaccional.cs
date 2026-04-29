using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSAgro.DAO.Entidades;

[Table("labor_transaccional")]
public class LaborTransaccional
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("tenant_id")]
    public string? TenantId { get; set; }

    [Column("tipo_labor")]
    public string? TipoLabor { get; set; }

    [Column("lote_id")]
    public Guid? LoteId { get; set; }

    [Column("insumo_id")]
    public Guid? InsumoId { get; set; }

    [Column("operario_id")]
    public Guid? OperarioId { get; set; }

    [Column("agronomo_id")]
    public Guid? AgronomoId { get; set; }

    [Column("tarjeta_prof_agronomo")]
    public string? TarjetaProfAgronomo { get; set; }

    [Column("fecha_aplicacion")]
    public DateTime? FechaAplicacion { get; set; }

    [Column("dosis_aplicada")]
    public decimal? DosisAplicada { get; set; }

    [Column("p_carencia")]
    public int? PCarencia { get; set; }

    [Column("p_reingreso")]
    public int? PReingreso { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

}
