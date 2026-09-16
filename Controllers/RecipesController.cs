using Microsoft.AspNetCore.Mvc;
using RecipeApi.Data;
using RecipeApi.Models;

namespace RecipeApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecipesController : ControllerBase
{
    [HttpGet]
    public ActionResult<List<Recipe>> GetAll()
    {
        return Ok(RecipeStore.Recipes);
    }

    [HttpPost]
    public ActionResult<Recipe> Create(Recipe newRecipe)
    {
        newRecipe.Id = RecipeStore.NextId;
        RecipeStore.NextId++;
        RecipeStore.Recipes.Add(newRecipe);
        return Ok(newRecipe);
    }

    [HttpPut("{id}")]
    public ActionResult<Recipe> Update(int id, Recipe updatedRecipe)
    {
        var recipe = RecipeStore.Recipes.FirstOrDefault(r => r.Id == id);

        if (recipe == null)
        {
            return NotFound();
        }

        recipe.Name = updatedRecipe.Name;
        recipe.Description = updatedRecipe.Description;
        recipe.CookTime = updatedRecipe.CookTime;
        recipe.Ingredients = updatedRecipe.Ingredients;
        recipe.Steps = updatedRecipe.Steps;
        recipe.ImagePath = updatedRecipe.ImagePath;

        return Ok(recipe);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var recipe = RecipeStore.Recipes.FirstOrDefault(r => r.Id == id);

        if (recipe == null)
        {
            return NotFound();
        }

        RecipeStore.Recipes.Remove(recipe);
        return NoContent();
    }
}