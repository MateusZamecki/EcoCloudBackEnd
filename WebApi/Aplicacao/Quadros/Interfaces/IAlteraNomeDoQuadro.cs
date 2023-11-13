using Aplicacao.DTOs;
using System.Threading.Tasks;

namespace Aplicacao.Quadros.Interfaces;

public interface IAlteraNomeDoQuadro
{
    Task<QuadroDto> Alterar(string nome, int idDoQuadro);
}
