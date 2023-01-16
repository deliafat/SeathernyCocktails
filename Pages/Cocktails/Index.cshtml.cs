using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SeathernyCocktails.Data;
using SeathernyCocktails.Models;

namespace SeathernyCocktails.Pages.Cocktails
{
    public class IndexModel : PageModel
    {
        private readonly SeathernyCocktails.Data.SeathernyCocktailsContext _context;

        public IndexModel(SeathernyCocktails.Data.SeathernyCocktailsContext context)
        {
            _context = context;
        }


        public IList<Cocktail> Cocktail { get; set; }
        public CocktailData CocktailD { get; set; }
        public int CocktailID { get; set; }
        public int CategoryID { get; set; }
        public string NameSort { get; set; }
        public string BartenderSort { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID, string sortOrder )
        {
            CocktailD = new CocktailData();
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            BartenderSort =String.IsNullOrEmpty(sortOrder) ? "bartender_desc" : "";
            CocktailD.Cocktails = await _context.Cocktail
                .Include(b => b.Bartender)
                .Include(b => b.Collection)
                .Include(b => b.CocktailCategories)
                .ThenInclude(b => b.Category)
                .AsNoTracking()
                .OrderBy(b => b.Name)
                .ToListAsync();
            if (id != null)
            {
                CocktailID = id.Value;
                Cocktail cocktail = CocktailD.Cocktails
                    .Where(i => i.ID == id.Value).Single();
                CocktailD.Categories = cocktail.CocktailCategories.Select(s => s.Category);
            }
            switch (sortOrder)
            {
                case "name_desc":
                    CocktailD.Cocktails = CocktailD.Cocktails.OrderByDescending(s => s.Name);
                    break;
                case "bartender_desc":
                    CocktailD.Cocktails = CocktailD.Cocktails.OrderByDescending(s => s.Bartender.FullName);
                    break;
            }
        }
    }
}