using Dominio.Transacoes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mapeamentos;

public class ClassificacaoMap : IEntityTypeConfiguration<Classificacao>
{
    public void Configure(EntityTypeBuilder<Classificacao> builder)
    {
        builder.ToTable("Classificacoes");
        builder.HasKey(classificacao => classificacao.Id);
        builder.OwnsOne(classificacao => classificacao.Nome)
           .Property(nome => nome.Valor)
           .HasColumnType("varchar(50)")
           .HasColumnName("Nome")
           .IsRequired();
        builder.Property(classificacao => classificacao.Cor)
            .HasConversion<string>()
            .IsRequired();
    }
}
