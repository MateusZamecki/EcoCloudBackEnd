using Aplicacao.DTOs;
using System.Threading.Tasks;

namespace Aplicacao.Transacoes.Interfaces;

public interface IAdicionaTransacao
{
    Task<TransacaoDto> Adicionar(TransacaoDto transacaoDto);
}
