using Agorastore.TechnicalTests;
using Agorastore.TechnicalTests.API;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IPricer, Pricer>();
builder.Services.Configure<PricerConfiguration>(
    builder.Configuration.GetSection("Pricer"));

var app = builder.Build();

app.MapGet("/calculate-pricing", (IPricer pricer, decimal initialPrice, bool includeVat) => 
{
    var sellingPrice = pricer.CalculateSellingPrice(initialPrice, includeVat);
    return Results.Ok(new Pricing(sellingPrice));
});

app.Run();