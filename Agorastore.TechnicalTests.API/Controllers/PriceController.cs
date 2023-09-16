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

        [HttpPost("CalculateSellingPrice")]
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

