using Aplicacao.DTOs.Quadros;
using Aplicacao.Mapeadores;
using Aplicacao.Quadros.Interfaces;
using Comum.Excecoes;
using Dominio.Usuarios;
using Infra.Repositorios.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplicacao.Quadros;

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
        ValidarSeOUsuarioExiste(usuario);

        return usuario.Quadros.ObterDto();
    }

    private void ValidarSeOUsuarioExiste(Usuario usuario)
    {
        new ExcecaoDeAplicacao()
            .QuandoEhNulo(usuario, MensagensDeExcecao.UsuarioNaoEncontrado)
            .EntaoDispara();
    }

}
