using Aplicacao.DTOs.Quadros;
using System.Threading.Tasks;

namespace Aplicacao.Quadros.Interfaces;

public interface IConsultaQuadro
{
    Task<QuadroDto> Consultar(int idDoQuadro);
}
