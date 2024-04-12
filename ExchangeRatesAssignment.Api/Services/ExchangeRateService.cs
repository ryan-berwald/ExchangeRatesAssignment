using ExchangeRatesAssignment.Api.Domain;
using ExchangeRatesAssignment.Api.Factories;
using ExchangeRatesAssignment.Api.Interfaces;
using ExchangeRatesAssignment.Repositories;

namespace ExchangeRatesAssignment.Api.Services;

public class ExchangeRateService(
    IPartnerRatesRepository partnerRatesRepository) : IExchangeRateService
{
    public PartnerRate ConvertExchangeRate(string countryCode)
    {
        var exchangeRateFactory = new ExchangeRateFactory();
        var partnerRates = partnerRatesRepository.GetPartnerRatesAsync(countryCode).Result.ToList();
        return exchangeRateFactory.BuildLatestPartnerRatesModel(partnerRates, countryCode);
    }
}