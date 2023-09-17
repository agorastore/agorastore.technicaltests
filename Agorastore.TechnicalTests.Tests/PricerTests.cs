using Microsoft.Extensions.Options;

namespace Agorastore.TechnicalTests.Domain.Tests
{
    public class PricerTests
    {
        [Fact]
        public void Selling_price_should_be_compute_according_to_pricing_formula()
        {
            decimal commission = 0.2m;
            decimal initialPrice = 10.00m;
            
            var optionsSnapshot = Substitute.For<IOptionsSnapshot<PricerConfiguration>>();
            optionsSnapshot.Value.Returns(new PricerConfiguration(commission));

            var pricer = new Pricer(optionsSnapshot);

            var sellingPrice = pricer.CalculateSellingPrice(initialPrice);

            sellingPrice.Should().Be(initialPrice + (initialPrice * commission));
        }

        [Fact]
        public void Selling_price_should_include_vat_when_requested()
        {
            decimal commission = 0.2m;
            decimal initialPrice = 10.00m;

            var optionsSnapshot = Substitute.For<IOptionsSnapshot<PricerConfiguration>>();
            optionsSnapshot.Value.Returns(new PricerConfiguration(commission));

            var pricer = new Pricer(optionsSnapshot);

            var sellingPriceWithVAT = pricer.CalculateSellingPrice(initialPrice, includeVat: true);

            var sellingPrice = initialPrice + (initialPrice * commission);

            sellingPriceWithVAT.Should().Be(sellingPrice * 1.20m);
        }
    }
}
