using Aplicacao.Configuracoes.Interfaces;
using Aplicacao.DTOs.Colunas;
using Aplicacao.Mapeadores;
using Comum.Excecoes;
using Dominio.Colunas;
using Infra.Repositorios.Interfaces;
using System.Threading.Tasks;

namespace Aplicacao.Configuracoes;

public class AdicionaConfiguracaoNaColuna : IAdicionaConfiguracaoNaColuna
{
    private readonly IColunaRepositorio _colunaRepositorio;

    public AdicionaConfiguracaoNaColuna(IColunaRepositorio colunaRepositorio)
    {
        _colunaRepositorio = colunaRepositorio;
    }

    public async Task<ColunaDto> Adicionar(int intervaloDeDias, int idDaColuna)
    {
        var coluna = await _colunaRepositorio.ObterPorId(idDaColuna);
        ValidarSeAColunaExiste(coluna);

        AdicionarConfiguracaoNaColuna(coluna, intervaloDeDias);

        await _colunaRepositorio.Atualizar(coluna);

        return coluna.ObterDto();
    }

    private void AdicionarConfiguracaoNaColuna(Coluna coluna, int intervaloDeDias)
    {
        if (coluna.Configuracao is null)
        {
            var configuracao = new Configuracao(intervaloDeDias);
            coluna.AdicionarConfiguracao(configuracao);
            return;
        }
        coluna.Configuracao.AlterarIntervalo(intervaloDeDias);
    }

    private void ValidarSeAColunaExiste(Coluna coluna)
    {
        new ExcecaoDeAplicacao()
            .QuandoEhNulo(coluna, MensagensDeExcecao.ColunaNaoEncontrada)
            .EntaoDispara();
    }
}
