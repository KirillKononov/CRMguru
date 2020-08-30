using System.Collections.Generic;
using System.Linq;
using CountriesInformation.DataAccess.DataAccess;
using CountriesInformation.DataAccess.Entities;
using CountriesInformation.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CountriesInformation.DataAccess.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly DataBaseContext _db;

        public RegionRepository(DataBaseContext context)
        {
            _db = context;
        }

        public IEnumerable<Region> GetAll()
        {
            var regions = _db.Regions.ToList();
            return regions;
        }

        public Region GetByName(string name)
        {
            var region = _db.Regions.FirstOrDefault(c => c.Name == name);
            return region;
        }

        public void Create(Region region)
        {
            _db.Regions.Add(region);
            _db.SaveChanges();
        }

        public void Update(Region region)
        {
            _db.Entry(region).State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}
