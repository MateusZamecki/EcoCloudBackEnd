using Aplicacao.DTOs;
using System.Threading.Tasks;

namespace Aplicacao.Quadros.Interfaces;

public interface IAdicionaQuadro
{
    Task<QuadroDto> Adicionar(string nomeDoQuadro, int idDoUsuario);
}
