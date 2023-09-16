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

        public double CalculateSellingPrice(double initialPrice)
        {
            return initialPrice + (initialPrice * _priceOptions.CommissionRate / 100);
        }
    }
}