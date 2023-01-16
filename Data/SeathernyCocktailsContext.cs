using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SeathernyCocktails.Models;

namespace SeathernyCocktails.Data
{
    public class SeathernyCocktailsContext : DbContext
    {
        public SeathernyCocktailsContext (DbContextOptions<SeathernyCocktailsContext> options)
            : base(options)
        {
        }

        public DbSet<SeathernyCocktails.Models.Cocktail> Cocktail { get; set; } = default!;

        public DbSet<SeathernyCocktails.Models.Bartender> Bartender { get; set; }

        public DbSet<SeathernyCocktails.Models.Category> Category { get; set; }

        public DbSet<SeathernyCocktails.Models.Collection> Collection { get; set; }

        public DbSet<SeathernyCocktails.Models.Member> Member { get; set; }

        public DbSet<SeathernyCocktails.Models.Sale> Sale { get; set; }
    }
}
