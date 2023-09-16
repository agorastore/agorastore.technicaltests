using Microsoft.OpenApi.Models;
using Agorastore.TechnicalTests.API.Config;
using Agorastore.TechnicalTests.API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.Configure<PriceOptions>(builder.Configuration.GetSection("PriceOptions"));

builder.Services.AddScoped<IPriceService, PriceService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Calculateur de Prix de Vente",
        Version = "v1",
        Description = "L'API du Calculateur de Prix de Vente est une application en .NET Core qui vous permet de prévisualiser le prix de vente à partir d'un montant initial. Elle vous offre la flexibilité de calculer le prix de vente hors taxes (HT) ou toutes taxes comprises (TTC), en appliquant une commission personnalisable. Cette API backend vous fournit un moteur de calcul précis pour vous aider à estimer vos prix de vente rapidement et efficacement.",
        Contact = new OpenApiContact
        {
            Name = "Soufian BOUTAIB",
            Email = "soufian.boutaib@gmail.com",
            Url = new Uri("https://www.linkedin.com/in/soufian-boutaib/"),
        },
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
});

app.UseHttpsRedirection();

app.MapControllers();

app.Run();