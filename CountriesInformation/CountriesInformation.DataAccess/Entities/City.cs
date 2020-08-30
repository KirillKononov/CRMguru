using System.ComponentModel.DataAnnotations;

namespace CountriesInformation.DataAccess.Entities
{
    public class City
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual Country Country { get; set; }
    }
}
