using Aplicacao.Colunas.Interfaces;
using Aplicacao.DTOs.Colunas;
using Aplicacao.Mapeadores;
using Comum.Excecoes;
using Dominio.Colunas;
using Infra.Repositorios.Interfaces;
using System.Threading.Tasks;

namespace Aplicacao.Colunas;

public class ConsultaColuna : IConsultaColuna
{
    private readonly IColunaRepositorio _colunaRepositorio;

    public ConsultaColuna(IColunaRepositorio colunaRepositorio)
    {
        _colunaRepositorio = colunaRepositorio;
    }

    public async Task<ColunaDto> Consultar(int id)
    {
        var coluna = await _colunaRepositorio.ObterPorId(id);
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
