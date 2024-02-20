using Aplicacao.Configuracoes.Interfaces;
using Aplicacao.DTOs.Configuracao;
using Carter;

namespace WebApi.Controllers;

public class ConfiguracaoController : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var rotaPadrao = app.MapGroup("configuracoes");

        rotaPadrao.MapPost("adicionar/{idDaColuna}", Adicionar);
        rotaPadrao.MapPost("adicionarNoQuadro/{idDoQuadro}", AdicionarNoQuadro);

        rotaPadrao.MapGet("consultar/{id}", Consultar);

        rotaPadrao.MapPut("alterarIntervalo", AlterarIntervalo);

        rotaPadrao.MapDelete("excluir/{id}", ExcluirConfiguracao);
    }

    private async Task<IResult> Consultar(int id, IConsultaConfiguracao consultaConfiguracao)
    {
        var configuracao = await consultaConfiguracao.Consultar(id);
        return Results.Ok(configuracao);
    }

    public async Task<IResult> Adicionar(int intervaloDeDias, int idDaColuna, 
        IAdicionaConfiguracaoNaColuna adicionaConfiguracaoNaColuna)
    {
        var coluna = await adicionaConfiguracaoNaColuna.Adicionar(intervaloDeDias, idDaColuna);
        return Results.Ok(coluna);
    }

    public async Task<IResult> AlterarIntervalo(ConfiguracaoDto configuracaoDto, 
        IAlteraConfiguracao alteraIntervaloDaConfiguracao)
    {
        await alteraIntervaloDaConfiguracao.Alterar(configuracaoDto);
        return Results.Ok();
    }

    public async Task<IResult> ExcluirConfiguracao(int id, 
        IExcluiConfiguracao excluiConfiguracao)
    {
        await excluiConfiguracao.Excluir(id);
        return Results.Ok();
    }

    public async Task<IResult> AdicionarNoQuadro(int intervaloDeDias, int idDoQuadro,
        IAdicionaConfiguracaoNoQuadro adicionaConfiguracaoNoQuadro)
    {
        var coluna = await adicionaConfiguracaoNoQuadro.Adicionar(intervaloDeDias, idDoQuadro);
        return Results.Ok(coluna);
    }
}
