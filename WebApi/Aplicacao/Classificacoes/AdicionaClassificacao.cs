using Aplicacao.Classificacoes.Interfaces;
using Aplicacao.DTOs;
using Aplicacao.Mapeadores;
using Dominio.ObjetosDeValor;
using Dominio.Transacoes;
using Infra.Repositorios.Interfaces;
using System.Threading.Tasks;

namespace Aplicacao.Classificacoes;

public class AdicionaClassificacao : IAdicionaClassificacao
{
    private IClassificacaoRepositorio _classificacaoRepositorio;

    public AdicionaClassificacao(IClassificacaoRepositorio classificacaoRepositorio)
    {
        _classificacaoRepositorio = classificacaoRepositorio;
    }

    public async Task Adicionar(ClassificacaoDto classificacaoDto)
    {
        var nomeDaClassificacao = Nome.Criar(classificacaoDto.Nome);
        var cor = classificacaoDto.Cor;
        var classificacao = new Classificacao(nomeDaClassificacao, cor);

        await _classificacaoRepositorio.Adicionar(classificacao);
    }
}
