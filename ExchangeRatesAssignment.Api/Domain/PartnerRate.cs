namespace ExchangeRatesAssignment.Api.Domain
{
    public record PartnerRate(string Currency, string PaymentMethod, string DeliveryMethod, decimal Rate, DateTimeOffset AcquiredDate);
}
