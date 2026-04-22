using GlobalShipping.Core.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GlobalShipping_Calculator.Models
{
    public class ShippingViewModel
    {
        public IEnumerable<Country> AvailableCountries { get; set; } = new List<Country>();

        [Required(ErrorMessage = "Seleccione el destino.")]
        public string SelectedCountryCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Peso obligatorio.")]
        [Range(0.1, 500.0, ErrorMessage = "El peso debe estar entre 0.1 y 500 Kg.")]
        public decimal Weight { get; set; }

        public ShippingQuote? QuoteResult { get; set; }
        public string? ErrorMessage { get; set; }
    }
}