using System.ComponentModel;

namespace Dominio.Servicos;

public enum TipoDeInformacao
{
    [Description("Informativo")] Informativo = 0,
    [Description("Aviso")] Aviso = 1,
    [Description("Erro")] Erro = 2,
    [Description("Depuração")] Depuracao = 3,
}
