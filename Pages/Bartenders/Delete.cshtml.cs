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
    public class DeleteModel : PageModel
    {
        private readonly SeathernyCocktails.Data.SeathernyCocktailsContext _context;

        public DeleteModel(SeathernyCocktails.Data.SeathernyCocktailsContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Bartender == null)
            {
                return NotFound();
            }
            var bartender = await _context.Bartender.FindAsync(id);

            if (bartender != null)
            {
                Bartender = bartender;
                _context.Bartender.Remove(Bartender);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
