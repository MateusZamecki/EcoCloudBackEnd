namespace WebApi.Inicializacao.ConfiguracaoDosServicos.Swagger;

public static class ConfiguracaoDoSwagger
{
    public static void ConfigurarSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new() { Title = "EcoCloud", Version = "v1" });
        });
    }

    public static void MapearSwagger(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }
}
