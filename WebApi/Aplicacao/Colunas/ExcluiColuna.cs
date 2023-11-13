using Aplicacao.Colunas.Interfaces;
using Comum.Excecoes;
using Dominio.Colunas;
using Infra.Repositorios.Interfaces;
using System.Threading.Tasks;

namespace Aplicacao.Colunas;

public class ExcluiColuna : IExcluiColuna
{
    private IColunaRepositorio _colunaRepositorio;

    public ExcluiColuna(IColunaRepositorio colunaRepositorio)
    {
        _colunaRepositorio = colunaRepositorio;
    }

    public async Task Excluir(int idDaColuna)
    {
        var coluna = await _colunaRepositorio.ObterPorId(idDaColuna);

        ValidarSeAColunaExiste(coluna);

        await _colunaRepositorio.Excluir(coluna);
    }

    private void ValidarSeAColunaExiste(Coluna coluna)
    {
        new ExcecaoDeAplicacao()
            .QuandoEhNulo(coluna, MensagensDeExcecao.ColunaNaoEncontrada)
            .EntaoDispara();
    }
}
