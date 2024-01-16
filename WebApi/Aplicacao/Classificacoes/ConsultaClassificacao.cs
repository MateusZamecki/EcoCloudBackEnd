using Aplicacao.Classificacoes.Interfaces;
using Aplicacao.DTOs;
using Aplicacao.Mapeadores;
using Comum.Excecoes;
using Dominio.Transacoes;
using Infra.Repositorios.Interfaces;
using System;
using System.Threading.Tasks;

namespace Aplicacao.Classificacoes;

public class ConsultaClassificacao : IConsultaClassificacao
{
    private readonly IClassificacaoRepositorio _classificacaoRepositorio;

    public ConsultaClassificacao(IClassificacaoRepositorio classificacaoRepositorio)
    {
        _classificacaoRepositorio = classificacaoRepositorio;
    }

    public async Task<ClassificacaoDto> Consultar(int id)
    {
        var classificacao = await RealizarConsultaEValidacao(id);

        return classificacao.ObterDto();
    }

    private async Task<Classificacao> RealizarConsultaEValidacao(int id)
    {
        var classificacao = await _classificacaoRepositorio.ObterPorId(id);
        ValidarSeAClassificacaoExiste(classificacao);

        return classificacao;
    }

    public async Task<Classificacao> ConsultarClassificacao(int id)
    {
        return await RealizarConsultaEValidacao(id);
    }

    private void ValidarSeAClassificacaoExiste(Classificacao classificacao)
    {
        new ExcecaoDeAplicacao()
            .QuandoEhNulo(classificacao, MensagensDeExcecao.ClassificacaoNaoEncontrada)
            .EntaoDispara();
    }
}
