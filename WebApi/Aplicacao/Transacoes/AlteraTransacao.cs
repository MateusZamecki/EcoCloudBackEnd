using Aplicacao.Transacoes.Interfaces;
using Aplicacao.Mapeadores;
using Comum.Excecoes;
using Dominio.Transacoes;
using Dominio.ObjetosDeValor;
using Infra.Repositorios.Interfaces;
using System.Threading.Tasks;
using Aplicacao.Classificacoes.Interfaces;
using System;
using Aplicacao.DTOs.Transacoes;

namespace Aplicacao.Transacoes;

public class AlteraTransacao : IAlteraTransacao
{
    private readonly ITransacaoRepositorio _transacaoRepositorio;
    private readonly IConsultaClassificacao _consultaClassificacao;

    public AlteraTransacao(ITransacaoRepositorio transacaoRepositorio, IConsultaClassificacao consultaClassificacao)
    {
        _transacaoRepositorio = transacaoRepositorio;
        _consultaClassificacao = consultaClassificacao;
    }

    public async Task Alterar(AlteraTransacaoDto transacaoDto)
    {
        var transacao = await _transacaoRepositorio.ObterPorId(transacaoDto.Id);
        ValidarDadosObrigatorios(transacao);

        AlterarNome(transacao, transacaoDto);
        AtualizarQuantia(transacao, transacaoDto);
        AlterarDescricao(transacao, transacaoDto);
        AlterarRecorrencia(transacao, transacaoDto);
        AlterarDataDeCriacao(transacao, transacaoDto);
        await AlterarClassificacao(transacao, transacaoDto);

        await _transacaoRepositorio.Atualizar(transacao);
    }

    private void AlterarNome(Transacao transacao, AlteraTransacaoDto transacaoDto)
    {
        var novoNome = Nome.Criar(transacaoDto.Nome);
        transacao.AlterarNome(novoNome);
    }

    private void AtualizarQuantia(Transacao transacao, AlteraTransacaoDto transacaoDto)
    {
        var novaQuantia = Quantia.Criar(transacaoDto.Quantia);
        transacao.AtualizarQuantia(novaQuantia);
    }

    private void AlterarDataDeCriacao(Transacao transacao, AlteraTransacaoDto transacaoDto)
    {
        transacao.AlterarDataDeCriacao(transacaoDto.DataDeCriacao);
    }

    private void AlterarRecorrencia(Transacao transacao, AlteraTransacaoDto transacaoDto)
    {
        transacao.AlterarRecorrencia(transacaoDto.EhRecorrente);
    }

    private void AlterarDescricao(Transacao transacao, AlteraTransacaoDto transacaoDto)
    {
        transacao.AlterarDescricao(transacaoDto.Descricao);
    }

    private async Task AlterarClassificacao(Transacao transacao, AlteraTransacaoDto transacaoDto)
    {
        var classificacao = await _consultaClassificacao.ConsultarClassificacao(transacaoDto.IdDaClassificacao);
        transacao.AlterarClassificacao(classificacao);
    }

    private void ValidarDadosObrigatorios(Transacao transacao)
    {
        new ExcecaoDeAplicacao()
            .QuandoEhNulo(transacao, MensagensDeExcecao.TransacaoNaoEncontrada)
            .EntaoDispara();
    }
}
