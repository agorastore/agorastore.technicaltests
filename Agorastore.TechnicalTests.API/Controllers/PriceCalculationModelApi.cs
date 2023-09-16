using System.ComponentModel.DataAnnotations;

namespace Agorastore.TechnicalTests.API.Controllers
{
    public class PriceCalculationModelApi
    {
        [Required(ErrorMessage = "Initial Price is required.")]
        public double InitialPrice { get; set; }

        [Required(ErrorMessage = "Include TVA or not is required.")]
        public bool IncludeVAT { get; set; }
    }
}