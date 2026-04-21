using GlobalShipping.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GlobalShipping.Core.Interfaces
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> GetAllActiveCountriesAsync();
        Task<Country?> GetCountryByCodeAsync(string code);
    }
}