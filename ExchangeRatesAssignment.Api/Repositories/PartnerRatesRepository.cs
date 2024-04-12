﻿using ExchangeRatesAssignment.Api.Domain;
using System.Text.Json;

namespace ExchangeRatesAssignment.Repositories
{
    public class PartnerRatesRepository : IPartnerRatesRepository
    {
        // Reads and returns the input partner rates from the provided JSON file PartnerRates.json
        public async Task<IEnumerable<PartnerRate>> GetPartnerRatesAsync(string countryCode, CancellationToken cancellationToken = default)
        {
            string text = await File.ReadAllTextAsync(@"Repositories/PartnerRates.json", cancellationToken);
            var response = JsonSerializer.Deserialize<IList<PartnerRate>>(text);

            return response;
        }
    }
}
