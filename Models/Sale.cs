using System.ComponentModel.DataAnnotations;

namespace SeathernyCocktails.Models
{
    public class Sale
    {public int ID { get; set; }   
        public int? MemberiID   { get; set; }   
        public Member? Member   { get; set; }
        public int? CocktailID  { get; set; }
        public Cocktail? Cocktail { get; set; }
        [DataType(DataType.Date)] public DateTime DataCumparare { get; set; }
    }
}
