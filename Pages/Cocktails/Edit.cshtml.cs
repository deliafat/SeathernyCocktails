using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SeathernyCocktails.Data;
using SeathernyCocktails.Models;

namespace SeathernyCocktails.Pages.Cocktails
{
    [Authorize(Roles = "Admin")]
    public class EditModel : CocktailCategoriesPageModel
    {
        private readonly SeathernyCocktails.Data.SeathernyCocktailsContext _context;

        public EditModel(SeathernyCocktails.Data.SeathernyCocktailsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cocktail Cocktail { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cocktail == null)
            {
                return NotFound();
            }

            Cocktail = await _context.Cocktail
                .Include(b => b.CocktailCategories)
                .ThenInclude(b => b.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Cocktail == null)
            {
                return NotFound();
            }

            PopulateAssignedCategoryData(_context, Cocktail);

            var bartenderList = _context.Bartender.Select(x => new
            {
                x.ID,
                FullName = x.LastName + " " + x.FirstName
            });
            ViewData["BartenderID"] = new SelectList(bartenderList, "ID", "FullName");
            ViewData["CollectionID"] = new SelectList(_context.Set<Collection>(), "ID", "Collect");
            ViewData["CategoryID"] = new SelectList(_context.Set<Category>(), "ID", "CategoryName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var cocktailToUpdate = await _context.Cocktail
                .Include(i => i.CocktailCategories)
                    .ThenInclude(i => i.Category)
                .FirstOrDefaultAsync(s => s.ID == id);

            if (cocktailToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Cocktail>(
                cocktailToUpdate,
                "Cocktail",
                i => i.Name, i => i.Bartender,
                i => i.Price))
            {
                UpdateCocktailCategories(_context, selectedCategories, cocktailToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care //este editata
            UpdateCocktailCategories(_context, selectedCategories, cocktailToUpdate);
            PopulateAssignedCategoryData(_context, cocktailToUpdate);
            return Page();
        }
    }

}