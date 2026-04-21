using GlobalShipping.Core.Interfaces;

namespace GlobalShipping.Services.Strategies
{
    public class UkShippingStrategy : IShippingStrategy
    {
        public bool CanHandle(string countryCode) => countryCode.ToUpper() == "UK";

        public decimal Calculate(decimal weight, decimal baseRate)
        {
            // Regla de negocio de UK: peso * tarifa (10 USD desde BD)
            return weight * baseRate;
        }
    }
}