using Aplicacao.DTOs.Quadros;
using Aplicacao.Quadros.Interfaces;
using Carter;

namespace WebApi.Controllers;

public class QuadroController : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var rotaPadrao = app.MapGroup("quadros");

        rotaPadrao.MapPost("adicionar", Adicionar);

        rotaPadrao.MapPut("alterarNome/{id}",AlterarNome);

        rotaPadrao.MapGet("consultar/{id}", Consultar);
        rotaPadrao.MapGet("consultarQuadrosDoUsuario/{idDoUsuario}", ConsultarQuadrosDoUsuario);

        rotaPadrao.MapDelete("excluir/{id}", Excluir);
    }

    public async Task<IResult> Adicionar(AdicionaQuadroDto adicionaQuadroDto, 
        IAdicionaQuadro adicionaQuadro)
    {
        await adicionaQuadro.Adicionar(adicionaQuadroDto);
        return Results.Ok();
    }

    public async Task<IResult> AlterarNome(string nome, int id,
        IAlteraNomeDoQuadro alteraNomeDoQuadro)
    {
        await alteraNomeDoQuadro.Alterar(nome, id);
        return Results.Ok();
    }

    public async Task<IResult> ConsultarQuadrosDoUsuario(int idDoUsuario, 
        IConsultaQuadrosDoUsuario consultaQuadrosDoUsuario)
    {
        var quadros = await consultaQuadrosDoUsuario.Consultar(idDoUsuario);
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
