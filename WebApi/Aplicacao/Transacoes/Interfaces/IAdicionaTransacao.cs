using Aplicacao.DTOs.Transacoes;
using System.Threading.Tasks;

namespace Aplicacao.Transacoes.Interfaces;

public interface IAdicionaTransacao
{
    Task Adicionar(AdicionaTransacaoDto transacaoDto);
}
