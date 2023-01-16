using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SeathernyCocktails.Data;
using SeathernyCocktails.Models;

namespace SeathernyCocktails.Pages.Cocktails
{
    [Authorize(Roles ="Admin")]
    public class CreateModel : CocktailCategoriesPageModel
    {
        private readonly SeathernyCocktails.Data.SeathernyCocktailsContext _context;

        public CreateModel(SeathernyCocktails.Data.SeathernyCocktailsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var bartenderList = _context.Bartender.Select(x => new
            {
                x.ID,
                FullName = x.LastName + " " + x.FirstName
            });
            ViewData["BartenderID"] = new SelectList(bartenderList, "ID", "FullName");
            ViewData["CollectionID"] = new SelectList(_context.Set<Collection>(), "ID", "Collect");
            ViewData["CategoryID"] = new SelectList(_context.Set<Category>(), "ID", "CategoryName");

            var cocktail = new Cocktail();
            cocktail.CocktailCategories = new List<CocktailCategory>();

            PopulateAssignedCategoryData(_context, cocktail);

            return Page();
        }

        [BindProperty]
        public Cocktail Cocktail { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newCocktail = new Cocktail();
            if (selectedCategories != null)
            {
                newCocktail.CocktailCategories = new List<CocktailCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new CocktailCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newCocktail.CocktailCategories.Add(catToAdd);
                }
            }
            Cocktail.CocktailCategories = newCocktail.CocktailCategories;

            _context.Cocktail.Add(Cocktail);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");

            PopulateAssignedCategoryData(_context, newCocktail);
            return Page();
        }
    }
}