using Aplicacao.DTOs;
using Aplicacao.Mapeadores;
using Aplicacao.Quadros.Interfaces;
using Comum.Excecoes;
using Dominio.ObjetosDeValor;
using Dominio.Quadros;
using Infra.Repositorios.Interfaces;
using System;
using System.Threading.Tasks;

namespace Aplicacao.Quadros;

public class AlteraNomeDoQuadro : IAlteraNomeDoQuadro
{
    private IQuadroRepositorio _quadroRepositorio;

    public AlteraNomeDoQuadro(IQuadroRepositorio quadroRepositorio)
    {
        _quadroRepositorio = quadroRepositorio;
    }

    public async Task<QuadroDto> Alterar(string nome, int idDoQuadro)
    {
        var novoNome = Nome.Criar(nome);
        var quadro = await _quadroRepositorio.ObterPorId(idDoQuadro);

        ValidarSeOQuadroExiste(quadro);

        quadro.AlterarNome(novoNome);

        await _quadroRepositorio.Atualizar(quadro);

        return quadro.ObterDto();
    }

    private void ValidarSeOQuadroExiste(Quadro quadro)
    {
        new ExcecaoDeAplicacao()
            .QuandoEhNulo(quadro, MensagensDeExcecao.QuadroNaoEncontrado)
            .EntaoDispara();
    }
}
