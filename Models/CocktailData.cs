namespace SeathernyCocktails.Models
{
    public class CocktailData
    {
        public IEnumerable<Cocktail> Cocktails { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<CocktailCategory> CocktailCategories { get; set; }
    }
}