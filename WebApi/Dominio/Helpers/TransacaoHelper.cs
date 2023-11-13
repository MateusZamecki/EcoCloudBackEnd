using Dominio.ObjetosDeValor;
using Dominio.Transacoes;
using System.Collections.Generic;
using System.Linq;

namespace Dominio.Helpers;

public static class TransacaoHelper
{
    public static Quantia Somar(this List<Transacao> transacoes)
    {
        return Quantia.Criar(transacoes.Sum(transacao => transacao.Quantia.Valor));
    }
}
