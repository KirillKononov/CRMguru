using System.Collections.Generic;
using CountriesInformation.DataAccess.Entities;

namespace CountriesInformation.DataAccess.Interfaces
{
    public interface ICityRepository
    {
        IEnumerable<City> GetAll();
        City GetByName(string name);
        void Create(City item);
        void Update(City item);
    }
}