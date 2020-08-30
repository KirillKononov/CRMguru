namespace CountriesInformation.Api.Dtos
{
    public class CountryDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public int? CityId { get; set; }
        public CityDto Capital { get; set; }

        public double Area { get; set; }

        public int Population { get; set; }

        public int? RegionId { get; set; }
        public RegionDto Region { get; set; }
    }
}
