using Microsoft.AspNetCore.Mvc.RazorPages;
using SeathernyCocktails.Data;
namespace SeathernyCocktails.Models
{
    public class CocktailCategoriesPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(SeathernyCocktailsContext context,
        Cocktail cocktail)
        {
            var allCategories = context.Category;
            var cocktailCategories = new HashSet<int>(
            cocktail.CocktailCategories.Select(c => c.CategoryID)); //
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    CategoryName = cat.CategoryName,
                    Assigned = cocktailCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateCocktailCategories(SeathernyCocktailsContext context,
        string[] selectedCategories, Cocktail cocktailToUpdate)
        {
            if (selectedCategories == null)
            {
                cocktailToUpdate.CocktailCategories = new List<CocktailCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var cocktailCategories = new HashSet<int>
            (cocktailToUpdate.CocktailCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!cocktailCategories.Contains(cat.ID))
                    {
                        cocktailToUpdate.CocktailCategories.Add(
                        new CocktailCategory
                        {
                            CocktailID = cocktailToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (cocktailCategories.Contains(cat.ID))
                    {
                        CocktailCategory courseToRemove
                        = cocktailToUpdate
                        .CocktailCategories
                        .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}