using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SeathernyCocktails.Data;
using SeathernyCocktails.Models;

namespace SeathernyCocktails.Pages.Collections
{
    public class CreateModel : PageModel
    {
        private readonly SeathernyCocktails.Data.SeathernyCocktailsContext _context;

        public CreateModel(SeathernyCocktails.Data.SeathernyCocktailsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Collection Collection { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Collection.Add(Collection);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
