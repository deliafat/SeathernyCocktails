using System.ComponentModel.DataAnnotations;
using System.Runtime.ExceptionServices;

namespace SeathernyCocktails.Models
{
    public class Bartender
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public ICollection<Cocktail>? Cocktails { get; set; }
    }
}
