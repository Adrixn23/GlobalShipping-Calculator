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
        private readonly ICountryRepository _repo;
        private readonly IEnumerable<IShippingStrategy> _strategies;

        public ShippingService(ICountryRepository repo, IEnumerable<IShippingStrategy> strategies)
        {
            _repo = repo;
            _strategies = strategies;
        }

        public async Task<ShippingQuote> CalculateShippingAsync(string code, decimal weight)
        {
            // Validaciones basicas de entrada
            if (weight <= 0) throw new ArgumentException("Peso invalido.");

            var country = await _repo.GetCountryByCodeAsync(code);
            if (country == null) throw new Exception("Destino no soportado.");

            // Validacion de negocio: limite de carga
            if (weight > country.MaxWeight)
                throw new Exception($"El limite para {country.Name} es de {country.MaxWeight}kg.");

            // Buscamos la logica de calculo segun el pais (Strategy Pattern)
            var strategy = _strategies.FirstOrDefault(s => s.CanHandle(code));
            if (strategy == null) throw new Exception("Falta definir regla de calculo para este destino.");

            return new ShippingQuote
            {
                CountryName = country.Name,
                Weight = weight,
                TotalCost = strategy.Calculate(weight, country.BaseShippingRate)
            };
        }
    }
}