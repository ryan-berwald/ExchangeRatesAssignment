using ExchangeRatesAssignment.Api.Domain;
using System.Text.Json;

namespace ExchangeRatesAssignment.Repositories
{
    public class PartnerRatesRepository : IPartnerRatesRepository
    {
        public async Task<IEnumerable<PartnerRate>> GetPartnerRatesAsync(string countryCode, CancellationToken cancellationToken = default)
        {
            var partnerRates = Enumerable.Empty<PartnerRate>();

            string text = await File.ReadAllTextAsync(@"Repositories/PartnerRates.json", cancellationToken);
            var response = JsonSerializer.Deserialize<IList<PartnerRate>>(text);

            //TODO: Implement the logic to populate partnerRates.

            return partnerRates;
        }
    }
}
