using Aplicacao.DTOs;
using System.Threading.Tasks;

namespace Aplicacao.Usuarios.Interfaces;

public interface IConsultaInformacoesDoUsuario
{
    Task<UsuarioDto> Consultar(int idDoUsuario); 
}
