using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WSAgro.DAO.Entidades;

namespace WSAgro.DAO.Mapeos;

public class InventarioBodegaMap : IEntityTypeConfiguration<InventarioBodega>
{
    public void Configure(EntityTypeBuilder<InventarioBodega> builder)
    {
        builder.ToTable("inventario_bodega")
               .HasKey(x => x.Id);
    }
}
