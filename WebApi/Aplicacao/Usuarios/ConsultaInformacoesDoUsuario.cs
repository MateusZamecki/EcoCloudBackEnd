using Aplicacao.DTOs;
using Aplicacao.Mapeadores;
using Aplicacao.Usuarios.Interfaces;
using Comum.Excecoes;
using Dominio.Usuarios;
using Infra.Repositorios.Interfaces;
using System.Threading.Tasks;

namespace Aplicacao.Usuarios;

public class ConsultaInformacoesDoUsuario : IConsultaInformacoesDoUsuario
{
    private IUsuarioRepositorio _usuarioRepositorio;

    public ConsultaInformacoesDoUsuario(IUsuarioRepositorio usuarioRepositorio)
    {
        _usuarioRepositorio = usuarioRepositorio;
    }

    public async Task<UsuarioDto> Consultar(int idDoUsuario)
    {
        var usuario = await _usuarioRepositorio.ObterPorId(idDoUsuario);
        ValidarSeOUsuarioExiste(usuario);

        return usuario.ObterDto();
    }

    private void ValidarSeOUsuarioExiste(Usuario usuario)
    {
        new ExcecaoDeAplicacao()
            .QuandoEhNulo(usuario, MensagensDeExcecao.UsuarioNaoEncontrado)
            .EntaoDispara();
    }
}
