using Aplicacao.Classificacoes;
using Aplicacao.Classificacoes.Interfaces;
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
        services.AddScoped<IAdicionaTransacao, AdicionaTransacao>();
        services.AddScoped<IExcluiTransacao, ExcluiTransacao>();
        services.AddScoped<IAlteraTransacao, AlteraTransacao>();
        services.AddScoped<IDesativaTransacao, DesativaTransacao>();
        services.AddScoped<IMovimentaTransacao, MovimentaTransacao>();

        services.AddScoped<IAdicionaClassificacao, AdicionaClassificacao>();
        services.AddScoped<IAlteraClassificacao, AlteraClassificacao>();
        services.AddScoped<IConsultaTodasAsClassificacoes, ConsultaTodasAsClassificacoes>();
        services.AddScoped<IExcluiClassificacao, ExcluiClassificacao>();
        services.AddScoped<IConsultaClassificacao, ConsultaClassificacao>();

        services.AddScoped<IAdicionaColuna, AdicionaColuna>();
        services.AddScoped<IAlteraColuna, AlteraColuna>();
        services.AddScoped<IExcluiColuna, ExcluiColuna>();
        services.AddScoped<ISalvaTodasAsTransacoesNoHistorico, SalvaTodasAsTransacoesNoHistorico>();
        services.AddScoped<IConsultaHistorico, ConsultaHistorico>();
        services.AddScoped<IConsultaColuna, ConsultaColuna>();

        services.AddScoped<IAdicionaConfiguracaoNaColuna, AdicionaConfiguracaoNaColuna>();
        services.AddScoped<IAlteraConfiguracao, AlteraConfiguracao>();
        services.AddScoped<IExcluiConfiguracao, ExcluiConfiguracao>();
        services.AddScoped<IAdicionaConfiguracaoNoQuadro, AdicionaConfiguracaoNoQuadro>();
        services.AddScoped<IConsultaConfiguracao, ConsultaConfiguracao>();

        services.AddScoped<IAdicionaQuadro, AdicionaQuadro>();
        services.AddScoped<IAlteraNomeDoQuadro, AlteraNomeDoQuadro>();
        services.AddScoped<IExcluiQuadro, ExcluiQuadro>();
        services.AddScoped<IConsultaQuadro, ConsultaQuadro>();
        services.AddScoped<IConsultaQuadrosDoUsuario, ConsultaQuadrosDoUsuario>();

        services.AddScoped<IConsultaInformacoesDoUsuario, ConsultaInformacoesDoUsuario>();

        services.AddScoped<ISalvaTodasAsTransacoesNoHistoricoAutomaticamente, SalvaTodosAsTransacoesNoHistoricoAutomaticamente>();
    }
}
