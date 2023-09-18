using Agorastore.TechnicalTests.API.Business.Interfaces;
using Agorastore.TechnicalTests.API.Business.ConfigurateursDePrix;
using Microsoft.AspNetCore.Mvc;
using Agorastore.TechnicalTests.API.Business.MoteursCalcul;
using Agorastore.TechnicalTests.API.Business.MoteursCalcul;
using AgoraStoreTest.Business.ConfigurateursDePrix;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000"); // add the allowed origins  
                      });
});

//un chwia de DI pour un peu se la jouer techos ;-)
builder.Services.AddScoped<IConfigurateurDePrix, configurateurDePrix>();
builder.Services.AddTransient<IMoteurCalcul, MoteurDeCalcul>();

var app = builder.Build();

app.UseCors(MyAllowSpecificOrigins);

app.MapGet("/CalculPrixVente/{prixInitial}",
    ([FromRoute] decimal prixInitial, [FromServices] IMoteurCalcul moteurCalcul) =>
{
    return moteurCalcul.GetPrixVente(prixInitial);
}
);

app.Run();
