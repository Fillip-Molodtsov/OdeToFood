using System.ComponentModel.DataAnnotations;

namespace OdeToFood.Core
{
    public class Restaurant
    {
        [Required, StringLength(80)]
        public string Name { get; set; }
        public int Id { get; set; }
        [Required, StringLength(80)]
        public string Location { get; set; }
        public CuisineType CuisineType { get; set; }
    }
}