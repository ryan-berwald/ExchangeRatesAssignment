using Microsoft.AspNetCore.Mvc;
using ExchangeRatesAssignment.Api.Contracts;
using ExchangeRatesAssignment.Api.Interfaces;

namespace ExchangeRatesAssignment.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExchangeRatesController(IExchangeRateService exchangeRateService, IValidationService validationService) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(
            [FromQuery] string countryCode)
        {
            var errors = validationService.ValidateCountryCode(countryCode.ToUpper());
            if (errors.Count > 0)
            {
                return BadRequest(errors.Select(e => $"{e}"));
            }
            
            return Ok(exchangeRateService.ConvertExchangeRate(countryCode.ToUpper()));
        }
    }
}
