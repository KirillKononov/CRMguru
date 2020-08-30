using System.Collections.Generic;
using System.Linq;
using CountriesInformation.DataAccess.DataAccess;
using CountriesInformation.DataAccess.Entities;
using CountriesInformation.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CountriesInformation.DataAccess.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DataBaseContext _db;

        public CountryRepository(DataBaseContext context)
        {
            _db = context;
        }

        public IEnumerable<Country> GetAll()
        {
            var countries = _db.Countries.ToList();
            return countries;
        }

        public Country GetByCode(string code)
        {
            var country = _db.Countries.FirstOrDefault(c => c.Code == code);
            return country;
        }

        public void Create(Country country)
        {
            _db.Countries.Add(country);
            _db.SaveChanges();
        }

        public void Update(Country country)
        {
            _db.Entry(country).State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}
