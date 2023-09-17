using Microsoft.Extensions.Options;

namespace Agorastore.TechnicalTests
{
    public interface IPricer
    {
        decimal CalculateSellingPrice(decimal initialPrice, bool includeVat = false);
    }

    public record PricerConfiguration(decimal Commission);
    public class Pricer: IPricer
    {
        private static readonly decimal VAT = 0.2m;

        private readonly IOptionsSnapshot<PricerConfiguration> _configuration;

        public Pricer(IOptionsSnapshot<PricerConfiguration> configuration)
        {
            _configuration = configuration;
        }

        public decimal CalculateSellingPrice(decimal initialPrice, bool includeVat = false)
        {
            var sellingPrice = initialPrice + (initialPrice * _configuration.Value.Commission);
            return includeVat ? sellingPrice + (sellingPrice * VAT) : sellingPrice;
        }
    }
}