using Aplicacao.DTOs;
using Aplicacao.Mapeadores;
using Aplicacao.Usuarios.Interfaces;
using Comum.Excecoes;
using Dominio.Usuarios;
using Infra.Repositorios.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplicacao.Usuarios;

public class ConsultaQuadrosDoUsuario : IConsultaQuadrosDoUsuario
{
    private IUsuarioRepositorio _usuarioRepositorio;

    public ConsultaQuadrosDoUsuario(IUsuarioRepositorio usuarioRepositorio)
    {
        _usuarioRepositorio = usuarioRepositorio;
    }

    public async Task<List<QuadroDto>> Consultar(int idDoUsuario)
    {
        var usuario = await _usuarioRepositorio.ObterPorId(idDoUsuario);

        ValidarSeUsuarioExiste(usuario);

        return usuario.Quadros.ObterDto();
    }

    private void ValidarSeUsuarioExiste(Usuario usuario)
    {
        new ExcecaoDeAplicacao()
            .QuandoEhNulo(usuario, MensagensDeExcecao.UsuarioNaoEncontrado)
            .EntaoDispara();
    }
}
