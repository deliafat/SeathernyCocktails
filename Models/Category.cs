using System.ComponentModel.DataAnnotations;

namespace SeathernyCocktails.Models
{
    public class Category
    {
        public int ID { get; set; }
        [Display(Name = "Category")]
        public string CategoryName { get; set; }
        public ICollection<CocktailCategory> CocktailCategories { get; set; }
    }
}
