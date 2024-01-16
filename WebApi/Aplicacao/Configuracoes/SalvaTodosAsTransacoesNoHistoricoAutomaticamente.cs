using Aplicacao.Configuracoes.Interfaces;
using Dominio.Transacoes;
using Infra.Repositorios.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplicacao.Configuracoes;

public class SalvaTodosAsTransacoesNoHistoricoAutomaticamente : ISalvaTodasAsTransacoesNoHistoricoAutomaticamente
{
    private readonly IColunaRepositorio _colunaRepositorio;
    private readonly IConfiguracaoRepositorio _configuracaoRepositorio;

    public SalvaTodosAsTransacoesNoHistoricoAutomaticamente(IColunaRepositorio colunaRepositorio, 
        IConfiguracaoRepositorio configuracaoRepositorio)
    {
        _colunaRepositorio = colunaRepositorio;
        _configuracaoRepositorio = configuracaoRepositorio;
    }

    public async Task Salvar()
    {
        var colunas = await _colunaRepositorio.Obter();

        foreach (var coluna in colunas)
        {
            if (coluna.Configuracao != null && coluna.Configuracao.EhParaSalvar)
            {
                var configuracao = coluna.Configuracao;

                coluna.SalvarTransacoesNoHistorico();
                coluna.Transacoes
                    .ForEach(transacao =>
                    {
                        if (transacao.EhRecorrente)
                        {
                            var transacaoRecorrente = new Transacao(
                                transacao.Nome, 
                                transacao.Quantia, 
                                transacao.Classificacao,
                                transacao.Descricao,
                                transacao.EhRecorrente);
                            coluna.AdicionarTransacao(transacaoRecorrente);
                        }
                    });

                configuracao.AtualizarData();
                await _colunaRepositorio.Atualizar(coluna);
                await _configuracaoRepositorio.Atualizar(configuracao);
            }
        }
    }
}
