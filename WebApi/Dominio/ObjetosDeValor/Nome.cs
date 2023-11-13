using Comum.Excecoes;
using Comum.ObjetosDeValor;
using System.Collections.Generic;

namespace Dominio.ObjetosDeValor;

public class Nome : ObjetoDeValor
{
    public const int TamanhoMaximo = 50;
    public string Valor { get; private set; }

    protected Nome()
    {
    }

    private Nome(string valor)
    {
        Valor = valor;
    }

    public static Nome Criar(string valor)
    {
        ValidarConteudo(valor);
        return new Nome(valor);
    }

    private static void ValidarConteudo(string valor)
    {
        new ExcecaoDeDominio()
            .QuandoEhNulo(valor, MensagensDeExcecao.EhObrigatorioInformarUmNome)
            .QuandoEhStringVaziaOuNula(valor, MensagensDeExcecao.EhObrigatorioInformarUmNome)
            .Quando(valor.Length > TamanhoMaximo, MensagensDeExcecao.OTamanhoDoNomeExcedeOLimiteDeCaracteres)
            .EntaoDispara();
    }

    public override IEnumerable<object> ValoresAtomicos()
    {
        yield return Valor;
    }
}
