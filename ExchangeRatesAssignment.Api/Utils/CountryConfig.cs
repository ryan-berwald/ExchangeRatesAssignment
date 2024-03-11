namespace ExchangeRatesAssignment.Api.Utils
{
    public record Country(string Name, string CountryCode, string CurrencyCode, decimal flatRate);
    public static class CountryConfig
    {
        public static Dictionary<string, Country> GetCountries()
        {
            return new Dictionary<string, Country>
            {
                {"GTM", new Country("Guatemala", "GTM", "GTQ", 0.056m)},
                {"IND", new Country("India", "IND", "INR", 3.213m)},
                {"MEX", new Country("Mexico", "MEX", "MXN", 0.024m)},
                {"PHL", new Country("Philippines", "PHL", "PHP", 2.437m)}
            };
        }
    }
}
