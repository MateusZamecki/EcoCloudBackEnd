using Aplicacao.DTOs;
using Aplicacao.Mapeadores;
using Aplicacao.Transacoes.Interfaces;
using Comum.Excecoes;
using Dominio.Colunas;
using Dominio.ObjetosDeValor;
using Dominio.Transacoes;
using Infra.Repositorios.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplicacao.Transacoes;

public class AdicionaTransacao : IAdicionaTransacao
{
    private IColunaRepositorio _colunaRepositorio;

    public AdicionaTransacao(IColunaRepositorio colunaRepositorio)
    {
        _colunaRepositorio = colunaRepositorio;
    }

    public async Task<TransacaoDto> Adicionar(TransacaoDto transacaoDto)
    {
        var coluna = await _colunaRepositorio.ObterPorId(transacaoDto.IdDaColuna);
        ValidarSeAColunaExiste(coluna);

        var nome = Nome.Criar(transacaoDto.Nome);
        var quantia = Quantia.Criar(transacaoDto.Quantia);
        var classificacao = (Classificacao)transacaoDto.Classificacao;
        var transacao = new Transacao(nome, quantia, classificacao);

        coluna.AdicionarTransacoes(new List<Transacao> { transacao });
        await _colunaRepositorio.Atualizar(coluna);

        return transacao.ObterDto();
    }

    private void ValidarSeAColunaExiste(Coluna coluna)
    {
        new ExcecaoDeAplicacao()
            .QuandoEhNulo(coluna, MensagensDeExcecao.ColunaNaoEncontrada)
            .EntaoDispara();
    }
}
