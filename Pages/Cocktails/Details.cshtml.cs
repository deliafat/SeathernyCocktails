using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SeathernyCocktails.Data;
using SeathernyCocktails.Models;

namespace SeathernyCocktails.Pages.Cocktails
{
    public class DetailsModel : PageModel
    {
        private readonly SeathernyCocktails.Data.SeathernyCocktailsContext _context;

        public DetailsModel(SeathernyCocktails.Data.SeathernyCocktailsContext context)
        {
            _context = context;
        }

        public Cocktail Cocktail { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cocktail == null)
            {
                return NotFound();
            }

            var cocktail = await _context.Cocktail.Include(b => b.Collection)
                                                  .FirstOrDefaultAsync(m => m.ID == id);
            if (cocktail == null)
            {
                return NotFound();
            }
            else
            {
                Cocktail = cocktail;
            }
            return Page();
        }
    }
}