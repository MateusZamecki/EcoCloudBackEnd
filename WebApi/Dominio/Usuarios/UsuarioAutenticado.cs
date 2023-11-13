using Comum.Dominio;
using System.Collections.Generic;

namespace Dominio.Usuarios;

public class UsuarioAutenticado : Entidade<UsuarioAutenticado>
{
    public List<Permissao> Permissoes { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
}
