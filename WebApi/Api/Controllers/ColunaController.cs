﻿using Aplicacao.Colunas.Interfaces;
using Aplicacao.DTOs.Colunas;
using Carter;

namespace WebApi.Controllers;

public class ColunaController : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var rotaPadrao = app.MapGroup("colunas");
        
        rotaPadrao.MapPost("adicionar", Adicionar);

        rotaPadrao.MapPut("alterarNome", AlterarNome);
        rotaPadrao.MapPut("salvarTransacoes/{idDaColuna}", SalvarTransacoes);

        rotaPadrao.MapGet("consultarHistorico/{idDaColuna}", ConsultarHistorico);
        rotaPadrao.MapGet("consultar/{idDaColuna}", Consultar);

        rotaPadrao.MapDelete("excluir", Excluir);
    }

    public async Task<IResult> Adicionar(ColunaDto colunaDto, IAdicionaColuna adicionaColuna)
    {
        var coluna = await adicionaColuna.Adicionar(colunaDto);
        return Results.Ok(coluna);
    }

    public async Task<IResult> AlterarNome(ColunaDto colunaDto, IAlteraNomeDaColuna alteraNomeDaColuna)
    {
        var coluna = await alteraNomeDaColuna.Alterar(colunaDto);
        return Results.Ok(coluna);
    }

    public async Task<IResult> Excluir(int idDaColuna, IExcluiColuna excluirColuna)
    {
        await excluirColuna.Excluir(idDaColuna);
        return Results.Ok();
    }

    public async Task<IResult> SalvarTransacoes(int idDaColuna, 
        ISalvaTodasAsTransacoesNoHistorico salvaTodasAsTransacoesNoHistorico)
    {
        var coluna = await salvaTodasAsTransacoesNoHistorico.Salvar(idDaColuna);
        return Results.Ok(coluna);
    }

    public async Task<IResult> ConsultarHistorico(int idDaColuna, IConsultaHistorico consultaHistorico)
    {
        var coluna = await consultaHistorico.Consultar(idDaColuna);
        return Results.Ok(coluna);
    }

    public async Task<IResult> Consultar(int idDaColuna, IConsultaColuna consultaColuna)
    {
        var coluna = await consultaColuna.Consultar(idDaColuna);
        return Results.Ok(coluna);
    }
}