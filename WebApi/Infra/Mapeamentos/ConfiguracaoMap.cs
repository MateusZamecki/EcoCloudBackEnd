using Dominio.Colunas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mapeamentos;

public class ConfiguracaoMap : IEntityTypeConfiguration<Configuracao>
{

    public void Configure(EntityTypeBuilder<Configuracao> builder)
    {
        builder.ToTable("Configuracoes");
        builder.HasKey(config => config.Id);
        builder.Property(config => config.IntervaloDeDias).HasColumnType("int").HasColumnName("IntervaloDeDias");
        builder.Property(config => config.Data).HasColumnType("date").HasColumnName("Data");
    }
}
