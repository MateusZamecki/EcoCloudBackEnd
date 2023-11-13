using Aplicacao.Colunas.Interfaces;
using Aplicacao.DTOs.Colunas;
using Aplicacao.Mapeadores;
using Comum.Excecoes;
using Dominio.Colunas;
using Infra.Repositorios.Interfaces;
using System.Threading.Tasks;

namespace Aplicacao.Colunas;

public class ConsultaHistorico : IConsultaHistorico
{
    private readonly IColunaRepositorio _colunaRepositorio;

    public ConsultaHistorico(IColunaRepositorio colunaRepositorio)
    {
        _colunaRepositorio = colunaRepositorio;
    }

    public async Task<ColunaDto> Consultar(int idDaColuna)
    {
        var coluna = await _colunaRepositorio.ConsultarHistorico(idDaColuna);
        ValidarSeAColunaExiste(coluna);

        return coluna.ObterDto();
    }

    private void ValidarSeAColunaExiste(Coluna coluna)
    {
        new ExcecaoDeAplicacao()
            .QuandoEhNulo(coluna, MensagensDeExcecao.ColunaNaoEncontrada)
            .EntaoDispara();
    }
}
