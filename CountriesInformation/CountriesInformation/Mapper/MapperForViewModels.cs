using AutoMapper;
using CountriesInformation.Api.Dtos;
using CountriesInformation.Interfaces;
using CountriesInformation.Models;

namespace CountriesInformation.Mapper
{
    public class MapperForViewModels : IMapperForViewModels
    {
        public IMapper CreateMapper()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CityDto, CityViewModel>().ReverseMap();
                cfg.CreateMap<CountryDto, CountryViewModel>().ReverseMap();
                cfg.CreateMap<RegionDto, RegionViewModel>().ReverseMap();
            }).CreateMapper();
        }
    }
}
