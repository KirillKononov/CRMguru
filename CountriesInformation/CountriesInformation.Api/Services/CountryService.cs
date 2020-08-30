using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CountriesInformation.Api.Dtos;
using CountriesInformation.Api.Interfaces;
using CountriesInformation.DataAccess.Entities;
using CountriesInformation.DataAccess.Interfaces;

namespace CountriesInformation.Api.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;

        public CountryService(ICountryRepository countryRepository, 
            ICityRepository cityRepository,
            IRegionRepository regionRepository,
            IMapperApi mapper)
        {
            _countryRepository = countryRepository;
            _cityRepository = cityRepository;
            _regionRepository = regionRepository;
            _mapper = mapper.CreateMapper();
        }

        public IEnumerable<CountryDto> GetAll()
        {
            var countries = _countryRepository.GetAll().ToList();

            if (!countries.ToList().Any())
            {
                throw new ArgumentException("There is no saved countries");
            }

            return countries.Select(c => _mapper.Map<CountryDto>(c));
        }

        public void Add(CountryDto countryDto)
        {
            if (countryDto == null)
                throw new ArgumentException("There was not received country to save");

            var city = _cityRepository.GetByName(countryDto.Capital.Name);
            var region = _regionRepository.GetByName(countryDto.Region.Name);
            var countryFromDb = _countryRepository.GetByCode(countryDto.Code);

            if (city != null && countryFromDb == null) 
            {
                countryDto.CityId = city.Id;
                countryDto.Capital = null;
            }

            if (region != null && countryFromDb == null)
            {
                countryDto.RegionId = region.Id;
                countryDto.Region = null;
            }
            
            if (countryFromDb != null)
                Update(countryDto, countryFromDb);
            else
            {
                var country = _mapper.Map<Country>(countryDto);
                _countryRepository.Create(country);
            }
        }

        private void Update(CountryDto countryDto, Country countryFromDb)
        {
            countryFromDb.Area = countryDto.Area;
            countryFromDb.Capital.Name = countryDto.Capital.Name;
            countryFromDb.Code = countryDto.Code;
            countryFromDb.Population = countryDto.Population;
            countryFromDb.Region.Name = countryDto.Region.Name;

            _countryRepository.Update(countryFromDb);
        }
    }
}
