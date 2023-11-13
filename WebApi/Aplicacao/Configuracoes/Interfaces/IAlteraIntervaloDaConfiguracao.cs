using Aplicacao.DTOs;
using System.Threading.Tasks;

namespace Aplicacao.Configuracoes.Interfaces;

public interface IAlteraIntervaloDaConfiguracao
{
    Task<ConfiguracaoDto> Alterar(ConfiguracaoDto configuracaoDto);
}
