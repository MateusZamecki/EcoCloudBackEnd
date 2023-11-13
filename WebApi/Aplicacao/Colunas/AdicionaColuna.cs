using Aplicacao.Colunas.Interfaces;
using Aplicacao.DTOs;
using Aplicacao.DTOs.Colunas;
using Aplicacao.Mapeadores;
using Comum.Excecoes;
using Dominio.Colunas;
using Dominio.ObjetosDeValor;
using Dominio.Quadros;
using Infra.Repositorios.Interfaces;
using System.Threading.Tasks;

namespace Aplicacao.Colunas;

public class AdicionaColuna : IAdicionaColuna
{
    private IColunaRepositorio _colunaRepositorio;

    public AdicionaColuna(IColunaRepositorio colunaRepositorio)
    {
        _colunaRepositorio = colunaRepositorio;
    }

    public async Task<ColunaDto> Adicionar(ColunaDto colunaDto)
    {
        var nome = Nome.Criar(colunaDto.Nome);
        var tipo = (Tipo)colunaDto.Tipo;
        var coluna = new Coluna(nome, tipo);

        AdicionarColuna(coluna, colunaDto.Configuracao);

        await _colunaRepositorio.Adicionar(coluna);

        return coluna.ObterDto();
    }

    private void AdicionarColuna(Coluna coluna, ConfiguracaoDto configuracaoDto)
    {
        if (configuracaoDto != null)
        {
            var configuracao = new Configuracao(configuracaoDto.IntervaloDeDias);
            coluna.AdicionarConfiguracao(configuracao);
        }
    }

    private void ValidarSeAColunaExiste(Quadro quadro)
    {
        new ExcecaoDeAplicacao()
            .QuandoEhNulo(quadro, MensagensDeExcecao.QuadroNaoEncontrado)
            .EntaoDispara();
    }
}
