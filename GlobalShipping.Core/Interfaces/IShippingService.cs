using GlobalShipping.Core.Entities;
using System.Threading.Tasks;

namespace GlobalShipping.Core.Interfaces
{
    public interface IShippingService
    {
        Task<ShippingQuote> CalculateShippingAsync(string countryCode, decimal weight);
    }
}