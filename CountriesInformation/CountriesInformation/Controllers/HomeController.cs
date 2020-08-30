using System.Diagnostics;
using System.Linq;
using AutoMapper;
using CountriesInformation.Api.Dtos;
using CountriesInformation.Api.Interfaces;
using CountriesInformation.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CountriesInformation.Models;

namespace CountriesInformation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICountryService _countryService;
        private readonly IMapper _mapper;

        public HomeController(ICountryService countryService, IMapperForViewModels mapper, ILogger<HomeController> logger)
        {
            _countryService = countryService;
            _mapper = mapper.CreateMapper();
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET: Countries
        [HttpGet]
        public JsonResult GetAll()
        {
            var countries = _countryService.GetAll().ToList();
            return Json(countries.Select(c => _mapper.Map<CountryViewModel>(c)));
        }

        // POST: Country
        [HttpPost]
        public ActionResult<CountryViewModel> Post(CountryViewModel countryViewModel)
        {
            var country = _mapper.Map<CountryDto>(countryViewModel);
            _countryService.Add(country);
            return Ok(countryViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
