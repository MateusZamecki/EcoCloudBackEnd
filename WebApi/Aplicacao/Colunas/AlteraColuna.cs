using Aplicacao.Colunas.Interfaces;
using Aplicacao.Configuracoes.Interfaces;
using Aplicacao.DTOs.Colunas;
using Comum.Excecoes;
using Dominio.Colunas;
using Dominio.ObjetosDeValor;
using Infra.Repositorios.Interfaces;
using System;
using System.Threading.Tasks;

namespace Aplicacao.Colunas;

public class AlteraColuna : IAlteraColuna
{
    private IColunaRepositorio _colunaRepositorio;
    private IAlteraConfiguracao _alteraConfiguracao;

    public AlteraColuna(IColunaRepositorio colunaRepositorio, 
        IAlteraConfiguracao alteraConfiguracao)
    {
        _colunaRepositorio = colunaRepositorio;
        _alteraConfiguracao = alteraConfiguracao;
    }

    public async Task Alterar(AlteraColunaDto alteraColunaDto)
    {
        var coluna = await _colunaRepositorio.ObterPorId(alteraColunaDto.Id);
        ValidarSeAColunaExiste(coluna);

        AlteraNome(coluna, alteraColunaDto);
        AlteraTipo(coluna, alteraColunaDto);
        AlteraClassificacao(coluna, alteraColunaDto);

        await _colunaRepositorio.Atualizar(coluna);
    }

    private void AlteraClassificacao(Coluna coluna, AlteraColunaDto alteraColunaDto)
    {
        if (alteraColunaDto.Configuracao != null) 
        {
            _alteraConfiguracao.Alterar(alteraColunaDto.Configuracao);
        }
    }

    private void AlteraTipo(Coluna coluna, AlteraColunaDto alteraColunaDto)
    {
        coluna.AlterarTipo((Tipo)alteraColunaDto.Tipo);
    }

    private void AlteraNome(Coluna coluna, AlteraColunaDto alteraColunaDto)
    {
        var novoNome = Nome.Criar(alteraColunaDto.Nome);
        coluna.AlterarNome(novoNome);
    }

    private void ValidarSeAColunaExiste(Coluna coluna)
    {
        new ExcecaoDeAplicacao()
            .QuandoEhNulo(coluna, MensagensDeExcecao.ColunaNaoEncontrada)
            .EntaoDispara();
    }
}
