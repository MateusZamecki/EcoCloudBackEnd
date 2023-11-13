using Comum.Dominio;
using Comum.Helpers;
using Dominio.ObjetosDeValor;
using System;

namespace Dominio.Transacoes;

public class Transacao : Entidade<Transacao>
{
    public Nome Nome { get; private set; }
    public Quantia Quantia { get; private set; }
    public DateTime DataDeCriacao { get; private set; }
    public bool Ativo { get; private set; }
    public bool Desativado => !Ativo;
    public Classificacao Classificacao { get; private set; }

    protected Transacao() { }

    public Transacao(Nome nome, Quantia quantia, Classificacao classificacao = Classificacao.DIVERSOS)
    {
        Nome = nome;
        Quantia = quantia;
        Classificacao = classificacao;
        DataDeCriacao = ObtemADataAtualEHorarioDeBrasilia.Obter();
        Ativo = true;
    }

    public void AlterarNome(Nome nome)
    {
        Nome = nome;
    }

    public void AtualizarQuantia(Quantia quantia)
    {
        Quantia = quantia;
    }

    public void Desativar()
    {
        Ativo = false;
    }

    public void AlterarClassificacao(Classificacao classificacao)
    {
        Classificacao = classificacao;
    }
}
