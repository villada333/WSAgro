using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WSAgro.DAO.Entidades;

namespace WSAgro.DAO.Mapeos;

public class MaterialPropagacionMap : IEntityTypeConfiguration<MaterialPropagacion>
{
    public void Configure(EntityTypeBuilder<MaterialPropagacion> builder)
    {
        builder.ToTable("material_propagacion")
               .HasKey(x => x.Id);
    }
}
