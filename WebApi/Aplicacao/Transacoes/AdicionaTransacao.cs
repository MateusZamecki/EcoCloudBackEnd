using Aplicacao.Classificacoes.Interfaces;
using Aplicacao.DTOs;
using Aplicacao.DTOs.Transacoes;
using Aplicacao.Transacoes.Interfaces;
using Comum.Excecoes;
using Dominio.Colunas;
using Dominio.ObjetosDeValor;
using Dominio.Transacoes;
using Infra.Repositorios.Interfaces;
using System.Threading.Tasks;

namespace Aplicacao.Transacoes;

public class AdicionaTransacao : IAdicionaTransacao
{
    private IColunaRepositorio _colunaRepositorio;
    private IConsultaClassificacao _consultaClassificacao;

    public AdicionaTransacao(IColunaRepositorio colunaRepositorio,
        IConsultaClassificacao consultaClassificacao)
    {
        _colunaRepositorio = colunaRepositorio;
        _consultaClassificacao = consultaClassificacao;
    }

    public async Task Adicionar(AdicionaTransacaoDto transacaoDto)
    {
        var coluna = await _colunaRepositorio.ObterPorId(transacaoDto.IdDaColuna);
        ValidarSeAColunaExiste(coluna);

        var transacao = await CriarTransacao(transacaoDto);

        coluna.AdicionarTransacao(transacao);
        await _colunaRepositorio.Atualizar(coluna);
    }

    private async Task<Transacao> CriarTransacao(AdicionaTransacaoDto transacaoDto)
    {
        var nome = Nome.Criar(transacaoDto.Nome);
        var quantia = Quantia.Criar(transacaoDto.Quantia);

        var classificacao = await ObterClassificacao(transacaoDto.IdDaClassificacao);

        return new Transacao(nome, quantia, classificacao, transacaoDto.Descricao, transacaoDto.EhRecorrente);
    }

    private async Task<Classificacao> ObterClassificacao(int idDaClassificacao)
    {
        var classificacao = await _consultaClassificacao.ConsultarClassificacao(idDaClassificacao);
        return classificacao;
    }

    private void ValidarSeAColunaExiste(Coluna coluna)
    {
        new ExcecaoDeAplicacao()
            .QuandoEhNulo(coluna, MensagensDeExcecao.ColunaNaoEncontrada)
            .EntaoDispara();
    }
}
