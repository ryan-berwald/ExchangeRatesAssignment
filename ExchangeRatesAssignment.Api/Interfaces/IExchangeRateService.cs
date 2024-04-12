using ExchangeRatesAssignment.Api.Domain;

namespace ExchangeRatesAssignment.Api.Interfaces;

public interface IExchangeRateService
{
    public PartnerRate ConvertExchangeRate(string countryCode);
}