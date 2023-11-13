using System.Threading.Tasks;

namespace Aplicacao.Colunas.Interfaces;

public interface IExcluiColuna
{
    Task Excluir(int idDaColuna);
}
