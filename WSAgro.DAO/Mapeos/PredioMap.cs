using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WSAgro.DAO.Entidades;

namespace WSAgro.DAO.Mapeos;

public class PredioMap : IEntityTypeConfiguration<Predio>
{
    public void Configure(EntityTypeBuilder<Predio> builder)
    {
        builder.ToTable("predio")
               .HasKey(x => x.Id);
    }
}
