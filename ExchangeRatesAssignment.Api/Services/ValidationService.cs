using ExchangeRatesAssignment.Api.Interfaces;
using ExchangeRatesAssignment.Api.Utils;

namespace ExchangeRatesAssignment.Api.Services;

public class ValidationService: IValidationService
{
    public List<string>? ValidateCountryCode(string countryCode)
    {
        var countries = CountryConfig.GetCountries();
        var errors = new List<string>();
        if (countryCode.Length != 3)
        {
            errors.Add("Country code must be 3 characters.");
        }
        
        if (!countries.ContainsKey(countryCode))
        {
            errors.Add("Country code not supported.");
        }

        return errors;
    }
}