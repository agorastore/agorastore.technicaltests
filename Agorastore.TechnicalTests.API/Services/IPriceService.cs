using System;
namespace Agorastore.TechnicalTests.API.Services
{
	public interface IPriceService
	{
        public double CalculateSellingPrice(double initialPrice);
    }
}