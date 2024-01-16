using Aplicacao.DTOs.Colunas;
using System.Threading.Tasks;

namespace Aplicacao.Colunas.Interfaces;

public interface IAlteraColuna
{
    Task Alterar(AlteraColunaDto alteraColunaDto);
}
