using Aplicacao.DTOs;
using Aplicacao.Transacoes.Interfaces;
using Comum.Excecoes;
using Dominio.Colunas;
using Dominio.Transacoes;
using Infra.Repositorios.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicacao.Transacoes;

public class MovimentaTransacao : IMovimentaTransacao
{
    private readonly IColunaRepositorio _colunaRepositorio;

    public MovimentaTransacao(IColunaRepositorio colunaRepositorio)
    {
        _colunaRepositorio = colunaRepositorio;
    }

    public async Task Movimentar(MovimentacaoDeTransacaoDto MovimentacaoDeTransacaoDto)
    {
        var coluna = await _colunaRepositorio.ObterPorId(MovimentacaoDeTransacaoDto.IdDaColunaAtual);
        var colunaDestino = await _colunaRepositorio.ObterPorId(MovimentacaoDeTransacaoDto.IdDaColunaDestino);
        ValidarSeAsColunasExistem(coluna, colunaDestino);

        var transacao = coluna.Transacoes.FirstOrDefault(transacao => transacao.Id == MovimentacaoDeTransacaoDto.IdDaTransacao);
        ValidarSeATransacaoExiste(transacao);

        coluna.ExlcuirTransacao(transacao);
        colunaDestino.AdicionarTransacao(transacao);

        await _colunaRepositorio.Atualizar(colunaDestino);
    }

    private void ValidarSeATransacaoExiste(Transacao transacao)
    {
        new ExcecaoDeAplicacao()
            .QuandoEhNulo(transacao, MensagensDeExcecao.TransacaoNaoEncontrada)
            .EntaoDispara();
    }

    private void ValidarSeAsColunasExistem(Coluna coluna, Coluna colunaDestino)
    {
        new ExcecaoDeAplicacao()
            .QuandoEhNulo(coluna, MensagensDeExcecao.ColunaNaoEncontrada)
            .QuandoEhNulo(colunaDestino, MensagensDeExcecao.ErroAoMovimentarATransacaoParaAColunaDeDestino)
            .EntaoDispara();
    }
}
