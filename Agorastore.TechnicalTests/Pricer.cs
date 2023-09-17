using Microsoft.Extensions.Options;

namespace Agorastore.TechnicalTests
{
    public interface IPricer
    {
        decimal CalculateSellingPrice(decimal initialPrice);
    }

    public record PricerConfiguration(decimal Commission);
    public class Pricer: IPricer
    {
        private readonly IOptionsSnapshot<PricerConfiguration> _configuration;

        public Pricer(IOptionsSnapshot<PricerConfiguration> configuration)
        {
            _configuration = configuration;
        }

        public decimal CalculateSellingPrice(decimal initialPrice)
        {
            return initialPrice + (initialPrice * _configuration.Value.Commission);
        }
    }
}