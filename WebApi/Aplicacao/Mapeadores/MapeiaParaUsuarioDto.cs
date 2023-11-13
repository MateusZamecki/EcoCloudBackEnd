using Aplicacao.DTOs;
using Dominio.Usuarios;
using System.Collections.Generic;
using System.Linq;

namespace Aplicacao.Mapeadores;

public static class MapeiaParaUsuarioDto
{
    public static UsuarioDto ObterDto(this Usuario usuario)
    {
        return new UsuarioDto
        {
            Id = usuario.Id,
            Nome = usuario.Nome.Valor,
            Email = usuario.Email.Valor,
            DataDeCriacao = usuario.DataDeCriacao
        };
    }

    public static List<UsuarioDto> ObterDto(this List<Usuario> usuarios)
    {
        return usuarios.Select(ObterDto).ToList();
    }
}
