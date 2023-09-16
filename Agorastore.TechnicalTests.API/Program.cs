
using Agorastore.TechnicalTests.API.Config;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.Configure<PriceOptions>(builder.Configuration.GetSection("PriceOptions"));

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
});

app.UseHttpsRedirection();

app.MapControllers();

app.Run();