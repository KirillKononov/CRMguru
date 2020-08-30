using System.Collections.Generic;
using System.Linq;
using CountriesInformation.DataAccess.DataAccess;
using CountriesInformation.DataAccess.Entities;
using CountriesInformation.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CountriesInformation.DataAccess.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly DataBaseContext _db;

        public CityRepository(DataBaseContext context)
        {
            _db = context;
        }

        public IEnumerable<City> GetAll()
        {
            var cities = _db.Cities.ToList();
            return cities;
        }

        public City GetByName(string name)
        {
            var city = _db.Cities.FirstOrDefault(c => c.Name == name);
            return city;
        }

        public void Create(City city)
        {
            _db.Cities.Add(city);
            _db.SaveChanges();
        }

        public void Update(City city)
        {
            _db.Entry(city).State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}
