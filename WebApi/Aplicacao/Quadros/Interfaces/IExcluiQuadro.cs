using System.Threading.Tasks;

namespace Aplicacao.Quadros.Interfaces;

public interface IExcluiQuadro
{
    Task Excluir(int idDoQuadro);
}
