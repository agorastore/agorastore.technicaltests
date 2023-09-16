
using Agorastore.TechnicalTests.API.Config;
using Agorastore.TechnicalTests.API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.Configure<PriceOptions>(builder.Configuration.GetSection("PriceOptions"));

builder.Services.AddScoped<IPriceService, PriceService>();

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