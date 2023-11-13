using System;

namespace Aplicacao.DTOs;

public class UsuarioDto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public DateTime DataDeCriacao { get; set; }
}
