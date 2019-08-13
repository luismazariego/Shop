namespace Shop.Web.Data.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Country : IEntity
    {
        public int Id { get; set; }

        [Required]
        [Display(Name="Country")]
        [MaxLength(50, ErrorMessage="The field {0} can only contain {1} characters")]
        public string Name { get; set; }

        public ICollection<City> Cities { get; set; }

        [Display(Name ="# Cities")]
        public int NumberCities { get { return Cities == null ? 0 : Cities.Count; } }
    }
}
