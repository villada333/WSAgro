using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WSAgro.DAO.Entidades;

namespace WSAgro.DAO.Mapeos;

public class RegistroCosechaMap : IEntityTypeConfiguration<RegistroCosecha>
{
    public void Configure(EntityTypeBuilder<RegistroCosecha> builder)
    {
        builder.ToTable("registro_cosecha")
               .HasKey(x => x.Id);
    }
}
