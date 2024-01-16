using Dominio.Colunas;
using Dominio.Quadros;
using Dominio.Servicos;
using Dominio.Transacoes;
using Dominio.Usuarios;
using Infra.Mapeamentos;
using Microsoft.EntityFrameworkCore;

namespace Infra.ConexaoComBanco;

public class Contexto : DbContext
{
    public DbSet<Transacao> Transacoes { get; set; }
    public DbSet<Classificacao> Classificacoes { get; set; }
    public DbSet<Coluna> Colunas { get; set; }
    public DbSet<Quadro> Quadros { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<LogDosServicos> LogDosServicos { get; set; }
    public DbSet<Configuracao> Configuracoes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UsuarioMap());
        modelBuilder.ApplyConfiguration(new QuadroMap());
        modelBuilder.ApplyConfiguration(new ColunaMap());
        modelBuilder.ApplyConfiguration(new ConfiguracaoMap());
        modelBuilder.ApplyConfiguration(new LogDosServicosMap());
        modelBuilder.ApplyConfiguration(new ClassificacaoMap());
        modelBuilder.ApplyConfiguration(new TransacaoMap());

        base.OnModelCreating(modelBuilder);
    }

    public Contexto(DbContextOptions<Contexto> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies()
            .UseSqlServer(ControladorDeRotaDoBancoDeDados.Conexao(), b => b.MigrationsAssembly("Infra"));
    }
}
