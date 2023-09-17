namespace Agorastore.TechnicalTests.API
{
    public record PricingRequest(decimal InitialPrice, bool IncludeVat = false);
    public record Pricing(decimal SellingPrice);
}
