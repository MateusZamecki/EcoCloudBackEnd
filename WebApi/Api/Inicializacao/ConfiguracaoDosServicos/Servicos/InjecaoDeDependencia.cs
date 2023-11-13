using Infra.ConexaoComBanco;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Inicializacao.ConfiguracaoDosServicos.Servicos;

public static class InjecaoDeDependencia
{
    public static void RegistrarServicos(this IServiceCollection services)
    {
        services.AddDbContext<Contexto>(options =>
            options.UseSqlServer(ControladorDeRotaDoBancoDeDados.Conexao()));

        services.RegistrarServicosDeAplicacao();
        services.RegistrarServicosDeInfra();
        services.RegistrarServicosDaApi();
    }
}
