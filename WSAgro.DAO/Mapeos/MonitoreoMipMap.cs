using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WSAgro.DAO.Entidades;

namespace WSAgro.DAO.Mapeos;

public class MonitoreoMipMap : IEntityTypeConfiguration<MonitoreoMip>
{
    public void Configure(EntityTypeBuilder<MonitoreoMip> builder)
    {
        builder.ToTable("monitoreo_mip")
               .HasKey(x => x.Id);
    }
}
