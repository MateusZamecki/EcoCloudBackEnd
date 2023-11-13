using Dominio.Transacoes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mapeamentos;

public class TransacaoMap : IEntityTypeConfiguration<Transacao>
{
    public void Configure(EntityTypeBuilder<Transacao> builder)
    {
        builder.ToTable("Transacoes");
        builder.HasKey(transacao => transacao.Id);
        builder.OwnsOne(transacao => transacao.Nome)
            .Property(nome => nome.Valor)
            .HasColumnType("varchar(50)")
            .HasColumnName("Nome")
            .IsRequired();
        builder.OwnsOne(transacao => transacao.Quantia)
            .Property(quantia => quantia.Valor)
            .HasColumnType("numeric(28,2)")
            .HasColumnName("Quantia")
            .IsRequired();
        builder.Property(transacao => transacao.DataDeCriacao)
            .HasColumnType("datetime")
            .IsRequired();
        builder.Property(transacao => transacao.Ativo)
            .HasColumnType("bit")
            .HasConversion<bool>()
            .HasDefaultValue(true)
            .IsRequired();
        builder.Property(transacao => transacao.Classificacao)
            .HasConversion<int>()
            .IsRequired();
        builder.HasQueryFilter(transacao => transacao.Ativo);
    }
}
