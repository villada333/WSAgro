using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WSAgro.DAO.Entidades;

namespace WSAgro.DAO.Mapeos;

public class EntregaEppMap : IEntityTypeConfiguration<EntregaEpp>
{
    public void Configure(EntityTypeBuilder<EntregaEpp> builder)
    {
        builder.ToTable("entrega_epp")
               .HasKey(x => x.Id);
    }
}
