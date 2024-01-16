using Aplicacao.DTOs.Quadros;
using Aplicacao.Mapeadores;
using Aplicacao.Quadros.Interfaces;
using Comum.Excecoes;
using Dominio.Quadros;
using Dominio.Usuarios;
using Infra.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicacao.Quadros;

public class ConsultaQuadro : IConsultaQuadro
{
    private IQuadroRepositorio _quadroRepositorio;

    public ConsultaQuadro(IQuadroRepositorio quadroRepositorio)
    {
        _quadroRepositorio = quadroRepositorio;
    }

    public async Task<QuadroDto> Consultar(int idDoQuadro)
    {
        var quadro = await _quadroRepositorio.ObterPorId(idDoQuadro);
        ValidarSeOQuadroExiste(quadro);
        return quadro.ObterInformacoesDoQuadroDto();
    }

    private void ValidarSeOQuadroExiste(Quadro quadro)
    {
        new ExcecaoDeAplicacao()
            .QuandoEhNulo(quadro, MensagensDeExcecao.QuadroNaoEncontrado)
            .EntaoDispara();
    }
}
