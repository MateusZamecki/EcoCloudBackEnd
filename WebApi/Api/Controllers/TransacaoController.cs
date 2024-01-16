using Aplicacao.DTOs;
using Aplicacao.DTOs.Transacoes;
using Aplicacao.Transacoes.Interfaces;
using Carter;

namespace WebApi.Controllers;

public class TransacaoController : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var rotaPadrao = app.MapGroup("transacoes");

        rotaPadrao.MapPost("adicionar", Adicionar);

        rotaPadrao.MapPut("alterar", Alterar);
        rotaPadrao.MapPut("desativar/{id}", Desativar);
        rotaPadrao.MapPut("movimentar", Movimentar);

        rotaPadrao.MapDelete("excluir", Excluir);
    }

    public async Task<IResult> Adicionar(AdicionaTransacaoDto transacaoDto, IAdicionaTransacao adicionaTransacao)
    {
        await adicionaTransacao.Adicionar(transacaoDto);
        return Results.Ok();
    }

    public async Task<IResult> Alterar(AlteraTransacaoDto transacaoDto, IAlteraTransacao alteraTransacao)
    {
        await alteraTransacao.Alterar(transacaoDto);
        return Results.Ok();
    }

    public async Task<IResult> Excluir(int idDaTranscao, int idDaColuna, IExcluiTransacao excluiTransacao)
    {
        await excluiTransacao.Excluir(idDaTranscao, idDaColuna);
        return Results.Ok();
    }

    private async Task<IResult> Desativar(int id, int idDaColuna, IDesativaTransacao desativaTransacao)
    {
        await desativaTransacao.Desativar(id, idDaColuna);
        return Results.Ok();
    }

    private async Task<IResult> Movimentar(MovimentacaoDeTransacaoDto movimentacaoDeTransacaoDto, IMovimentaTransacao movimentaTransacao)
    {
        await movimentaTransacao.Movimentar(movimentacaoDeTransacaoDto);
        return Results.Ok();
    }
}
