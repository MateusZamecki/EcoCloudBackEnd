using Aplicacao.Configuracoes.Interfaces;
using Hangfire;

namespace WebApi.Jobs;

public class SalvaTransacoesNoHistoricoJob
{
    public void Salvar()
    {
        RecurringJob.AddOrUpdate<ISalvaTodasAsTransacoesNoHistoricoAutomaticamente>(
            "SalvaTodasAsTransacoes",
            salva => salva.Salvar().Wait(),
            Cron.Minutely);
    }
}
