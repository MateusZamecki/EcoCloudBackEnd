using Aplicacao.DTOs.Colunas;
using System.Threading.Tasks;

namespace Aplicacao.Colunas.Interfaces;

public interface IAdicionaColuna
{
    Task<ColunaDto> Adicionar(ColunaDto colunaDto);
}
