using Aplicacao.DTOs;
using System.Threading.Tasks;

namespace Aplicacao.Transacoes.Interfaces;

public interface IAtualizaQuantia
{
    Task<TransacaoDto> Atualizar(TransacaoDto transacaoDto);
}
