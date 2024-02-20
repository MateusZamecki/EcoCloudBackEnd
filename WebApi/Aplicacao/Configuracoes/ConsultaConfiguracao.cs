using Aplicacao.Configuracoes.Interfaces;
using Aplicacao.DTOs.Configuracao;
using Aplicacao.Mapeadores;
using Comum.Excecoes;
using Dominio.Colunas;
using Infra.Repositorios.Interfaces;
using System;
using System.Threading.Tasks;

namespace Aplicacao.Configuracoes;

public class ConsultaConfiguracao : IConsultaConfiguracao
{
    private readonly IConfiguracaoRepositorio _configuracaoRepositorio;

    public ConsultaConfiguracao(IConfiguracaoRepositorio configuracaoRepositorio)
    {
        _configuracaoRepositorio = configuracaoRepositorio;
    }

    public async Task<ConfiguracaoDto> Consultar(int id)
    {
        var configuracao = await Obter(id);
        return configuracao.ObterDto();
    }

    public async Task<Configuracao> ConsultarEntidade(int id)
    {
        return await Obter(id);
    }

    private async Task<Configuracao> Obter(int id)
    {
        var configuracao = await _configuracaoRepositorio.ObterPorId(id);
        ValidarSeAConfiguracaoExiste(configuracao);
        return configuracao;
    }

    private void ValidarSeAConfiguracaoExiste(Configuracao configuracao)
    {
        new ExcecaoDeAplicacao()
            .QuandoEhNulo(configuracao, MensagensDeExcecao.ConfiguracaoNaoFoiEncontrada)
            .EntaoDispara();
    }
}
