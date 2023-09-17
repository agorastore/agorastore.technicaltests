

namespace Agorastore.TechnicalTests.Domain.Tests
{
    public class PricerTests
    {
        [Fact]
        public void Price_should_be_compute_according_to_pricing_formula()
        {
            var pricer = new Pricer();

            var sellingPrice = pricer.CalculateSellingPrice(10.00m);

            sellingPrice.Should().Be(10.00m + (10.00m * 0.2m));
        }
    }
}
