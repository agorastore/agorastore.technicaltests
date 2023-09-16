using System;
using Agorastore.TechnicalTests.API.Config;
using Agorastore.TechnicalTests.API.Services;
using Microsoft.Extensions.Options;
using Moq;

namespace Agorastore.TechnicalTests.Tests
{
	public class PriceServiceTests
	{
        [Fact]
        public void CalculateSellingPriceHT_ShouldCalculateCorrectly()
        {
            // Arrange
            var mockPriceOptions = new Mock<IOptions<PriceOptions>>();
            mockPriceOptions.Setup(p => p.Value).Returns(new PriceOptions
            {
                CommissionRate = 10, // 10%
                VATRate = 20 // 20%
            });

            var priceService = new PriceService(mockPriceOptions.Object);

            // Act
            double initialPrice = 100.0;
            double expectedSellingPriceHT = 110.0;
            double actualSellingPriceHT = priceService.CalculateSellingPriceHT(initialPrice);

            // Assert
            Assert.Equal(expectedSellingPriceHT, actualSellingPriceHT, 2);
        }

        [Fact]
        public void CalculateSellingPriceTTC_ShouldCalculateCorrectly()
        {
            // Arrange
            var mockPriceOptions = new Mock<IOptions<PriceOptions>>();
            mockPriceOptions.Setup(p => p.Value).Returns(new PriceOptions
            {
                CommissionRate = 10.0,
                VATRate = 20.0
            });

            var priceService = new PriceService(mockPriceOptions.Object);

            // Act
            double initialPrice = 100.0;
            double expectedSellingPriceTTC = 132.0;
            double actualSellingPriceTTC = priceService.CalculateSellingPriceTTC(initialPrice);

            // Assert
            Assert.Equal(expectedSellingPriceTTC, actualSellingPriceTTC, 2);
        }

        [Fact]
        public void CalculateSellingPriceHT_ShouldCalculateCorrectlyWithNegativeInitialPrice()
        {
            // Arrange
            var mockPriceOptions = new Mock<IOptions<PriceOptions>>();
            mockPriceOptions.Setup(p => p.Value).Returns(new PriceOptions
            {
                CommissionRate = 10.0,
                VATRate = 20.0
            });

            var priceService = new PriceService(mockPriceOptions.Object);

            // Act
            double initialPrice = -100.0;

            // Assert
            Assert.Throws<ArgumentException>(() => priceService.CalculateSellingPriceHT(initialPrice));
        }

        [Fact]
        public void CalculateSellingPriceTTC_ShouldCalculateCorrectlyWithNegativeInitialPrice()
        {
            // Arrange
            var mockPriceOptions = new Mock<IOptions<PriceOptions>>();
            mockPriceOptions.Setup(p => p.Value).Returns(new PriceOptions
            {
                CommissionRate = 10.0,
                VATRate = 20.0
            });

            var priceService = new PriceService(mockPriceOptions.Object);

            // Act
            double initialPrice = -100.0;

            // Assert
            Assert.Throws<ArgumentException>(() => priceService.CalculateSellingPriceTTC(initialPrice));
        }
    }
}