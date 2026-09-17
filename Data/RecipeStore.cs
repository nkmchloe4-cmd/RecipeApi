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
            ImagePath = "https://images.unsplash.com/photo-1612874742237-6526221588e3?w=400",
            Ingredients = new List<string> { "400g spaghetti", "150g bacon", "3 ägg", "1 dl parmesan" },
            Steps = new List<string> { "Koka spaghetti", "Stek bacon", "Blanda ägg och parmesan", "Blanda allt" }
        },
        new Recipe
        {
            Id = 2,
            Name = "Tacos",
            Description = "Mexikanska tacos med köttfärs och färska tillbehör.",
            CookTime = "25 minuter",
            ImagePath = "https://images.unsplash.com/photo-1552332386-f8dd00dc2f85?w=400",
            Ingredients = new List<string> {
                "8 tacoskal",
                "500g köttfärs",
                "1 paket tacokrydda",
                "Sallad, tomat, lök",
                "Riven ost",
                "Salsa och gräddfil"
            },
            Steps = new List<string> {
                "Bryn köttfärsen i en stekpanna",
                "Blanda i tacokryddan enligt förpackningen",
                "Skär grönsakerna i mindre bitar",
                "Värm tacoskalen enligt förpackningen",
                "Fyll skalen med kött och tillbehör efter smak"
            }
        },
        new Recipe
        {
            Id = 3,
            Name = "Pannkakor",
            Description = "Klassiska svenska pannkakor, perfekt till fika eller middag.",
            CookTime = "45 minuter",
            ImagePath = "https://images.unsplash.com/photo-1567620905732-2d1ec7ab7445?w=400",
            Ingredients = new List<string> {
                "3 dl mjöl",
                "6 dl mjölk",
                "3 ägg",
                "1 msk socker",
                "1 nypa salt",
                "Smör till stekning"
            },
            Steps = new List<string> {
                "Vispa ihop mjöl och lite mjölk till en klumpfri smet",
                "Tillsätt resten av mjölken, ägg, socker och salt",
                "Låt smeten vila i 30 minuter",
                "Stek tunna pannkakor i smör på medelvärme",
                "Servera med sylt och grädde"
            }
        }
    };
    
    public static int NextId = 4;
}