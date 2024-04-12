namespace ExchangeRatesAssignment.Api.Interfaces;

public interface IValidationService
{
    public List<string> ValidateCountryCode(string CountryCode);
}