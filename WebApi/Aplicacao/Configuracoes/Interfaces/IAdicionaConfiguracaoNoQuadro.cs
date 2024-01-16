using Aplicacao.DTOs.Quadros;
using System.Threading.Tasks;

namespace Aplicacao.Configuracoes.Interfaces;

public interface IAdicionaConfiguracaoNoQuadro
{
    Task<QuadroDto> Adicionar(int intervaloDeDias, int idDoQuadro);
}
