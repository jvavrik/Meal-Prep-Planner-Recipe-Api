using Microsoft.AspNetCore.Mvc;
using RecipeApi.Data;
using RecipeApi.Models;

namespace RecipeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly RecipeRepository _recipeRepository;
        public RecipesController() 
        { 
            _recipeRepository = new RecipeRepository();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Recipe>> Get() 
        {
            return Ok(_recipeRepository.GetAllRecipes());
        }

        [HttpGet("{id:int}")]
        public ActionResult<Recipe> Get(int id)
        {
            return Ok(_recipeRepository.GetRecipeById(id));
        }

        [HttpPost]
        public ActionResult<Recipe> Post(Recipe recipe) 
        {
            return Ok(_recipeRepository.Create(recipe));
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            _recipeRepository.Delete(id);

            return Ok();
        }

        [HttpPut]
        public ActionResult Update(Recipe recipe) 
        { 
            _recipeRepository.Update(recipe); 

            return Ok();
        }

        [HttpGet("search")]
        public ActionResult<IEnumerable<Recipe>> Search([FromQuery] string query)
        {
            //todo: add search
            return Ok(_recipeRepository.GetAllRecipes());
        }
            
    }
}
