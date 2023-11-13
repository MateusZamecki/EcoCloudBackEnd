using Aplicacao.Colunas.Interfaces;
using Aplicacao.DTOs.Colunas;
using Aplicacao.Mapeadores;
using Comum.Excecoes;
using Dominio.Colunas;
using Dominio.ObjetosDeValor;
using Infra.Repositorios.Interfaces;
using System.Threading.Tasks;

namespace Aplicacao.Colunas;

public class AlteraNomeDaColuna : IAlteraNomeDaColuna
{
    private IColunaRepositorio _colunaRepositorio;

    public AlteraNomeDaColuna(IColunaRepositorio colunaRepositorio)
    {
        _colunaRepositorio = colunaRepositorio;
    }

    public async Task<ColunaDto> Alterar(ColunaDto colunaDto)
    {
        var novoNome = Nome.Criar(colunaDto.Nome);
        var coluna = await _colunaRepositorio.ObterPorId(colunaDto.Id);

        ValidarSeAColunaExiste(coluna);

        coluna.AlterarNome(novoNome);

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
