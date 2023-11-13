using System.ComponentModel;

namespace Dominio.Colunas;

public enum Tipo
{
    [Description("Receita")]
    RECEITA = 0,
    [Description("Despesa")]
    DESPESA = 1,
}