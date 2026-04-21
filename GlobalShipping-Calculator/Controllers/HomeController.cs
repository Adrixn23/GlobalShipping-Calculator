using GlobalShipping_Calculator.Models;
using GlobalShipping.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace GlobalShipping_Calculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly IShippingService _shippingService;
        private readonly ICountryRepository _countryRepository;

        // Inyección de Dependencias
        public HomeController(IShippingService shippingService, ICountryRepository countryRepository)
        {
            _shippingService = shippingService;
            _countryRepository = countryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var viewModel = new ShippingViewModel
            {
                // Le pasamos a la vista los países disponibles directamente desde nuestra base de datos
                AvailableCountries = await _countryRepository.GetAllActiveCountriesAsync()
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(ShippingViewModel model)
        {
            // Siempre recargamos los países para volver a llenar el <select> en caso de error o recarga
            model.AvailableCountries = await _countryRepository.GetAllActiveCountriesAsync();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                // Delegamos la lógica al servicio. El controlador NO calcula nada. 
                // Esto cumple estrictamente con la Arquitectura en Capas y SRP.
                model.QuoteResult = await _shippingService.CalculateShippingAsync(model.SelectedCountryCode, model.Weight);
            }
            catch (System.Exception ex)
            {
                model.ErrorMessage = ex.Message;
            }

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}