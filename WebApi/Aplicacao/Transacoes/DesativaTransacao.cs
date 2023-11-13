using Aplicacao.DTOs;
using Aplicacao.DTOs.Colunas;
using Aplicacao.Transacoes.Interfaces;
using Aplicacao.Mapeadores;
using Comum.Excecoes;
using Dominio.Colunas;
using Dominio.Transacoes;
using Infra.Repositorios;
using Infra.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicacao.Transacoes;

public class DesativaTransacao : IDesativaTransacao
{
    private readonly IColunaRepositorio _colunaRepositorio;
    private readonly ITransacaoRepositorio _transacaoRepositorio;

    public DesativaTransacao(IColunaRepositorio colunaRepositorio, 
        ITransacaoRepositorio transacaoRepositorio)
    {
        _colunaRepositorio = colunaRepositorio;
        _transacaoRepositorio = transacaoRepositorio;
    }

    public async Task<List<TransacaoDto>> Desativar(int id, int idDaColuna)
    {
        var coluna = await _colunaRepositorio.ObterPorId(idDaColuna);
        ValidarSeAColunaExiste(coluna);

        var transacao = coluna.Transacoes.FirstOrDefault(transacao => transacao.Id == id);
        ValidarSeATransacaoExiste(transacao);
        transacao.Desativar();

        await _transacaoRepositorio.Atualizar(transacao);

        return coluna.Transacoes.ObterDto();
    }

    private void ValidarSeATransacaoExiste(Transacao transacao)
    {
        new ExcecaoDeAplicacao()
            .QuandoEhNulo(transacao, MensagensDeExcecao.TransacaoNaoEncontrada)
            .EntaoDispara();
    }

    private void ValidarSeAColunaExiste(Coluna coluna)
    {
        new ExcecaoDeAplicacao()
            .QuandoEhNulo(coluna, MensagensDeExcecao.ColunaNaoEncontrada)
            .EntaoDispara();
    }
}
