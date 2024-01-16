using Aplicacao.DTOs.Transacoes;
using System.Threading.Tasks;

namespace Aplicacao.Transacoes.Interfaces;

public interface IAlteraTransacao
{
    Task Alterar(AlteraTransacaoDto transacaoDto);
}
