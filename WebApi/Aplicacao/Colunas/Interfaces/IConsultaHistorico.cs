using Aplicacao.DTOs.Colunas;
using System.Threading.Tasks;

namespace Aplicacao.Colunas.Interfaces;

public interface IConsultaHistorico
{
    Task<ColunaDto> Consultar(int idDaColuna);
}
