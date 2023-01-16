using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeathernyCocktails.Models
{
    public class Cocktail
    {
        public int ID { get; set; }
        [Display(Name = "Cocktail Name")]
        public string Name { get; set; }
        public int? BartenderID { get; set; }
        public Bartender? Bartender { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }
        public int? CollectionID { get; set; }
        public Collection? Collection { get; set; }

        public ICollection<CocktailCategory> CocktailCategories { get; set; }


    }
}