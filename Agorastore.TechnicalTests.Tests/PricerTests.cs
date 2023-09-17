using Microsoft.Extensions.Options;

namespace Agorastore.TechnicalTests.Domain.Tests
{
    public class PricerTests
    {
        private readonly decimal _commission;
        private readonly IPricer _pricer;

        public PricerTests()
        {
            _commission = 0.2m;
            
            var optionsSnapshot = Substitute.For<IOptionsSnapshot<PricerConfiguration>>();
            optionsSnapshot.Value.Returns(new PricerConfiguration(_commission));

            _pricer = new Pricer(optionsSnapshot);
        }

        [Fact]
        public void Selling_price_should_be_computed_according_to_pricing_formula()
        {
            decimal initialPrice = 10.00m;

            var sellingPrice = _pricer.CalculateSellingPrice(initialPrice);

            sellingPrice.Should().Be(initialPrice + (initialPrice * _commission));
        }

        [Fact]
        public void Selling_price_should_include_vat_when_requested()
        {
            decimal initialPrice = 10.00m;

            var sellingPriceWithVAT = _pricer.CalculateSellingPrice(initialPrice, includeVat: true);

            var sellingPrice = initialPrice + (initialPrice * _commission);

            sellingPriceWithVAT.Should().Be(sellingPrice * 1.20m);
        }
    }
}
