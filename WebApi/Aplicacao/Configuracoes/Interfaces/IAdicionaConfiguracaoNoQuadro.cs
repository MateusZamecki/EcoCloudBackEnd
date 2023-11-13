using Aplicacao.DTOs;
using System.Threading.Tasks;

namespace Aplicacao.Configuracoes.Interfaces;

public interface IAdicionaConfiguracaoNoQuadro
{
    Task<QuadroDto> Adicionar(int intervaloDeDias, int idDoQuadro);
}
