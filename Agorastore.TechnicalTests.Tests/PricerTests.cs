using Microsoft.Extensions.Options;

namespace Agorastore.TechnicalTests.Domain.Tests
{
    public class PricerTests
    {
        [Fact]
        public void Price_should_be_compute_according_to_pricing_formula()
        {
            decimal commission = 0.2m;
            decimal initialPrice = 10.00m;
            
            var optionsSnapshot = Substitute.For<IOptionsSnapshot<PricerConfiguration>>();
            optionsSnapshot.Value.Returns(new PricerConfiguration(commission));

            var pricer = new Pricer(optionsSnapshot);

            var sellingPrice = pricer.CalculateSellingPrice(initialPrice);

            sellingPrice.Should().Be(initialPrice + (initialPrice * commission));
        }
    }
}
