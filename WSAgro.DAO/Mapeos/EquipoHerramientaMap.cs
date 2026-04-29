using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WSAgro.DAO.Entidades;

namespace WSAgro.DAO.Mapeos;

public class EquipoHerramientaMap : IEntityTypeConfiguration<EquipoHerramienta>
{
    public void Configure(EntityTypeBuilder<EquipoHerramienta> builder)
    {
        builder.ToTable("equipo_herramienta")
               .HasKey(x => x.Id);
    }
}
