using System.Collections.Generic;
using CountriesInformation.DataAccess.Entities;

namespace CountriesInformation.DataAccess.Interfaces
{
    public interface ICountryRepository
    {
        IEnumerable<Country> GetAll();
        Country GetByCode(string code);
        void Create(Country item);
        void Update(Country item);
    }
}