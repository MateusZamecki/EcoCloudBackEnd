using Aplicacao.DTOs.Colunas;
using System.Threading.Tasks;

namespace Aplicacao.Colunas.Interfaces;

public interface IAlteraNomeDaColuna
{
    Task<ColunaDto> Alterar(ColunaDto colunaDto);
}
