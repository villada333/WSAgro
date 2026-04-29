using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WSAgro.DAO.Entidades;

namespace WSAgro.DAO.Mapeos;

public class CatalogoPlagaEnfermedadMap : IEntityTypeConfiguration<CatalogoPlagaEnfermedad>
{
    public void Configure(EntityTypeBuilder<CatalogoPlagaEnfermedad> builder)
    {
        builder.ToTable("catalogo_plaga_enfermedad")
               .HasKey(x => x.Id);
    }
}
