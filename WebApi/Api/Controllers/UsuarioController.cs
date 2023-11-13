using Aplicacao.Usuarios.Interfaces;
using Carter;
using Dominio.ObjetosDeValor;
using Dominio.Usuarios;
using Infra.Repositorios.Interfaces;

namespace WebApi.Controllers;

public class UsuarioController : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var rotaPadrao = app.MapGroup("usuarios");

        rotaPadrao.MapGet("obter/{id}", ObterPorId);
        rotaPadrao.MapPost("adicionarUsuario", Adicionar);
    }

    public async Task<IResult> ObterPorId(int idDoUsuario, 
        IConsultaInformacoesDoUsuario consultaInformacoesDoUsuario)
    {
        var usuario = await consultaInformacoesDoUsuario.Consultar(idDoUsuario);
        return Results.Ok(usuario);
    }

    public async Task<IResult> Adicionar(IUsuarioRepositorio usuarioRepositorio)
    {
        await usuarioRepositorio.Adicionar(new Usuario(Nome.Criar("Mateus"), Email.Criar("email@gmail.com")));
        return Results.Ok();
    }
}
