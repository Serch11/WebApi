using Microsoft.Extensions.DependencyInjection.Extensions;
using WebApi;
using WebApi.Middlewares;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlServices<TareasContext>("");
//builder.Services.AddScoped<InterfaceHelloWorldService,HelloWorldService>();

//Inyeccion de dependencias
builder.Services.AddScoped<InterfaceHelloWorldService>(p => new HelloWorldService());
builder.Services.AddScoped<ICategoriaServices, CategoriaService>();
builder.Services.AddScoped<ITareaService, TareasService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//Middlewares persolazados

//app.UseWelcomePage();

//app.UseTimeMiddleware();

app.MapControllers();

app.Run();
