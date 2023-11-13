using Aplicacao.DTOs;
using Aplicacao.Transacoes.Interfaces;
using Aplicacao.Mapeadores;
using Comum.Excecoes;
using Dominio.Transacoes;
using Dominio.ObjetosDeValor;
using Infra.Repositorios.Interfaces;
using System;
using System.Threading.Tasks;

namespace Aplicacao.Transacoes;

public class AtualizaQuantia : IAtualizaQuantia
{
    private ITransacaoRepositorio _transacaoRepositorio;

    public AtualizaQuantia(ITransacaoRepositorio transacaoRepositorio)
    {
        _transacaoRepositorio = transacaoRepositorio;
    }

    public async Task<TransacaoDto> Atualizar(TransacaoDto transacaoDto)
    {
        var transacao = await _transacaoRepositorio.ObterPorId(transacaoDto.Id);
        ValidarDadosObrigatorios(transacao);

        var quantia = Quantia.Criar(transacaoDto.Quantia);
        transacao.AtualizarQuantia(quantia);

        await _transacaoRepositorio.Atualizar(transacao);

        return transacao.ObterDto();
    }

    private void ValidarDadosObrigatorios(Transacao transacao)
    {
        new ExcecaoDeAplicacao()
            .QuandoEhNulo(transacao, MensagensDeExcecao.TransacaoNaoEncontrada)
            .EntaoDispara();
    }
}
