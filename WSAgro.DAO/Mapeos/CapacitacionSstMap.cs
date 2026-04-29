using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WSAgro.DAO.Entidades;

namespace WSAgro.DAO.Mapeos;

public class CapacitacionSstMap : IEntityTypeConfiguration<CapacitacionSst>
{
    public void Configure(EntityTypeBuilder<CapacitacionSst> builder)
    {
        builder.ToTable("capacitacion_sst")
               .HasKey(x => x.Id);
    }
}
