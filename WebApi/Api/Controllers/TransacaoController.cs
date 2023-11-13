using Aplicacao.DTOs;
using Aplicacao.Transacoes.Interfaces;
using Carter;

namespace WebApi.Controllers;

public class TransacaoController : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var rotaPadrao = app.MapGroup("transacoes");

        rotaPadrao.MapPost("adicionar", Adicionar);

        rotaPadrao.MapPut("alterarNome", AlterarNome);
        rotaPadrao.MapPut("atualizarQuantia", AtualizarQuantia);
        rotaPadrao.MapPut("desativar/{id}", Desativar);
        rotaPadrao.MapPut("movimentar", Movimentar);

        rotaPadrao.MapDelete("excluir", Excluir);
    }

    public async Task<IResult> Adicionar(TransacaoDto transacaoDto, IAdicionaTransacao adicionaTransacao)
    {
        var transacao = await adicionaTransacao.Adicionar(transacaoDto);
        return Results.Ok(transacao);
    }

    public async Task<IResult> AtualizarQuantia(TransacaoDto transacaoDto, IAtualizaQuantia atualizaQuantia)
    {
        var transacao = await atualizaQuantia.Atualizar(transacaoDto);
        return Results.Ok(transacao);
    }

    public async Task<IResult> AlterarNome(TransacaoDto transacaoDto, IAlteraNomeDaTransacao alteraNomeDaTransacao)
    {
        var transacao = await alteraNomeDaTransacao.Alterar(transacaoDto.Nome, transacaoDto.Id);
        return Results.Ok(transacao);
    }

    public async Task<IResult> Excluir(int idDaTranscao, int idDaColuna, IExcluiTransacao excluiTransacao)
    {
        await excluiTransacao.Excluir(idDaTranscao, idDaColuna);
        return Results.Ok();
    }

    private async Task<IResult> Desativar(int id, int idDaColuna, IDesativaTransacao desativaTransacao)
    {
        var transacaos = await desativaTransacao.Desativar(id, idDaColuna);
        return Results.Ok(transacaos);
    }

    private async Task<IResult> Movimentar(MovimentacaoDeTransacaoDto movimentacaoDeTransacaoDto, IMovimentaTransacao movimentaTransacao)
    {
        await movimentaTransacao.Movimentar(movimentacaoDeTransacaoDto);
        return Results.Ok();
    }
}
