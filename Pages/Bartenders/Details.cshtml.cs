using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SeathernyCocktails.Data;
using SeathernyCocktails.Models;

namespace SeathernyCocktails.Pages.Bartenders
{
    public class DetailsModel : PageModel
    {
        private readonly SeathernyCocktails.Data.SeathernyCocktailsContext _context;

        public DetailsModel(SeathernyCocktails.Data.SeathernyCocktailsContext context)
        {
            _context = context;
        }

      public Bartender Bartender { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Bartender == null)
            {
                return NotFound();
            }

            var bartender = await _context.Bartender.FirstOrDefaultAsync(m => m.ID == id);
            if (bartender == null)
            {
                return NotFound();
            }
            else 
            {
                Bartender = bartender;
            }
            return Page();
        }
    }
}
