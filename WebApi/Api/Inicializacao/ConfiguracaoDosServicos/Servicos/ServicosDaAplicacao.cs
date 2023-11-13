using Aplicacao.Colunas;
using Aplicacao.Colunas.Interfaces;
using Aplicacao.Configuracoes;
using Aplicacao.Configuracoes.Interfaces;
using Aplicacao.Quadros;
using Aplicacao.Quadros.Interfaces;
using Aplicacao.Transacoes;
using Aplicacao.Transacoes.Interfaces;
using Aplicacao.Usuarios;
using Aplicacao.Usuarios.Interfaces;

namespace WebApi.Inicializacao.ConfiguracaoDosServicos.Servicos;

public static class ServicosDaAplicacao
{
    public static void RegistrarServicosDeAplicacao(this IServiceCollection services)
    {
        services.AddScoped<IAtualizaQuantia, AtualizaQuantia>();
        services.AddScoped<IAdicionaTransacao, AdicionaTransacao>();
        services.AddScoped<IExcluiTransacao, ExcluiTransacao>();
        services.AddScoped<IAlteraNomeDaTransacao, AlteraNomeDaTransacao>();
        services.AddScoped<IDesativaTransacao, DesativaTransacao>();
        services.AddScoped<IMovimentaTransacao, MovimentaTransacao>();

        services.AddScoped<IAdicionaColuna, AdicionaColuna>();
        services.AddScoped<IAlteraNomeDaColuna, AlteraNomeDaColuna>();
        services.AddScoped<IExcluiColuna, ExcluiColuna>();
        services.AddScoped<ISalvaTodasAsTransacoesNoHistorico, SalvaTodasAsTransacoesNoHistorico>();
        services.AddScoped<IConsultaHistorico, ConsultaHistorico>();
        services.AddScoped<IConsultaColuna, ConsultaColuna>();

        services.AddScoped<IAdicionaConfiguracaoNaColuna, AdicionaConfiguracaoNaColuna>();
        services.AddScoped<IAlteraIntervaloDaConfiguracao, AlteraIntervaloDaConfiguracao>();
        services.AddScoped<IExcluiConfiguracao, ExcluiConfiguracao>();
        services.AddScoped<IAdicionaConfiguracaoNoQuadro, AdicionaConfiguracaoNoQuadro>();

        services.AddScoped<IAdicionaQuadro, AdicionaQuadro>();
        services.AddScoped<IAlteraNomeDoQuadro, AlteraNomeDoQuadro>();
        services.AddScoped<IExcluiQuadro, ExcluiQuadro>();
        services.AddScoped<IConsultaQuadro, ConsultaQuadro>();

        services.AddScoped<IConsultaInformacoesDoUsuario, ConsultaInformacoesDoUsuario>();

        services.AddScoped<ISalvaTodasAsTransacoesNoHistoricoAutomaticamente, SalvaTodosAsTransacoesNoHistoricoAutomaticamente>();
    }
}
