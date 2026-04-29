using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WSAgro.DAO.Entidades;

namespace WSAgro.DAO.Mapeos;

public class DetalleRemisionMap : IEntityTypeConfiguration<DetalleRemision>
{
    public void Configure(EntityTypeBuilder<DetalleRemision> builder)
    {
        builder.ToTable("detalle_remision")
               .HasKey(x => x.Id);
    }
}
