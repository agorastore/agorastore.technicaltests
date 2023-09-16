using System;
namespace Agorastore.TechnicalTests.API.Services
{
	public interface IPriceService
	{
        public double CalculateSellingPriceHT(double initialPrice);

        public double CalculateSellingPriceTTC(double initialPrice);
    }
}