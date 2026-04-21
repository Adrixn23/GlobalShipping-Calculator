using GlobalShipping.Core.Entities;
using GlobalShipping.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalShipping.Infrastructure.Data
{
    public class CountryRepository : ICountryRepository
    {
        private readonly AppDbContext _context;

        // Inyección de dependencias estricta: No se usa new AppDbContext()
        public CountryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Country>> GetAllActiveCountriesAsync()
        {
            return await _context.Countries
                                 .Where(c => c.IsActive)
                                 .ToListAsync();
        }

        public async Task<Country?> GetCountryByCodeAsync(string code)
        {
            return await _context.Countries
                                 .FirstOrDefaultAsync(c => c.Code.ToUpper() == code.ToUpper() && c.IsActive);
        }
    }
}