using System.ComponentModel;

namespace Dominio.Usuarios;

public enum Permissao
{
    [Description("Administrador")]
    Administrador,
    [Description("Usuario")]
    Usuario,
}
