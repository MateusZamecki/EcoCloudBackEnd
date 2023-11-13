using Aplicacao.DTOs;
using Aplicacao.Mapeadores;
using Aplicacao.Quadros.Interfaces;
using Comum.Excecoes;
using Dominio.ObjetosDeValor;
using Dominio.Quadros;
using Dominio.Usuarios;
using Infra.Repositorios.Interfaces;
using System.Threading.Tasks;

namespace Aplicacao.Quadros;

public class AdicionaQuadro : IAdicionaQuadro
{
    private IUsuarioRepositorio _usuarioRepositorio;

    public AdicionaQuadro(IUsuarioRepositorio usuarioRepositorio)
    {
        _usuarioRepositorio = usuarioRepositorio;
    }

    public async Task<QuadroDto> Adicionar(string nomeDoQuadro, int idDoUsuario)
    {
        var usuario = await _usuarioRepositorio.ObterPorId(idDoUsuario);
        ValidarSeOUsuarioExiste(usuario);

        var nome = Nome.Criar(nomeDoQuadro);
        var quadro = new Quadro(nome);

        usuario.AdicionarQuadro(quadro);
        await _usuarioRepositorio.Atualizar(usuario);

        return quadro.ObterDto();
    }

    private void ValidarSeOUsuarioExiste(Usuario usuario)
    {
        new ExcecaoDeAplicacao()
            .QuandoEhNulo(usuario, MensagensDeExcecao.UsuarioNaoEncontrado)
            .EntaoDispara();
    }
}
