namespace RecipeApi.Models;

public class Recipe
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public string CookTime { get; set; } = "";
    public List<string> Ingredients { get; set; } = new();
    public List<string> Steps { get; set; } = new();
    public string? ImagePath { get; set; }
} 