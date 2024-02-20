using System.Threading.Tasks;
using Aplicacao.DTOs.Configuracao;
using Dominio.Colunas;

namespace Aplicacao.Configuracoes.Interfaces;

public interface IConsultaConfiguracao
{
    Task<ConfiguracaoDto> Consultar(int id);
    Task<Configuracao> ConsultarEntidade(int id);
}
