namespace CountriesInformation.Models
{
    public class CountryViewModel
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public CityViewModel Capital { get; set; }

        public double Area { get; set; }

        public int Population { get; set; }

        public RegionViewModel Region { get; set; }
    }
}
