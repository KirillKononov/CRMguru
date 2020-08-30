using CountriesInformation.Api.Interfaces;
using CountriesInformation.Api.Mapper;
using CountriesInformation.Api.Services;
using CountriesInformation.DataAccess.Interfaces;
using CountriesInformation.DataAccess.Repositories;
using CountriesInformation.Interfaces;
using CountriesInformation.Mapper;
using Microsoft.Extensions.DependencyInjection;

namespace CountriesInformation
{
    public static class ServicesBuilder
    {
        public static void BuildServices(IServiceCollection services)
        {
            services.AddScoped<ICityRepository, CityRepository>();

            services.AddScoped<IRegionRepository, RegionRepository>();

            services.AddScoped<ICountryRepository, CountryRepository>();

            services.AddScoped<ICountryService, CountryService>();

            services.AddSingleton<IMapperApi, MapperApi>();
            services.AddSingleton<IMapperForViewModels, MapperForViewModels>();
        }
    }
}
