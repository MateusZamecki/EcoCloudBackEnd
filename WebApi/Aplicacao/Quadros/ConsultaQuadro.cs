using Aplicacao.DTOs;
using Aplicacao.Mapeadores;
using Aplicacao.Quadros.Interfaces;
using Comum.Excecoes;
using Dominio.Quadros;
using Dominio.Usuarios;
using Infra.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplicacao.Quadros;

public class ConsultaQuadro : IConsultaQuadro
{
    private IQuadroRepositorio _quadroRepositorio;
    private IUsuarioRepositorio _usuarioRepositorio;

    public ConsultaQuadro(IQuadroRepositorio quadroRepositorio, IUsuarioRepositorio usuarioRepositorio)
    {
        _quadroRepositorio = quadroRepositorio;
        _usuarioRepositorio = usuarioRepositorio;
    }

    public async Task<QuadroDto> Consultar(int idDoQuadro)
    {
        var quadro = await _quadroRepositorio.ObterPorId(idDoQuadro);
        ValidarSeOQuadroExiste(quadro);
        return quadro.ObterDto();
    }

    public async Task<List<QuadroDto>> ConsultarPorUsuario(int idDoUsuario)
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

    private void ValidarSeOQuadroExiste(Quadro quadro)
    {
        new ExcecaoDeAplicacao()
            .QuandoEhNulo(quadro, MensagensDeExcecao.QuadroNaoEncontrado)
            .EntaoDispara();
    }
}
