using Comum.Dominio;
using Comum.Excecoes;
using System;

namespace Dominio.Colunas;

public class Configuracao : Entidade<Configuracao>
{
    public DateTime Data { get; private set; }
    public int IntervaloDeDias { get; private set; }
    public bool EhParaSalvar => Data.AddDays(IntervaloDeDias) <= DateTime.Now.Date;

    protected Configuracao() { }

    public Configuracao(int intervaloDeDias)
    {
        ValidarDadosObrigatorios(intervaloDeDias);
        Data = DateTime.Now.Date;
        IntervaloDeDias = intervaloDeDias;
    }

    private void ValidarDadosObrigatorios(int intervaloDeDias)
    {
        new ExcecaoDeDominio()
            .Quando(intervaloDeDias <= 0, MensagensDeExcecao.IntervaloDeTempoInformadoEhInvalido)
            .EntaoDispara();
    }

    public void AlterarIntervalo(int novoIntervaloDeDias)
    {
        ValidarDadosObrigatorios(novoIntervaloDeDias);
        AtualizarData();
        IntervaloDeDias = novoIntervaloDeDias;
    }

    public void AtualizarData()
    {
        Data = DateTime.Now.Date;
    }
}
