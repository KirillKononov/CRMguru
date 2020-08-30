using AutoMapper;
using CountriesInformation.Api.Dtos;
using CountriesInformation.Api.Interfaces;
using CountriesInformation.DataAccess.Entities;

namespace CountriesInformation.Api.Mapper
{
    public class MapperApi : IMapperApi
    {
        public IMapper CreateMapper()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<City, CityDto>().ReverseMap();
                cfg.CreateMap<Country, CountryDto>().ReverseMap();
                cfg.CreateMap<Region, RegionDto>().ReverseMap();
            }).CreateMapper();
        }
    }
}
