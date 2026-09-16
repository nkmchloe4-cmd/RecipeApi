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
}