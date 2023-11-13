using Aplicacao.Usuarios.Interfaces;
using Aplicacao.Usuarios;
using Infra.Repositorios.Interfaces;
using Infra.Repositorios;

namespace WebApi.Inicializacao.ConfiguracaoDosServicos.Servicos
{
    public static class ServicosDeInfra
    {
        public static void RegistrarServicosDeInfra(this IServiceCollection services)
        {
            services.AddScoped<IConsultaQuadrosDoUsuario, ConsultaQuadrosDoUsuario>();
            services.AddScoped<IQuadroRepositorio, QuadroRepositorio>();
            services.AddScoped<ITransacaoRepositorio, TransacaoRepositorio>();
            services.AddScoped<IColunaRepositorio, ColunaRepositorio>();
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddScoped<IConfiguracaoRepositorio, ConfiguracaoRepositorio>();
        }
    }
}
