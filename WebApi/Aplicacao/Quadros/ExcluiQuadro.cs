using Aplicacao.Quadros.Interfaces;
using Comum.Excecoes;
using Infra.Repositorios.Interfaces;
using System;
using System.Threading.Tasks;

namespace Aplicacao.Quadros;

public class ExcluiQuadro : IExcluiQuadro
{
    private IQuadroRepositorio _quadroRepositorio;

    public ExcluiQuadro(IQuadroRepositorio quadroRepositorio)
    {
        _quadroRepositorio = quadroRepositorio;
    }

    public async Task Excluir(int idDoQuadro)
    {
        ValidarDadosObrigatorios(idDoQuadro);
        await _quadroRepositorio.Excluir(idDoQuadro);
    }

    private void ValidarDadosObrigatorios(int idDoQuadro)
    {
        new ExcecaoDeAplicacao()
            .Quando(idDoQuadro <= 0, MensagensDeExcecao.QuadroNaoEncontrado)
            .EntaoDispara();
    }
}
