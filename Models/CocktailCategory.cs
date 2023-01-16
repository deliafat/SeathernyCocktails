namespace SeathernyCocktails.Models
{
    public class CocktailCategory
    {
        public int ID { get; set; }
        public int CocktailID { get; set; }
        public Cocktail Cocktail { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}

