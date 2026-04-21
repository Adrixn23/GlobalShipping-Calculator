using GlobalShipping.Core.Interfaces;

namespace GlobalShipping.Services.Strategies
{
    public class IndiaShippingStrategy : IShippingStrategy
    {
        public bool CanHandle(string countryCode) => countryCode.ToUpper() == "IN";

        public decimal Calculate(decimal weight, decimal baseRate)
        {
            // Regla de negocio de la India: peso * tarifa (5 USD desde BD)
            return weight * baseRate;
        }
    }
}