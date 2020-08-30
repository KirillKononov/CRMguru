using System.Collections.Generic;
using CountriesInformation.DataAccess.Entities;

namespace CountriesInformation.DataAccess.Interfaces
{
    public interface IRegionRepository
    {
        IEnumerable<Region> GetAll();
        Region GetByName(string name);
        void Create(Region item);
        void Update(Region item);
    }
}