using Dominio.Usuarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mapeamentos;

public class UsuarioMap : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("Usuarios");
        builder.HasKey(usuario => usuario.Id);
        builder.OwnsOne(usuario => usuario.Nome)
            .Property(nome => nome.Valor)
            .HasColumnType("varchar(50)")
            .HasColumnName("Nome")
            .IsRequired();
        builder.OwnsOne(usuario => usuario.Email)
            .Property(email => email.Valor)
            .HasColumnType("varchar(200)")
            .HasColumnName("Email")
            .IsRequired();
        builder.Property(usuario => usuario.DataDeCriacao)
            .HasColumnType("datetime")
            .IsRequired();
    }
}
