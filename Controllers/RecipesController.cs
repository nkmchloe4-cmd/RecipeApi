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

    [HttpPost("upload")]
    public async Task<ActionResult<string>> UploadImage(IFormFile file)
    {
        const long maxSizeBytes = 2 * 1024 * 1024;

        if (file == null || file.Length == 0)
        {
            return BadRequest("Ingen fil vald.");
        }

        if (file.Length > maxSizeBytes)
        {
            return BadRequest("Filen är för stor. Max 2MB tillåtet.");
        }

        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".webp" };
        var extension = Path.GetExtension(file.FileName).ToLowerInvariant();

        if (!allowedExtensions.Contains(extension))
        {
            return BadRequest("Endast bildfiler (jpg, png, webp) är tillåtna.");
        }

        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
        Directory.CreateDirectory(uploadsFolder);

        var fileName = $"{Guid.NewGuid()}{extension}";
        var filePath = Path.Combine(uploadsFolder, fileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        var relativePath = $"/uploads/{fileName}";
        return Ok(new { path = relativePath });
    }
}