using System.Threading.Tasks;

namespace Aplicacao.Transacoes.Interfaces;

public interface IDesativaTransacao
{
    Task Desativar(int id, int idDaColuna);
}
