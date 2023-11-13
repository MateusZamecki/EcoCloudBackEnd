using Aplicacao.DTOs.Colunas;
using System.Threading.Tasks;

namespace Aplicacao.Colunas.Interfaces;

public interface ISalvaTodasAsTransacoesNoHistorico
{
    Task<ColunaDto> Salvar(int idDaColuna);
}
