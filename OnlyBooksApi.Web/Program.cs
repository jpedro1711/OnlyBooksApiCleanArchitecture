using OnlyBooksApi.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

IoC ioC = new IoC(builder.Configuration);

ioC.Configure(builder.Services);

ioC.ConfigureKeyVault(builder.Configuration);

ioC.WriteConfigurationSources(builder.Configuration);

var app = builder.Build();

app.UseMiddleware<ErrorMiddleware>();

app.UseCors("AllowAllOrigins");

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
