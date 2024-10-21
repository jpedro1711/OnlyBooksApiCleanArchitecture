using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Azure.Storage.Blobs;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.Json;
using OnlyBooksApi.Application.Interfaces.Providers;
using OnlyBooksApi.Application.Interfaces.Repositories;
using OnlyBooksApi.Application.Interfaces.Services;
using OnlyBooksApi.Application.Services;
using OnlyBooksApi.Infrastructure.AzureBlobStorage;
using OnlyBooksApi.Infrastructure.Data;
using OnlyBooksApi.Infrastructure.Repositories;

namespace OnlyBooksApi.Web.Extensions
{
    public class IoC
    {
        private readonly IConfiguration _configuration;

        public IoC(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(IServiceCollection services)
        {
            ConfigureServices(services);
            ConfigureServiceBus(services);
            ConfigureBlobServiceClient(services);
            ConfigureAutoMapper(services);
            ConfigureDatabaseConnection(services);
            ConfigureCors(services);
            ConfigureSwagger(services);
            ConfigureEndpoints(services);
        }


        private void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IGeneroLivroService, GeneroLivroService>();
            services.AddScoped<ILivroService, LivroService>();
            services.AddScoped<ILivroRepository, LivroRepository>();
            services.AddScoped<IReservaService, ReservaService>();
            services.AddScoped<IReservaRepository, ReservaRepository>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IEmprestimoService, EmprestimoService>();
            services.AddScoped<IEmprestimoRepository, EmprestimoRepository>();
            services.AddScoped<IBlobStorageProvider, BlobStorageProvider>();
            services.AddScoped<IGeneroLivroRepository, GeneroLivroRepository>();
        }

        private void ConfigureServiceBus(IServiceCollection services)
        {
            services.AddMassTransit(x =>
            {
                x.UsingAzureServiceBus((context, cfg) =>
                {
                    string azureServiceBusConnection = _configuration.GetConnectionString("AzureServiceBus");

                    cfg.Host(azureServiceBusConnection);
                });
            });
        }

        private void ConfigureBlobServiceClient(IServiceCollection services)
        {
            services.AddSingleton(u => new BlobServiceClient(
                                      _configuration.GetConnectionString("BlobConnection")
            ));
        }


        private void ConfigureAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        private void ConfigureDatabaseConnection(IServiceCollection services)
        {
            services.AddDbContext<OnlyBooksDbContext>(opt =>
            {
                opt.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
            }, ServiceLifetime.Transient);
        }

        private void ConfigureCors(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });
        }

        private void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen();
        }

        private void ConfigureEndpoints(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
        }

        public void ConfigureKeyVault(IConfigurationBuilder builder)
        {
            string? keyVaultEndpoint = _configuration["KEYVAULT_ENDPOINT"];

            if (keyVaultEndpoint is null)
                throw new InvalidOperationException("KeyVault Inválido");

            builder.AddAzureKeyVault(new Uri(keyVaultEndpoint), new DefaultAzureCredential());
        }

        public void WriteConfigurationSources(IConfigurationBuilder config)
        {
            Console.WriteLine("Configuration sources\n=====================");
            foreach (var source in config.Sources)
            {
                if (source is JsonConfigurationSource jsonSource)
                    Console.WriteLine($"{source}: {jsonSource.Path}");
                else
                    Console.WriteLine(source.ToString());
            }
            Console.WriteLine("=====================\n");
        }
    }
}
