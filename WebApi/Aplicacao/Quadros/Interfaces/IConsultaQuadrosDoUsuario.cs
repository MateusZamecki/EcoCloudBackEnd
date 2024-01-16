using Aplicacao.DTOs.Quadros;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplicacao.Quadros.Interfaces;

public interface IConsultaQuadrosDoUsuario
{
    Task<List<QuadroDto>> Consultar(int idDoUsuario);
}
