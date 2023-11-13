using Aplicacao.Transacoes.Interfaces;
using Comum.Excecoes;
using Dominio.Colunas;
using Dominio.Transacoes;
using Infra.Repositorios.Interfaces;
using System;
using System.Threading.Tasks;

namespace Aplicacao.Transacoes;

public class ExcluiTransacao : IExcluiTransacao
{
    private ITransacaoRepositorio _transacaoRepositorio;
    private IColunaRepositorio _colunaRepositorio;

    public ExcluiTransacao(ITransacaoRepositorio transacaoRepositorio, 
        IColunaRepositorio colunaRepositorio)
    {
        _transacaoRepositorio = transacaoRepositorio;
        _colunaRepositorio = colunaRepositorio;
    }

    public async Task Excluir(int idDaTranscao, int idDaColuna)
    {
        var transacao = await _transacaoRepositorio.ObterPorId(idDaTranscao);
        var coluna = await _colunaRepositorio.ObterPorId(idDaColuna);

        ValidarDadosObrigatorios(transacao, coluna);

        coluna.ExlcuirTransacao(transacao);
        await _colunaRepositorio.Atualizar(coluna);
    }

    private void ValidarDadosObrigatorios(Transacao transacao, Coluna coluna)
    {
        new ExcecaoDeAplicacao()
            .QuandoEhNulo(transacao, MensagensDeExcecao.TransacaoNaoEncontrada)
            .QuandoEhNulo(coluna, MensagensDeExcecao.ColunaNaoEncontrada)
            .EntaoDispara();
    }
}
