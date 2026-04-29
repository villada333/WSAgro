using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WSAgro.DAO.Entidades;

namespace WSAgro.DAO.Mapeos;

public class AnalisisRecursoMap : IEntityTypeConfiguration<AnalisisRecurso>
{
    public void Configure(EntityTypeBuilder<AnalisisRecurso> builder)
    {
        builder.ToTable("analisis_recurso")
               .HasKey(x => x.Id);
    }
}
