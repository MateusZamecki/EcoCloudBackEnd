using Aplicacao.DTOs;
using System.Threading.Tasks;

namespace Aplicacao.Transacoes.Interfaces;

public interface IMovimentaTransacao
{
    Task Movimentar(MovimentacaoDeTransacaoDto movimentacaoDeTransacaoDto);
}
