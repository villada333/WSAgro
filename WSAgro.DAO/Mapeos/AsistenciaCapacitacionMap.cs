using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WSAgro.DAO.Entidades;

namespace WSAgro.DAO.Mapeos;

public class AsistenciaCapacitacionMap : IEntityTypeConfiguration<AsistenciaCapacitacion>
{
    public void Configure(EntityTypeBuilder<AsistenciaCapacitacion> builder)
    {
        builder.ToTable("asistencia_capacitacion")
               .HasKey(x => x.Id);
    }
}
