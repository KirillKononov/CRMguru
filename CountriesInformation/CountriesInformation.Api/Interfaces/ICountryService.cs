using System.Collections.Generic;
using CountriesInformation.Api.Dtos;

namespace CountriesInformation.Api.Interfaces
{
    public interface ICountryService
    {
        IEnumerable<CountryDto> GetAll();

        void Add(CountryDto item);
    }
}