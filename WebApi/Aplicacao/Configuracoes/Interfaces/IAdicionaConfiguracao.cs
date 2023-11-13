using Aplicacao.DTOs.Colunas;
using System.Threading.Tasks;

namespace Aplicacao.Configuracoes.Interfaces;

public interface IAdicionaConfiguracaoNaColuna
{
    Task<ColunaDto> Adicionar(int intervaloDeDias, int idDaColuna);
}
