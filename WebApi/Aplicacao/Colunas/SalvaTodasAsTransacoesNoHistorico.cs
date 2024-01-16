using Aplicacao.Colunas.Interfaces;
using Comum.Excecoes;
using Dominio.Colunas;
using Infra.Repositorios.Interfaces;
using System.Threading.Tasks;

namespace Aplicacao.Colunas;

public class SalvaTodasAsTransacoesNoHistorico : ISalvaTodasAsTransacoesNoHistorico
{
    private readonly IColunaRepositorio _colunaRepositorio;

    public SalvaTodasAsTransacoesNoHistorico(IColunaRepositorio colunaRepositorio)
    {
        _colunaRepositorio = colunaRepositorio;
    }

    public async Task Salvar(int idDaColuna)
    {
        var coluna = await _colunaRepositorio.ObterPorId(idDaColuna);
        ValidarSeAColunaExiste(coluna);

        coluna.SalvarTransacoesNoHistorico();

        await _colunaRepositorio.Atualizar(coluna);
    }

    private void ValidarSeAColunaExiste(Coluna coluna)
    {
        new ExcecaoDeAplicacao()
            .QuandoEhNulo(coluna, MensagensDeExcecao.ColunaNaoEncontrada)
            .EntaoDispara();
    }
}
