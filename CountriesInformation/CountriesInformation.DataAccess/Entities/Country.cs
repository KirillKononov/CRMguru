using System.ComponentModel.DataAnnotations;

namespace CountriesInformation.DataAccess.Entities
{
    public class Country
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Code { get; set; }

        public int? CityId { get; set; }
        public virtual City Capital { get; set; }

        [Required]
        public double Area { get; set; }

        [Required]
        public int Population { get; set; }

        public int? RegionId { get; set; }
        public virtual Region Region { get; set; }
    }
}
