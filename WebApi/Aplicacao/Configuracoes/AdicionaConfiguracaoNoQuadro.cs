using Aplicacao.Configuracoes.Interfaces;
using Aplicacao.DTOs;
using Aplicacao.Mapeadores;
using Comum.Excecoes;
using Dominio.Colunas;
using Dominio.Quadros;
using Infra.Repositorios.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplicacao.Configuracoes;

public class AdicionaConfiguracaoNoQuadro : IAdicionaConfiguracaoNoQuadro
{
    private readonly IQuadroRepositorio _quadroRepositorio;
    private readonly IConfiguracaoRepositorio _configuracaoRepositorio;

    public AdicionaConfiguracaoNoQuadro(IQuadroRepositorio quadroRepositorio, 
        IConfiguracaoRepositorio configuracaoRepositorio)
    {
        _quadroRepositorio = quadroRepositorio;
        _configuracaoRepositorio = configuracaoRepositorio;
    }

    public async Task<QuadroDto> Adicionar(int intervaloDeDias, int idDoQuadro)
    {
        var quadro = await _quadroRepositorio.ObterPorId(idDoQuadro);
        ValidaSeQuadroExiste(quadro);

        AdicionarConfiguracaoEmTodasAsColunas(intervaloDeDias, quadro.Colunas);

        await _quadroRepositorio.Atualizar(quadro);

        return quadro.ObterDto();
    }

    private void AdicionarConfiguracaoEmTodasAsColunas(int intervaloDeDias, List<Coluna> colunas)
    {
        foreach (var coluna in colunas)
        {
            if (coluna.Configuracao is null)
            {
                var configuracao = new Configuracao(intervaloDeDias);
                coluna.AdicionarConfiguracao(configuracao);
            }
            else
            {
                coluna.Configuracao.AlterarIntervalo(intervaloDeDias);
            }
        }
    }

    private void ValidaSeQuadroExiste(Quadro quadro)
    {
        new ExcecaoDeAplicacao()
            .QuandoEhNulo(quadro, MensagensDeExcecao.QuadroNaoEncontrado)
            .EntaoDispara();
    }
}
