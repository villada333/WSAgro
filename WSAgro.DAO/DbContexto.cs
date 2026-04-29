using Microsoft.EntityFrameworkCore;
using WSAgro.DAO.Entidades;
using WSAgro.DAO.Mapeos;

namespace WSAgro.DAO;

public class DbContexto : DbContext
{
    public DbContexto(DbContextOptions<DbContexto> options) : base(options)
    {
    }

    public DbSet<AnalisisRecurso> AnalisisRecurso { get; set; }
    public DbSet<AsistenciaCapacitacion> AsistenciaCapacitacion { get; set; }
    public DbSet<CapacitacionSst> CapacitacionSst { get; set; }
    public DbSet<CatalogoInsumoIca> CatalogoInsumoIca { get; set; }
    public DbSet<CatalogoPlagaEnfermedad> CatalogoPlagaEnfermedad { get; set; }
    public DbSet<DetalleMonitoreoMip> DetalleMonitoreoMip { get; set; }
    public DbSet<DetalleRemision> DetalleRemision { get; set; }
    public DbSet<EntregaEpp> EntregaEpp { get; set; }
    public DbSet<EquipoHerramienta> EquipoHerramienta { get; set; }
    public DbSet<InventarioBodega> InventarioBodega { get; set; }
    public DbSet<LaborTransaccional> LaborTransaccional { get; set; }
    public DbSet<Lote> Lote { get; set; }
    public DbSet<MantenimientoCalibracion> MantenimientoCalibracion { get; set; }
    public DbSet<MaterialPropagacion> MaterialPropagacion { get; set; }
    public DbSet<MonitoreoMip> MonitoreoMip { get; set; }
    public DbSet<Predio> Predio { get; set; }
    public DbSet<RegistroCosecha> RegistroCosecha { get; set; }
    public DbSet<RemisionDespacho> RemisionDespacho { get; set; }
    public DbSet<UmbralAccionFinca> UmbralAccionFinca { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AnalisisRecursoMap());
        modelBuilder.ApplyConfiguration(new AsistenciaCapacitacionMap());
        modelBuilder.ApplyConfiguration(new CapacitacionSstMap());
        modelBuilder.ApplyConfiguration(new CatalogoInsumoIcaMap());
        modelBuilder.ApplyConfiguration(new CatalogoPlagaEnfermedadMap());
        modelBuilder.ApplyConfiguration(new DetalleMonitoreoMipMap());
        modelBuilder.ApplyConfiguration(new DetalleRemisionMap());
        modelBuilder.ApplyConfiguration(new EntregaEppMap());
        modelBuilder.ApplyConfiguration(new EquipoHerramientaMap());
        modelBuilder.ApplyConfiguration(new InventarioBodegaMap());
        modelBuilder.ApplyConfiguration(new LaborTransaccionalMap());
        modelBuilder.ApplyConfiguration(new LoteMap());
        modelBuilder.ApplyConfiguration(new MantenimientoCalibracionMap());
        modelBuilder.ApplyConfiguration(new MaterialPropagacionMap());
        modelBuilder.ApplyConfiguration(new MonitoreoMipMap());
        modelBuilder.ApplyConfiguration(new PredioMap());
        modelBuilder.ApplyConfiguration(new RegistroCosechaMap());
        modelBuilder.ApplyConfiguration(new RemisionDespachoMap());
        modelBuilder.ApplyConfiguration(new UmbralAccionFincaMap());
    }
}
