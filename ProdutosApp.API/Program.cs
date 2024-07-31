using ProdutoApp.Infra.Data.Repositories;
using ProdutosApp.Domain.Interfaces.Messages;
using ProdutosApp.Domain.Interfaces.Repositories;
using ProdutosApp.Domain.Interfaces.Services;
using ProdutosApp.Domain.Services;
using ProdutosApp.Infra.Messages.Consumers;
using ProdutosApp.Infra.Messages.Producers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddRouting(config => { config.LowercaseUrls = true; });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IProdutoRepository,ProdutoRepository>();
builder.Services.AddTransient<IFornecedorRepository, FornecedorRepository>();
builder.Services.AddTransient<IProdutoService, ProdutoService>();
builder.Services.AddTransient<IFornecedorService, FornecedorService>();
builder.Services.AddTransient<IMessageProducer, MessageProducer>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("DefaultPolicy", builder =>
    {
        builder.WithOrigins("http://localhost:5284")
        .AllowAnyMethod()
        .AllowAnyHeader();
    });

});

#region Registrando a classe CONSUMER
builder.Services.AddHostedService<MessageConsumer>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseCors("DefaultPolicy");

app.MapControllers();

app.Run();
public partial class Program { }
