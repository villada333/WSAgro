using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WSAgro.DAO.Entidades;

namespace WSAgro.DAO.Mapeos;

public class RemisionDespachoMap : IEntityTypeConfiguration<RemisionDespacho>
{
    public void Configure(EntityTypeBuilder<RemisionDespacho> builder)
    {
        builder.ToTable("remision_despacho")
               .HasKey(x => x.Id);
    }
}
