using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WSAgro.DAO.Entidades;

namespace WSAgro.DAO.Mapeos;

public class DetalleMonitoreoMipMap : IEntityTypeConfiguration<DetalleMonitoreoMip>
{
    public void Configure(EntityTypeBuilder<DetalleMonitoreoMip> builder)
    {
        builder.ToTable("detalle_monitoreo_mip")
               .HasKey(x => x.Id);
    }
}
