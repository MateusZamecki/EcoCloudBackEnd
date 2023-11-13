using System.Threading.Tasks;

namespace Aplicacao.Transacoes.Interfaces;

public interface IExcluiTransacao
{
    Task Excluir(int idDaTranscao, int idDaColuna);
}
