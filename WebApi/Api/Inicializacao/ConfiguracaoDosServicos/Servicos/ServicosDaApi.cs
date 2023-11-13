using WebApi.Jobs;

namespace WebApi.Inicializacao.ConfiguracaoDosServicos.Servicos
{
    public static class ServicosDaApi
    {
        public static void RegistrarServicosDaApi(this IServiceCollection services)
        {
            services.AddScoped<SalvaTransacoesNoHistoricoJob>();
        }
    }
}
