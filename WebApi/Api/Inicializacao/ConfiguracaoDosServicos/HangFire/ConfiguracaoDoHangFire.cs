using Hangfire;
using Infra.ConexaoComBanco;

namespace WebApi.Inicializacao.ConfiguracaoDosServicos.HangFire;

public static class ConfiguracaoDoHangFire
{
    public static void ConfigurarHangFire(this IServiceCollection services)
    {
        var conexao = ControladorDeRotaDoBancoDeDados.ConexaoHangFire();
        services.AddHangfire(configuration => configuration
                    .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
                    .UseSimpleAssemblyNameTypeSerializer()
                    .UseRecommendedSerializerSettings()
                    .UseSqlServerStorage(conexao));
        services.AddHangfireServer();
    }

    public static void MapearQuadroDoHangFire(this WebApplication app)
    {
        app.UseHangfireDashboard();
        app.MapHangfireDashboard();
    }
}
