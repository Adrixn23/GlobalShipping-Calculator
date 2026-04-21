using GlobalShipping.Core.Interfaces;

namespace GlobalShipping.Services.Strategies
{
    public class UsShippingStrategy : IShippingStrategy
    {
        public bool CanHandle(string countryCode) => countryCode.ToUpper() == "US";

        public decimal Calculate(decimal weight, decimal baseRate)
        {
            // Regla de negocio de US: peso * tarifa (8 USD desde BD)
            return weight * baseRate;
        }
    }
}