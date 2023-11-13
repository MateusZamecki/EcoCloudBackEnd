using Dominio.Usuarios;
using Infra.ConexaoComBanco;
using Infra.Repositorios.Interfaces;

namespace Infra.Repositorios;

public class UsuarioRepositorio : RepositorioBase<Usuario>, IUsuarioRepositorio
{
    public UsuarioRepositorio(Contexto contexto) : base(contexto)
    {
    }
}
