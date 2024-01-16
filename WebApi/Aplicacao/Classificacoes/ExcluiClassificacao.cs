using Aplicacao.Classificacoes.Interfaces;
using Comum.Excecoes;
using Dominio.Transacoes;
using Infra.Repositorios.Interfaces;
using System.Threading.Tasks;

namespace Aplicacao.Classificacoes;

public class ExcluiClassificacao : IExcluiClassificacao
{
    private readonly IClassificacaoRepositorio _classificacaoRepositorio;

    public ExcluiClassificacao(IClassificacaoRepositorio classificacaoRepositorio)
    {
        _classificacaoRepositorio = classificacaoRepositorio;
    }

    public async Task Excluir(int idDaClassificacao)
    {
        var classificacao = await _classificacaoRepositorio.ObterPorId(idDaClassificacao);
        ValidarSeAClassificacaoExiste(classificacao);

        await _classificacaoRepositorio.Excluir(idDaClassificacao);
    }

    private void ValidarSeAClassificacaoExiste(Classificacao classificacao)
    {
        new ExcecaoDeAplicacao()
            .QuandoEhNulo(classificacao, MensagensDeExcecao.ClassificacaoNaoEncontrada)
            .EntaoDispara();
    }
}
