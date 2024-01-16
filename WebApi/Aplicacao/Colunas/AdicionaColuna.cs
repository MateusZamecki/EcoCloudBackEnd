using Aplicacao.Colunas.Interfaces;
using Aplicacao.DTOs;
using Aplicacao.DTOs.Colunas;
using Aplicacao.Mapeadores;
using Comum.Excecoes;
using Dominio.Colunas;
using Dominio.ObjetosDeValor;
using Dominio.Quadros;
using Infra.Repositorios.Interfaces;
using System;
using System.Threading.Tasks;

namespace Aplicacao.Colunas;

public class AdicionaColuna : IAdicionaColuna
{
    private IQuadroRepositorio _quadroRepositorio;

    public AdicionaColuna(IQuadroRepositorio quadroRepositorio)
    {
        _quadroRepositorio = quadroRepositorio;
    }

    public async Task Adicionar(ColunaDto colunaDto)
    {
        var quadro = await _quadroRepositorio.ObterPorId(colunaDto.IdDoQuadro);
        ValidarSeOQuadroExiste(quadro);

        var nome = Nome.Criar(colunaDto.Nome);
        var tipo = (Tipo)colunaDto.Tipo;
        var coluna = new Coluna(nome, tipo);

        AdicionarColuna(coluna, colunaDto.Configuracao);

        quadro.AdicionarColuna(coluna);
        await _quadroRepositorio.Atualizar(quadro);
    }


    private void AdicionarColuna(Coluna coluna, ConfiguracaoDto configuracaoDto)
    {
        if (configuracaoDto != null)
        {
            var configuracao = new Configuracao(configuracaoDto.IntervaloDeDias);
            coluna.AdicionarConfiguracao(configuracao);
        }
    }

    private void ValidarSeOQuadroExiste(Quadro quadro)
    {
        new ExcecaoDeAplicacao()
            .QuandoEhNulo(quadro, MensagensDeExcecao.QuadroNaoEncontrado)
            .EntaoDispara();
    }
}
