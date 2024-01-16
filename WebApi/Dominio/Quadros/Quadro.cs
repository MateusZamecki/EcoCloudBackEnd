using Comum.Dominio;
using Comum.Excecoes;
using Dominio.Colunas;
using Dominio.ObjetosDeValor;
using System.Collections.Generic;
using System.Linq;

namespace Dominio.Quadros;

public class Quadro : Entidade<Quadro>
{
    public Nome Nome { get; private set; }
    private readonly List<Coluna> _colunas = new();
    public virtual List<Coluna> Colunas => _colunas;
    public Quantia DespesasTotaisDasColunas => CalcularAQuantiaTotalDasColunas(Tipo.DESPESA);
    public Quantia ReceitasTotaisDasColunas => CalcularAQuantiaTotalDasColunas(Tipo.RECEITA);

    protected Quadro() { }

    public Quadro(Nome nome)
    {
        ValidarNome(nome);
        Nome = nome;
    }

    public void AlterarNome(Nome nome)
    {
        ValidarNome(nome);
        Nome = nome;
    }

    public void AdicionarColuna(Coluna coluna)
    {
        ValidarColuna(coluna);
        _colunas.Add(coluna);
    }

    public void RemoverColuna(Coluna coluna)
    {
        ValidarColuna(coluna);
        _colunas.Remove(coluna);
    }

    private Quantia CalcularAQuantiaTotalDasColunas(Tipo tipo)
    {
        var total = Colunas
                .Where(coluna => coluna.Tipo == tipo)
                .Sum(coluna => coluna.TotalDasTransacoes.Valor);
        return Quantia.Criar();
    }

    private void ValidarColuna(Coluna coluna)
    {
        new ExcecaoDeDominio()
            .QuandoEhNulo(coluna, MensagensDeExcecao.ColunaAdicionadaEhInvalida)
            .EntaoDispara();
    }

    private void ValidarNome(Nome nome)
    {
        new ExcecaoDeDominio()
            .QuandoEhNulo(nome, MensagensDeExcecao.ONomeInformadoEhInvalido)
            .EntaoDispara();
    }
}
