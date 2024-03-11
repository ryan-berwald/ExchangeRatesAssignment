using ExchangeRatesAssignment.Api.Domain;
using ExchangeRatesAssignment.Domain;
using System.Text.Json;

namespace ExchangeRatesAssignment.Repositories
{
    public class PartnerRatesRepository : IPartnerRatesRepository
    {
        public async Task<IEnumerable<PartnerRate>> GetPartnerRatesAsync(string countryCode, CancellationToken cancellationToken = default)
        {
            var validatedPartnerRates = Enumerable.Empty<PartnerRate>();

            string text = await File.ReadAllTextAsync(@"Repositories/PartnerRates.json", cancellationToken);
            var response = JsonSerializer.Deserialize<PartnerRatesServiceResponse>(text);

            //TODO: Implement the logic to populate validatedPartnerRates with the most recent exchange rates for a given country code.

            return validatedPartnerRates;
        }
    }
}
