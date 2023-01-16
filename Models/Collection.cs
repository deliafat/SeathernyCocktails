using System.ComponentModel.DataAnnotations;

namespace SeathernyCocktails.Models
{
    public class Collection
    {
        public int ID { get; set; }
        [Display(Name = "Collection")]
        public string Collect { get; set; } 
        public ICollection<Cocktail>? Cocktails { get; set; }

    }
}
