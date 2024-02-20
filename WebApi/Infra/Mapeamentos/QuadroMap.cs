using Dominio.Quadros;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mapeamentos;

public class QuadroMap : IEntityTypeConfiguration<Quadro>
{
    public void Configure(EntityTypeBuilder<Quadro> builder)
    {
        builder.ToTable("Quadros");
        builder.HasKey(quadro => quadro.Id);
        builder.OwnsOne(quadro => quadro.Nome)
            .Property(nome => nome.Valor)
            .HasColumnType("varchar(50)")
            .HasColumnName("Nome")
            .IsRequired();
    }
}
