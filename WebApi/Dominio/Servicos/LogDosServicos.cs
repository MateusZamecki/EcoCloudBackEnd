using Comum.Dominio;
using Comum.Helpers;
using System;

namespace Dominio.Servicos;

public class LogDosServicos : Entidade<LogDosServicos>
{
    public TipoDeServico TipoDeServico { get; set; }
    public string Mensagem { get; set; }
    public DateTime DataDeExcecucao { get; set; }
    public TipoDeInformacao TipoDeInformacao { get; set; }

    public LogDosServicos(TipoDeServico tipoDeServico, string mensagem, TipoDeInformacao tipoDeInformacao)
    {
        TipoDeServico = tipoDeServico;
        Mensagem = mensagem;
        DataDeExcecucao = ObtemADataAtualEHorarioDeBrasilia.Obter();
        TipoDeInformacao = tipoDeInformacao;
    }
}
