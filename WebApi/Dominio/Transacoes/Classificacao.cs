using System.ComponentModel;

namespace Dominio.Transacoes;

public enum Classificacao
{
    [Description("Diversos")]
    DIVERSOS = 0,
    [Description("Fixo")]
    FIXO = 1,
    [Description("Investimento")]
    INVESTIMENTO = 2,
}
