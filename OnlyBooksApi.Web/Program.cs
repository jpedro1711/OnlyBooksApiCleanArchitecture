using MassTransit;
using Microsoft.EntityFrameworkCore;
using OnlyBooksApi.Application.Interfaces.Repositories;
using OnlyBooksApi.Application.Interfaces.Services;
using OnlyBooksApi.Application.Services;
using OnlyBooksApi.Infrastructure.Data;
using OnlyBooksApi.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<OnlyBooksDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
}, ServiceLifetime.Transient);

builder.Services.AddScoped<IGeneroLivroRepository, GeneroLivroRepository>();
builder.Services.AddScoped<IGeneroLivroService, GeneroLivroService>();
builder.Services.AddScoped<ILivroService, LivroService>();
builder.Services.AddScoped<ILivroRepository, LivroRepository>();
builder.Services.AddScoped<IReservaService, ReservaService>();
builder.Services.AddScoped<IReservaRepository, ReservaRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IEmprestimoService, EmprestimoService>();
builder.Services.AddScoped<IEmprestimoRepository, EmprestimoRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin()      
               .AllowAnyMethod()      
               .AllowAnyHeader();    
    });
});

builder.Services.AddMassTransit(x =>
{
    x.UsingAzureServiceBus((context, cfg) =>
    {
        string azureServiceBusConnection = builder.Configuration.GetConnectionString("AzureServiceBus");

        cfg.Host(azureServiceBusConnection);
    });
});

var app = builder.Build();

app.UseMiddleware<ErrorMiddleware>();

app.UseCors("AllowAllOrigins");

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
