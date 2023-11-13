using Aplicacao.DTOs;
using System.Threading.Tasks;

namespace Aplicacao.Transacoes.Interfaces;

public interface IAlteraNomeDaTransacao
{
    Task<TransacaoDto> Alterar(string nome, int idDaTranscao);
}
