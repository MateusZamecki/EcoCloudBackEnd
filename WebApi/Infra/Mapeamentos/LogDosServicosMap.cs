using Dominio.Servicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mapeamentos;

public class LogDosServicosMap : IEntityTypeConfiguration<LogDosServicos>
{
    public void Configure(EntityTypeBuilder<LogDosServicos> builder)
    {
        builder.ToTable("LogDosServicos");
        builder.HasKey(logDosServicos => logDosServicos.Id);
        builder.Property(logDosServicos => logDosServicos.TipoDeServico).HasConversion<int>().IsRequired();
        builder.Property(logDosServicos => logDosServicos.TipoDeInformacao).HasConversion<int>().IsRequired();
        builder.Property(logDosServicos => logDosServicos.DataDeExcecucao).HasColumnType("datetime").IsRequired();
        builder.Property(logDosServicos => logDosServicos.Mensagem).HasColumnType("varchar(500)").IsRequired();
    }
}
