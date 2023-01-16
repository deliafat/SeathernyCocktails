namespace SeathernyCocktails.Models.ViewModels
{
    public class CategoryIndexData
    {public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<CocktailCategory> CocktailCategories { get; set; }
        public IEnumerable<Cocktail>Cocktails { get; set; }

    }
}
