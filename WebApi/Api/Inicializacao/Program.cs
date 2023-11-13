using WebApi.Inicializacao.ConfiguracaoDosServicos.Controllers;
using WebApi.Inicializacao.ConfiguracaoDosServicos.HangFire;
using WebApi.Inicializacao.ConfiguracaoDosServicos.Servicos;
using WebApi.Inicializacao.ConfiguracaoDosServicos.Swagger;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AdicionarConfiguracaoDosControllers();
services.RegistrarServicos();
services.ConfigurarHangFire();
services.ConfigurarSwagger();

var app = builder.Build();

app.MapearControllers();
app.MapearQuadroDoHangFire();
app.MapearSwagger();

app.UseHttpsRedirection();

app.Run();