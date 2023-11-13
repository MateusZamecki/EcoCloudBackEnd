using Aplicacao.DTOs.Colunas;
using System.Threading.Tasks;

namespace Aplicacao.Colunas.Interfaces;

public interface IConsultaColuna
{
    Task<ColunaDto> Consultar(int id);
}
