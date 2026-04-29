using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WSAgro.DAO.Entidades;

namespace WSAgro.DAO.Mapeos;

public class MantenimientoCalibracionMap : IEntityTypeConfiguration<MantenimientoCalibracion>
{
    public void Configure(EntityTypeBuilder<MantenimientoCalibracion> builder)
    {
        builder.ToTable("mantenimiento_calibracion")
               .HasKey(x => x.Id);
    }
}
