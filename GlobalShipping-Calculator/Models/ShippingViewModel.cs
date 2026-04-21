using GlobalShipping.Core.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GlobalShipping_Calculator.Models
{
    // Este ViewModel sirve como puente exclusivo para la Vista.
    // Cumple con SRP, separando los datos de visualización del Modelo de Dominio.
    public class ShippingViewModel
    {
        public IEnumerable<Country> AvailableCountries { get; set; } = new List<Country>();

        [Required(ErrorMessage = "Debe seleccionar un país de destino.")]
        [Display(Name = "País de Destino")]
        public string SelectedCountryCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "El peso es obligatorio.")]
        [Range(0.1, double.MaxValue, ErrorMessage = "El peso debe ser mayor a cero.")]
        [Display(Name = "Peso del Paquete (Kg)")]
        public decimal Weight { get; set; }

        public ShippingQuote? QuoteResult { get; set; }
        public string? ErrorMessage { get; set; }
    }
}