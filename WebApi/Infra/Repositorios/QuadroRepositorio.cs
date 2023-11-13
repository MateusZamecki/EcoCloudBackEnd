using Dominio.Quadros;
using Infra.ConexaoComBanco;
using Infra.Repositorios.Interfaces;

namespace Infra.Repositorios;

public class QuadroRepositorio : RepositorioBase<Quadro>, IQuadroRepositorio
{
    public QuadroRepositorio(Contexto contexto) : base(contexto)
    {
    }
}
