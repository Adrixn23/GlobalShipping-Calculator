using GlobalShipping.Core.Entities;
using GlobalShipping.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalShipping.Services.Services
{
    public class ShippingService : IShippingService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IEnumerable<IShippingStrategy> _shippingStrategies;

        public ShippingService(
            ICountryRepository countryRepository, 
            IEnumerable<IShippingStrategy> shippingStrategies)
        {
            _countryRepository = countryRepository;
            _shippingStrategies = shippingStrategies;
        }

        public async Task<ShippingQuote> CalculateShippingAsync(string countryCode, decimal weight)
        {
            if (weight <= 0)
                throw new ArgumentException("El peso debe ser mayor a cero.", nameof(weight));

            // Validamos que el país exista en nuestra base de datos
            var country = await _countryRepository.GetCountryByCodeAsync(countryCode);
            if (country == null)
                throw new ArgumentException($"El país con código '{countryCode}' no está soportado o no existe.", nameof(countryCode));

            //  Buscamos la estrategia correcta (Open/Closed Principle en acción)
            var strategy = _shippingStrategies.FirstOrDefault(s => s.CanHandle(countryCode));
            if (strategy == null)
                throw new InvalidOperationException($"No se encontró una estrategia de envío para el país '{countryCode}'.");

            //Calculamos usando la tarifa de la BD y la regla específica de la estrategia
            var totalCost = strategy.Calculate(weight, country.BaseShippingRate);

            return new ShippingQuote
            {
                CountryName = country.Name,
                Weight = weight,
                TotalCost = totalCost
            };
        }
    }
}