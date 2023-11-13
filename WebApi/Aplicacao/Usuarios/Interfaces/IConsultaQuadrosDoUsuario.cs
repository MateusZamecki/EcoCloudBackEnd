using Aplicacao.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplicacao.Usuarios.Interfaces;

public interface IConsultaQuadrosDoUsuario
{
    public Task<List<QuadroDto>> Consultar(int idDoUsuario);
}
