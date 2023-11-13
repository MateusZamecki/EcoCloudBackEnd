using Comum.Excecoes;
using Comum.ObjetosDeValor;
using System;
using System.Collections.Generic;

namespace Dominio.ObjetosDeValor;

public class Data : ObjetoDeValor
{
    public DateTime Valor { get; private set; }

    private Data(DateTime valor)
    {
        Valor = valor;
    }

    public static Data Criar(DateTime valor)
    {
        ValidarConteudo(valor);
        return new Data(valor);
    }

    private static void ValidarConteudo(DateTime valor)
    {
        new ExcecaoDeDominio()
            .QuandoDataEhMenorQueADataAtual(valor, MensagensDeExcecao.DataInvalida)
            .EntaoDispara();
    }

    public override IEnumerable<object> ValoresAtomicos()
    {
        yield return Valor;
    }
}
