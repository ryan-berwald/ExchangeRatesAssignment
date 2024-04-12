using ExchangeRatesAssignment.Api.Interfaces;
using ExchangeRatesAssignment.Api.Services;

namespace ExchangeRatesAssignment.UnitTests;

public class ValidationServiceTests
{
    private static readonly IValidationService _validationService = new ValidationService();

    [Fact]
    public void ValidCountryCodeReceived()
    {
        var countryCode = "MEX";
        var errors = _validationService.ValidateCountryCode(countryCode);
        Assert.Empty(errors);
    }

    [Fact]
    public void InvalidCountryCodeAndInvalidLengthReceived()
    {
        var countryCode = "m";
        var errors = _validationService.ValidateCountryCode(countryCode);
        Assert.Equal(2, errors.Count);
        Assert.Contains("Country code must be 3 characters.", errors);
        Assert.Contains("Country code not supported.", errors);
    }
        
    [Fact]
    public void InvalidCountryCodeReceived()
    {
        var countryCode = "ABC";
        var errors = _validationService.ValidateCountryCode(countryCode);
        Assert.Single(errors);
        Assert.Contains("Country code not supported.", errors);
    }
}