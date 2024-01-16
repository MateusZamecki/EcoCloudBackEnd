using Aplicacao.DTOs.Quadros;
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

    public async Task Adicionar(AdicionaQuadroDto adicionaQuadroDto)
    {
        var usuario = await _usuarioRepositorio.ObterPorId(adicionaQuadroDto.IdDoUsuario);
        ValidarSeOUsuarioExiste(usuario);

        var nome = Nome.Criar(adicionaQuadroDto.Nome);
        var quadro = new Quadro(nome);

        usuario.AdicionarQuadro(quadro);
        await _usuarioRepositorio.Atualizar(usuario);
    }

    private void ValidarSeOUsuarioExiste(Usuario usuario)
    {
        new ExcecaoDeAplicacao()
            .QuandoEhNulo(usuario, MensagensDeExcecao.UsuarioNaoEncontrado)
            .EntaoDispara();
    }
}
