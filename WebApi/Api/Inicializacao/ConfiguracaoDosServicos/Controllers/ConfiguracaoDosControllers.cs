using Carter;

namespace WebApi.Inicializacao.ConfiguracaoDosServicos.Controllers
{
    public static class ConfiguracaoDosControllers
    {
        public static void AdicionarConfiguracaoDosControllers(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddCarter();
        }

        public static void MapearControllers(this WebApplication app)
        {
            app.MapControllers();
            app.MapCarter();
        }
    }
}
