using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WSAgro.DAO.Entidades;

namespace WSAgro.DAO.Mapeos;

public class CatalogoInsumoIcaMap : IEntityTypeConfiguration<CatalogoInsumoIca>
{
    public void Configure(EntityTypeBuilder<CatalogoInsumoIca> builder)
    {
        builder.ToTable("catalogo_insumo_ica")
               .HasKey(x => x.Id);
    }
}
