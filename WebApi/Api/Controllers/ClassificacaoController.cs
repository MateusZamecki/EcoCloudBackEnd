using Aplicacao.Classificacoes.Interfaces;
using Aplicacao.DTOs;
using Carter;

namespace Api.Controllers;

public class ClassificacaoController : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var rotaPadrao = app.MapGroup("classificacoes");

        rotaPadrao.MapGet("consultarTodas", ConsultarTodas);
        rotaPadrao.MapGet("consultar/{idDaColuna}", Consultar);

        rotaPadrao.MapPost("adicionar", Adicionar);

        rotaPadrao.MapPut("alterar", Alterar);

        rotaPadrao.MapDelete("excluir", Excluir);
    }

    private async Task<IResult> Consultar(int id, IConsultaClassificacao consultaClassificacao)
    {
        var classificacao = await consultaClassificacao.Consultar(id);
        return Results.Ok(classificacao);
    }

    public async Task<IResult> ConsultarTodas(IConsultaTodasAsClassificacoes consultaTodasAsClassificacoes)
    {
        var classificacoes = await consultaTodasAsClassificacoes.Consultar();
        return Results.Ok(classificacoes);
    }

    public async Task<IResult> Adicionar(ClassificacaoDto classificacaoDto, IAdicionaClassificacao adicionaClassificacao)
    {
        await adicionaClassificacao.Adicionar(classificacaoDto);
        return Results.Ok();
    }

    public async Task<IResult> Alterar(ClassificacaoDto classificacaoDto, IAlteraClassificacao alteraClassificacao)
    {
        await alteraClassificacao.Alterar(classificacaoDto);
        return Results.Ok();
    }

    public async Task<IResult> Excluir(int idDaClassificacao, IExcluiClassificacao excluiClassificacao)
    {
        await excluiClassificacao.Excluir(idDaClassificacao);
        return Results.Ok();
    }
}
