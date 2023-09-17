namespace Agorastore.TechnicalTests
{
    public class Pricer
    {
        public decimal CalculateSellingPrice(decimal initialPrice)
        {
            return initialPrice + (initialPrice * 0.2m);
        }
    }
}