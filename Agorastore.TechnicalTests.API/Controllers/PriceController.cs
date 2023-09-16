using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agorastore.TechnicalTests.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Agorastore.TechnicalTests.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PriceController : ControllerBase
    {
        private readonly IPriceService _priceService;
        private readonly ILogger<PriceController> _logger;

        public PriceController(IPriceService priceService, ILogger<PriceController> logger)
        {
            _logger = logger;
            _priceService = priceService;
        }

        /// <summary>
        /// Calcul du prix de vente.
        /// </summary>
        /// <param name="initialAmount">Le prix initial, cette valeur devrait être un nombre double.</param>
        /// <param name="includeVAT">TVA incluse ou non, cette valeur de type boolean</param>
        /// <returns>Le prix de vente calculé.</returns>
        [HttpPost("CalculateSellingPrice")]
        [ProducesResponseType(typeof(double), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public ActionResult<double> CalculateSellingPrice([FromBody] PriceCalculationModelApi model)
        {
            try
            {
                if (model.IncludeVAT)
                {
                    double sellingPriceTTC = _priceService.CalculateSellingPriceTTC(model.InitialPrice);
                    return Ok(sellingPriceTTC);
                }
                else
                {
                    double sellingPrice = _priceService.CalculateSellingPriceHT(model.InitialPrice);
                    return Ok(sellingPrice);
                }
            }
            catch (Exception ex)
            {
                string message = "An error occurred while calculating the selling price.";
                _logger.LogError(ex, message);
                return BadRequest(message);
            }
        }
    }
}

