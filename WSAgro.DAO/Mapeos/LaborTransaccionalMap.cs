using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WSAgro.DAO.Entidades;

namespace WSAgro.DAO.Mapeos;

public class LaborTransaccionalMap : IEntityTypeConfiguration<LaborTransaccional>
{
    public void Configure(EntityTypeBuilder<LaborTransaccional> builder)
    {
        builder.ToTable("labor_transaccional")
               .HasKey(x => x.Id);
    }
}
