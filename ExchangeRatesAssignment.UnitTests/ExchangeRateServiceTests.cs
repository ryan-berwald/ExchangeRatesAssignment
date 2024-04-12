using ExchangeRatesAssignment.Api.Interfaces;
using ExchangeRatesAssignment.Api.Services;
using ExchangeRatesAssignment.Repositories;

namespace ExchangeRatesAssignment.UnitTests;

public class ExchangeRateServiceTests
{
    private static readonly IPartnerRatesRepository _partnerRatesRepository = new PartnerRatesRepository();
    private static readonly IExchangeRateService _exchangeRateService = new ExchangeRateService(_partnerRatesRepository);

    
    [Theory]
    [InlineData("GTM", "GTQ")]
    [InlineData("IND", "INR")]
    [InlineData("MEX", "MXN")]
    [InlineData("PHL", "PHP")]
    public void GetDataFromFileSuccess(string countryCode, string expectedCurrency)
    {
        var partnerRate = _exchangeRateService.ConvertExchangeRate(countryCode);
        Assert.Equal(partnerRate.Currency, expectedCurrency);
    }
}