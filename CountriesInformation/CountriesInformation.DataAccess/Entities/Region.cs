using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CountriesInformation.DataAccess.Entities
{
    public class Region
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual List<Country> Countries { get; set; }
    }
}
