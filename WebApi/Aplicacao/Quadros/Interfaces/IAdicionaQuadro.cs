using Aplicacao.DTOs.Quadros;
using System.Threading.Tasks;

namespace Aplicacao.Quadros.Interfaces;

public interface IAdicionaQuadro
{
    Task Adicionar(AdicionaQuadroDto adicionaQuadroDto);
}
