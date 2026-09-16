using RecipeApi.Models;

namespace RecipeApi.Data;

public static class RecipeStore
{
    public static List<Recipe> Recipes = new()
    {
        new Recipe
        {
            Id = 1,
            Name = "Spaghetti Carbonara",
            Description = "Krämig italiensk pastarätt med ägg, bacon och parmesan.",
            CookTime = "25 minuter",
            Ingredients = new List<string> { "400g spaghetti", "150g bacon", "3 ägg", "1 dl parmesan" },
            Steps = new List<string> { "Koka spaghetti", "Stek bacon", "Blanda ägg och parmesan", "Blanda allt" }
        }
    };

    public static int NextId = 2;
}