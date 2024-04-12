using ExchangeRatesAssignment.Api.Controllers;
using ExchangeRatesAssignment.Api.Domain;
using ExchangeRatesAssignment.Api.Interfaces;
using ExchangeRatesAssignment.Api.Services;
using ExchangeRatesAssignment.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeRatesAssignment.UnitTests
{
    public class ExchangeRateControllerTests
    {
        private static readonly IPartnerRatesRepository _partnerRatesRepository = new PartnerRatesRepository();
        private static readonly IExchangeRateService _exchangeRateService = new ExchangeRateService(_partnerRatesRepository);
        private static readonly IValidationService _validationService = new ValidationService();
        private readonly ExchangeRatesController _exchangeRatesController = new ExchangeRatesController(_exchangeRateService, _validationService);

        [Fact]
        public void ValidDataReceived()
        {
            var result = _exchangeRatesController.Get("MEX");
            
            var okResult = result as OkObjectResult;
            
            Assert.Equal(200, okResult.StatusCode);
            Assert.IsType<PartnerRate>(okResult.Value);
        }
        
        [Fact]
        public void InvalidCountryCodeReceived()
        {
            var result = _exchangeRatesController.Get("MXN");
            
            var badResult = result as BadRequestObjectResult;
            
            Assert.Equal(400, badResult.StatusCode);
            Assert.IsAssignableFrom<IEnumerable<string>>(badResult.Value);
        }
        
        
    }
}