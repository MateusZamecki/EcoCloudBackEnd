using Aplicacao.Colunas.Interfaces;
using Aplicacao.Configuracoes.Interfaces;
using Aplicacao.DTOs.Colunas;
using Comum.Excecoes;
using Dominio.Colunas;
using Dominio.ObjetosDeValor;
using Dominio.Quadros;
using Infra.Repositorios.Interfaces;
using System.Threading.Tasks;

namespace Aplicacao.Colunas;

public class AdicionaColuna : IAdicionaColuna
{
    private IQuadroRepositorio _quadroRepositorio;
    private IConsultaConfiguracao _consultaConfiguracao;

    public AdicionaColuna(IQuadroRepositorio quadroRepositorio, 
        IConsultaConfiguracao consultaConfiguracao)
    {
        _quadroRepositorio = quadroRepositorio;
        _consultaConfiguracao = consultaConfiguracao;
    }

    public async Task Adicionar(AdicionaColunaDto adicionaColunaDto)
    {
        var quadro = await _quadroRepositorio.ObterPorId(adicionaColunaDto.IdDoQuadro);
        ValidarSeOQuadroExiste(quadro);

        var nome = Nome.Criar(adicionaColunaDto.Nome);
        var tipo = (Tipo)adicionaColunaDto.Tipo;
        var coluna = new Coluna(nome, tipo);

        await AdicionarConfiguracaoNaColuna(coluna, adicionaColunaDto.IdDaConfiguracao);

        quadro.AdicionarColuna(coluna);
        await _quadroRepositorio.Atualizar(quadro);
    }

    private async Task AdicionarConfiguracaoNaColuna(Coluna coluna, int idDaConfiguracao)
    {
        if (idDaConfiguracao == 0)
            return;

        var configuracao = await _consultaConfiguracao.ConsultarEntidade(idDaConfiguracao);
        coluna.AdicionarConfiguracao(configuracao);
    }

    private void ValidarSeOQuadroExiste(Quadro quadro)
    {
        new ExcecaoDeAplicacao()
            .QuandoEhNulo(quadro, MensagensDeExcecao.QuadroNaoEncontrado)
            .EntaoDispara();
    }
}
