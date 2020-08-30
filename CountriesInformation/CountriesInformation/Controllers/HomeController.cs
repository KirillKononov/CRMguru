using System.Linq;
using AutoMapper;
using CountriesInformation.Api.Dtos;
using CountriesInformation.Api.Interfaces;
using CountriesInformation.Interfaces;
using Microsoft.AspNetCore.Mvc;
using CountriesInformation.Models;

namespace CountriesInformation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICountryService _countryService;
        private readonly IMapper _mapper;

        public HomeController(ICountryService countryService, IMapperForViewModels mapper)
        {
            _countryService = countryService;
            _mapper = mapper.CreateMapper();
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
    }
}
