using Aplicacao.Configuracoes.Interfaces;
using Aplicacao.DTOs;
using Aplicacao.Mapeadores;
using Comum.Excecoes;
using Dominio.Colunas;
using Infra.Repositorios.Interfaces;
using System.Threading.Tasks;

namespace Aplicacao.Configuracoes;

public class AlteraIntervaloDaConfiguracao : IAlteraIntervaloDaConfiguracao
{
    private readonly IConfiguracaoRepositorio _configuracaoRepositorio;

    public AlteraIntervaloDaConfiguracao(IConfiguracaoRepositorio configuracaoRepositorio)
    {
        _configuracaoRepositorio = configuracaoRepositorio;
    }

    public async Task<ConfiguracaoDto> Alterar(ConfiguracaoDto configuracaoDto)
    {
        var configuracao = await _configuracaoRepositorio.ObterPorId(configuracaoDto.Id);
        ValidarSeAConfiguracaoFoiEncontrada(configuracao);

        configuracao.AlterarIntervalo(configuracaoDto.IntervaloDeDias);

        await _configuracaoRepositorio.Atualizar(configuracao);

        return configuracao.ObterDto();
    }

    private void ValidarSeAConfiguracaoFoiEncontrada(Configuracao configuracao)
    {
        new ExcecaoDeAplicacao()
            .QuandoEhNulo(configuracao, MensagensDeExcecao.ConfiguracaoNaoEncontrada)
            .EntaoDispara();
    }
}
