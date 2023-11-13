using Dominio.Colunas;
using System.Threading.Tasks;

namespace Infra.Repositorios.Interfaces;

public interface IColunaRepositorio : IRepositorioBase<Coluna>
{
    Task<Coluna> ConsultarHistorico(int idDaColuna);
}
