using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SeathernyCocktails.Data;
using SeathernyCocktails.Models;

namespace SeathernyCocktails.Pages.Sales
{
    public class IndexModel : PageModel
    {
        private readonly SeathernyCocktails.Data.SeathernyCocktailsContext _context;

        public IndexModel(SeathernyCocktails.Data.SeathernyCocktailsContext context)
        {
            _context = context;
        }

        public IList<Sale> Sale { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Sale != null)
            {
                Sale = await _context.Sale
                .Include(b => b.Cocktail)
                .ThenInclude(b => b.Bartender)
                .Include(b => b.Member)
                .ToListAsync();
            }
        }
    }
}
