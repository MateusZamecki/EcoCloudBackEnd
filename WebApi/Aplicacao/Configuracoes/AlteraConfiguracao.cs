using Aplicacao.Configuracoes.Interfaces;
using Aplicacao.DTOs;
using Aplicacao.Mapeadores;
using Comum.Excecoes;
using Dominio.Colunas;
using Infra.Repositorios.Interfaces;
using System;
using System.Threading.Tasks;

namespace Aplicacao.Configuracoes;

public class AlteraConfiguracao : IAlteraConfiguracao
{
    private readonly IConfiguracaoRepositorio _configuracaoRepositorio;

    public AlteraConfiguracao(IConfiguracaoRepositorio configuracaoRepositorio)
    {
        _configuracaoRepositorio = configuracaoRepositorio;
    }

    public async Task Alterar(ConfiguracaoDto configuracaoDto)
    {
        var configuracao = await _configuracaoRepositorio.ObterPorId(configuracaoDto.Id);
        ValidarSeAConfiguracaoExiste(configuracao);

        AlterarIntervalo(configuracaoDto, configuracao);
        AlterarData(configuracaoDto, configuracao);

        await _configuracaoRepositorio.Atualizar(configuracao);
    }

    private static void AlterarIntervalo(ConfiguracaoDto configuracaoDto, Configuracao configuracao)
    {
        if (configuracaoDto.IntervaloDeDias > 0)
        {
            configuracao.AlterarIntervalo(configuracaoDto.IntervaloDeDias);
        }
    }

    private void AlterarData(ConfiguracaoDto configuracaoDto, Configuracao configuracao)
    {
        if (configuracaoDto.Data != DateTime.MinValue)
        {
            configuracao.AlterarData(configuracaoDto.Data);
        }
    }

    private void ValidarSeAConfiguracaoExiste(Configuracao configuracao)
    {
        new ExcecaoDeAplicacao()
            .QuandoEhNulo(configuracao, MensagensDeExcecao.ConfiguracaoNaoEncontrada)
            .EntaoDispara();
    }
}
