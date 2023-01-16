using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SeathernyCocktails.Data;
using SeathernyCocktails.Models;

namespace SeathernyCocktails.Pages.Collections
{
    public class IndexModel : PageModel
    {
        private readonly SeathernyCocktails.Data.SeathernyCocktailsContext _context;

        public IndexModel(SeathernyCocktails.Data.SeathernyCocktailsContext context)
        {
            _context = context;
        }

        public IList<Collection> Collection { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Collection != null)
            {
                Collection = await _context.Collection.ToListAsync();
            }
        }
    }
}
