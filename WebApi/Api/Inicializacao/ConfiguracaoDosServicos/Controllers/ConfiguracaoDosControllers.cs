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
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.WithOrigins("http://localhost:4200")
                                      .AllowAnyHeader()
                                      .AllowAnyMethod());
            });
        }

        public static void MapearControllers(this WebApplication app)
        {
            app.MapControllers();
            app.MapCarter();
            app.UseCors("AllowSpecificOrigin");
        }
    }
}
