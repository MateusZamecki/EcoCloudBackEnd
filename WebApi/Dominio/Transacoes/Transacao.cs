using Comum.Dominio;
using Comum.Excecoes;
using Comum.Helpers;
using Dominio.ObjetosDeValor;
using System;

namespace Dominio.Transacoes;

public class Transacao : Entidade<Transacao>
{
    public Nome Nome { get; private set; }
    public Quantia Quantia { get; private set; }
    public string Descricao { get; private set; }
    public DateTime DataDeCriacao { get; private set; }
    public bool Ativo { get; private set; }
    public bool Desativado => !Ativo;
    public virtual Classificacao Classificacao { get; private set; }
    public bool EhRecorrente { get; private set; }

    protected Transacao() { }

    public Transacao(Nome nome, Quantia quantia, Classificacao classificacao, string descricao = "", bool ehRecorrente = false)
    {
        ValidarDadosObrigatorios(nome, quantia, classificacao);
        Nome = nome;
        Quantia = quantia;
        Classificacao = classificacao;
        DataDeCriacao = ObtemADataAtualEHorarioDeBrasilia.Obter();
        Ativo = true;
        EhRecorrente = ehRecorrente;
        Descricao = descricao;
    }

    private void ValidarDadosObrigatorios(Nome nome, Quantia quantia, Classificacao classificacao)
    {
        ValidarNome(nome);
        ValidarQuantia(quantia);
        ValidarClassificacao(classificacao);
    }

    public void AlterarNome(Nome nome)
    {
        ValidarNome(nome);
        Nome = nome;
    }

    public void AtualizarQuantia(Quantia quantia)
    {
        ValidarQuantia(quantia);
        Quantia = quantia;
    }

    public void Desativar()
    {
        Ativo = false;
    }

    public void Aivar()
    {
        Ativo = true;
    }

    public void AlterarRecorrencia(bool ehRecorrente)
    {
        EhRecorrente = ehRecorrente;
    }

    public void AlterarClassificacao(Classificacao classificacao)
    {
        ValidarClassificacao(classificacao);
        Classificacao = classificacao;
    }

    public void AlterarDataDeCriacao(DateTime dataDeCriacao)
    {
        DataDeCriacao = dataDeCriacao;
    }

    public void AlterarDescricao(string descricao)
    {
        Descricao = descricao;
    }

    private void ValidarClassificacao(Classificacao classificacao)
    {
        new ExcecaoDeDominio()
            .QuandoEhNulo(classificacao, MensagensDeExcecao.AClassificacaoInformadaEhInvalida)
            .EntaoDispara();
    }

    private void ValidarQuantia(Quantia quantia)
    {
        new ExcecaoDeDominio()
           .QuandoEhNulo(quantia, MensagensDeExcecao.QuantiaInformadaEhInvalida)
           .EntaoDispara();
    }

    private void ValidarNome(Nome nome)
    {
        new ExcecaoDeDominio()
          .QuandoEhNulo(nome, MensagensDeExcecao.ONomeInformadoEhInvalido)
          .EntaoDispara();
    }
}
