using ExchangeRatesAssignment.Api.Domain;

namespace ExchangeRatesAssignment.Repositories
{
    public interface IPartnerRatesRepository
    {
        Task<IEnumerable<PartnerRate>> GetPartnerRatesAsync(string countryCode, CancellationToken cancellationToken = default);
    }
}
