using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WSAgro.DAO.Entidades;

namespace WSAgro.DAO.Mapeos;

public class UmbralAccionFincaMap : IEntityTypeConfiguration<UmbralAccionFinca>
{
    public void Configure(EntityTypeBuilder<UmbralAccionFinca> builder)
    {
        builder.ToTable("umbral_accion_finca")
               .HasKey(x => x.Id);
    }
}
