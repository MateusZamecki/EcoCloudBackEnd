using Aplicacao.Colunas.Interfaces;
using Aplicacao.DTOs.Colunas;
using Aplicacao.Mapeadores;
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

    public async Task<ColunaDto> Salvar(int idDaColuna)
    {
        var coluna = await _colunaRepositorio.ObterPorId(idDaColuna);
        ValidarSeAColunaExiste(coluna);

        coluna.SalvarTransacoesNoHistorico();

        await _colunaRepositorio.Atualizar(coluna);

        return coluna.ObterDto();
    }

    private void ValidarSeAColunaExiste(Coluna coluna)
    {
        new ExcecaoDeAplicacao()
            .QuandoEhNulo(coluna, MensagensDeExcecao.ColunaNaoEncontrada)
            .EntaoDispara();
    }
}
