using System;
using Agorastore.TechnicalTests.API.Config;
using Microsoft.Extensions.Options;

namespace Agorastore.TechnicalTests.API.Services
{
    public class PriceService : IPriceService
    {
        private readonly PriceOptions _priceOptions;

        public PriceService(IOptions<PriceOptions> priceOptions)
        {
            _priceOptions = priceOptions.Value;
        }

        public double CalculateSellingPriceHT(double initialPrice)
        {
            if (initialPrice <= 0)
            {
                throw new ArgumentException("Initial price must be greater than 0.", nameof(initialPrice));
            }
            return CalculatePriceRate(initialPrice, _priceOptions.CommissionRate);
        }

        public double CalculateSellingPriceTTC(double initialPrice)
        {
            if (initialPrice <= 0)
            {
                throw new ArgumentException("Initial price must be greater than 0.", nameof(initialPrice));
            }
            double sellingPriceHT = CalculateSellingPriceHT(initialPrice);
            return CalculatePriceRate(sellingPriceHT, _priceOptions.VATRate);
        }

        private static double CalculatePriceRate(double price, double rate)
        {
            return price + (price * rate / 100);
        }
    }
}