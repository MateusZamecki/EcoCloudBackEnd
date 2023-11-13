using Aplicacao.Configuracoes.Interfaces;
using Comum.Excecoes;
using Dominio.Colunas;
using Infra.Repositorios.Interfaces;
using System;
using System.Threading.Tasks;

namespace Aplicacao.Configuracoes;

public class ExcluiConfiguracao : IExcluiConfiguracao
{
    private readonly IConfiguracaoRepositorio _configuracaoRepositorio;

    public ExcluiConfiguracao(IConfiguracaoRepositorio configuracaoRepositorio)
    {
        _configuracaoRepositorio = configuracaoRepositorio;
    }

    public async Task Excluir(int idDaConfiguracao)
    {
        var configuracao = await _configuracaoRepositorio.ObterPorId(idDaConfiguracao);

        ValidarSeAConfiguracaoExiste(configuracao);

        await _configuracaoRepositorio.Excluir(configuracao);
    }

    private void ValidarSeAConfiguracaoExiste(Configuracao configuracao)
    {
        new ExcecaoDeAplicacao()
            .QuandoEhNulo(configuracao, MensagensDeExcecao.ConfiguracaoNaoEncontrada)
            .EntaoDispara();
    }
}
