using Infra.Repositorios;
using Infra.Repositorios.Interfaces;

namespace WebApi.Inicializacao.ConfiguracaoDosServicos.Servicos;

public static class ServicosDeInfra
{
    public static void RegistrarServicosDeInfra(this IServiceCollection services)
    {
        services.AddScoped<IQuadroRepositorio, QuadroRepositorio>();
        services.AddScoped<ITransacaoRepositorio, TransacaoRepositorio>();
        services.AddScoped<IColunaRepositorio, ColunaRepositorio>();
        services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
        services.AddScoped<IConfiguracaoRepositorio, ConfiguracaoRepositorio>();
        services.AddScoped<IClassificacaoRepositorio, ClassificacaoRepositorio>();
    }
}
