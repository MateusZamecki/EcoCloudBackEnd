using Aplicacao.DTOs;
using Aplicacao.Transacoes.Interfaces;
using Aplicacao.Mapeadores;
using Comum.Excecoes;
using Dominio.Transacoes;
using Dominio.ObjetosDeValor;
using Infra.Repositorios.Interfaces;
using System.Threading.Tasks;

namespace Aplicacao.Transacoes;

public class AlteraNomeDaTransacao : IAlteraNomeDaTransacao
{
    private readonly ITransacaoRepositorio _transacaoRepositorio;

    public AlteraNomeDaTransacao(ITransacaoRepositorio transacaoRepositorio)
    {
        _transacaoRepositorio = transacaoRepositorio;
    }

    public async Task<TransacaoDto> Alterar(string nome, int idDaTransacao)
    {
        var transacao = await _transacaoRepositorio.ObterPorId(idDaTransacao);
        ValidarDadosObrigatorios(transacao);

        var novoNome = Nome.Criar(nome);

        transacao.AlterarNome(novoNome);

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
