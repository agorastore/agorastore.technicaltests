using System.ComponentModel.DataAnnotations;

namespace Agorastore.TechnicalTests.API.Controllers
{
    public class PriceCalculationModelApi
    {
        public double InitialPrice { get; set; }
        public bool IncludeVAT { get; set; }
    }
}