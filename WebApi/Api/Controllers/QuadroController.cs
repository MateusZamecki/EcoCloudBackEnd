using Aplicacao.Quadros.Interfaces;
using Carter;

namespace WebApi.Controllers;

public class QuadroController : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var rotaPadrao = app.MapGroup("quadros");

        rotaPadrao.MapPost("adicionar/{idDoUsuario}", Adicionar);

        rotaPadrao.MapPut("alterarNome/{id}",AlterarNome);

        rotaPadrao.MapGet("consultar/{id}", Consultar);
        rotaPadrao.MapGet("consultarPorUsuario/{idDoUsuario}", ConsultarPorUsuario);

        rotaPadrao.MapDelete("excluir/{id}", Excluir);
    }

    public async Task<IResult> Adicionar(string nome, int idDoUsuario, 
        IAdicionaQuadro adicionaQuadro)
    {
        var quadro = await adicionaQuadro.Adicionar(nome, idDoUsuario);
        return Results.Ok(quadro);
    }

    public async Task<IResult> AlterarNome(string nome, int id,
        IAlteraNomeDoQuadro alteraNomeDoQuadro)
    {
        var quadro = await alteraNomeDoQuadro.Alterar(nome, id);
        return Results.Ok(quadro);
    }

    public async Task<IResult> ConsultarPorUsuario(int idDoUsuario, 
        IConsultaQuadro consultaQuadro)
    {
        var quadros = await consultaQuadro.ConsultarPorUsuario(idDoUsuario);
        return Results.Ok(quadros);
    }

    public async Task<IResult> Consultar(int id,
        IConsultaQuadro consultaQuadro)
    {
        var quadro = await consultaQuadro.Consultar(id);
        return Results.Ok(quadro);
    }

    public async Task<IResult> Excluir(int id,
        IExcluiQuadro excluiQuadro)
    {
        await excluiQuadro.Excluir(id);
        return Results.Ok();
    }
}
