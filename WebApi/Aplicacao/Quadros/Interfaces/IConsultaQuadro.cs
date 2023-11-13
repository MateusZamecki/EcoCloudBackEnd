using Aplicacao.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplicacao.Quadros.Interfaces;

public interface IConsultaQuadro
{
    Task<QuadroDto> Consultar(int idDoQuadro);
    Task<List<QuadroDto>> ConsultarPorUsuario(int idDoUsuario);
}
