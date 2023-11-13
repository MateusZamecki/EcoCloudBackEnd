using Dominio.Colunas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mapeamentos;

public class ColunaMap : IEntityTypeConfiguration<Coluna>
{
    public void Configure(EntityTypeBuilder<Coluna> builder)
    {
        builder.ToTable("Colunas");
        builder.HasKey(coluna => coluna.Id);
        builder.OwnsOne(coluna => coluna.Nome)
            .Property(nome => nome.Valor)
            .HasColumnType("varchar(50)")
            .HasColumnName("Nome")
            .IsRequired();
        builder.HasMany(coluna => coluna.Transacoes)
            .WithOne()
            .HasForeignKey("ColunaId")
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
        builder.HasOne(coluna => coluna.Configuracao)
            .WithOne()
            .HasForeignKey<Configuracao>("ColunaId")
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired(false);
        builder.Property(coluna => coluna.Tipo)
            .HasConversion<int>()
            .IsRequired();
    }
}
