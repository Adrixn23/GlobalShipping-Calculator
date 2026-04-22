using GlobalShipping.Core.Entities;
using GlobalShipping.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using GlobalShipping_Calculator.Models;

namespace GlobalShipping_Calculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly IShippingService _shippingService;
        private readonly ICountryRepository _countryRepo;

        public HomeController(IShippingService shippingService, ICountryRepository countryRepo)
        {
            _shippingService = shippingService;
            _countryRepo = countryRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(new ShippingViewModel 
            { 
                AvailableCountries = await _countryRepo.GetAllActiveCountriesAsync() 
            });
        }

        [HttpPost]
        public async Task<IActionResult> Index(ShippingViewModel model)
        {
            model.AvailableCountries = await _countryRepo.GetAllActiveCountriesAsync();

            if (!ModelState.IsValid) return View(model);

            try
            {
                model.QuoteResult = await _shippingService.CalculateShippingAsync(model.SelectedCountryCode, model.Weight);
            }
            catch (Exception ex)
            {
                model.ErrorMessage = ex.Message;
            }

            return View(model);
        }

        public IActionResult Privacy() => View();
    }
}