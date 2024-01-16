using Dominio.Colunas;
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
        builder.HasQueryFilter(transacao => transacao.Ativo);

        builder.HasIndex("ClassificacaoId")
            .IsUnique(false);
    }
}
