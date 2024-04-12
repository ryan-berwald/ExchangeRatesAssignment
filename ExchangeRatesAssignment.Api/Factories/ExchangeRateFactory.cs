using ExchangeRatesAssignment.Api.Domain;
using ExchangeRatesAssignment.Api.Utils;

namespace ExchangeRatesAssignment.Api.Factories;

public class ExchangeRateFactory
{
    public PartnerRate BuildLatestPartnerRatesModel(List<PartnerRate> partnerRates, string countryCode)
    {
        var country = CountryConfig.GetCountries()[countryCode];

        var latestRate = partnerRates.Select(e => e).Where(e => e.Currency.ToUpper() == country.CurrencyCode.ToUpper())
            .OrderByDescending(e => e.AcquiredDate).First();
        
        latestRate.Rate = AdjustRate(latestRate.Rate, country);
        
        return latestRate;
    }

    private decimal AdjustRate(decimal latestRate, Country country)
    {
        latestRate += country.flatRate;
        return Math.Round(latestRate, 2);
    }

}