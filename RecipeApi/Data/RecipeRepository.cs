using RecipeApi.Models;

namespace RecipeApi.Data
{
    public class RecipeRepository
    {
        public RecipeRepository() { }

        public IEnumerable<Recipe> GetAllRecipes()
        {
            return Recipes;
        }

        public Recipe GetRecipeById(int id)
        {
            return Recipes.SingleOrDefault(x => x.Id == id);
        }

        public Recipe Create(Recipe recipe)
        {
            var latestId = Recipes.OrderByDescending(x => x.Id).Select(x => x.Id).First();
            recipe.Id = latestId+1;
            Recipes.Add(recipe);
            return recipe;
        }

        public bool Delete(int id)
        {
            var index = Recipes.FindIndex(x => x.Id == id);

            Recipes.RemoveAt(index);

            return true;
        }

        public Recipe Update(Recipe recipe)
        {
            var index = Recipes.FindIndex(x => x.Id == recipe.Id);
            Recipes[index] = recipe;

            return Recipes[index];
        }

        //temp hard coded list
        private static List<Recipe> Recipes =  new List<Recipe>
        {
           new Recipe
            {
                Id = 1,
                Name = "Grilled Chicken Breast",
                Description = "Simple, healthy grilled chicken perfect for meal prep. Great with rice and vegetables.",
                PrepTimeMinutes = 10,
                CookTimeMinutes = 15,
                Servings = 4,
                Instructions = "1. Pat chicken breasts dry and season both sides with salt, pepper, garlic powder, and paprika.\n2. Preheat grill or grill pan to medium-high heat.\n3. Brush chicken with olive oil.\n4. Grill for 6-7 minutes per side until internal temperature reaches 165°F.\n5. Let rest for 5 minutes before slicing.\n6. Store in airtight containers for up to 4 days.",
                Ingredients = new[]
                {
                    "4 boneless skinless chicken breasts (6 oz each)",
                    "2 tbsp olive oil",
                    "1 tsp salt",
                    "1 tsp black pepper",
                    "1 tsp garlic powder",
                    "1 tsp paprika"
                }
            },

            new Recipe
            {
                Id = 2,
                Name = "Basic Pasta Marinara",
                Description = "Quick and easy pasta with homemade marinara sauce. A weeknight staple that reheats beautifully.",
                PrepTimeMinutes = 5,
                CookTimeMinutes = 20,
                Servings = 4,
                Instructions = "1. Bring a large pot of salted water to boil for pasta.\n2. Heat olive oil in a large pan over medium heat.\n3. Add minced garlic and cook for 1 minute until fragrant.\n4. Add crushed tomatoes, oregano, basil, salt, and pepper.\n5. Simmer sauce for 15 minutes, stirring occasionally.\n6. Cook pasta according to package directions, drain.\n7. Toss pasta with sauce.\n8. Serve with grated Parmesan if desired.",
                Ingredients = new[]
                {
                    "1 lb penne pasta",
                    "2 tbsp olive oil",
                    "4 cloves garlic, minced",
                    "28 oz can crushed tomatoes",
                    "1 tsp dried oregano",
                    "1 tsp dried basil",
                    "1/2 tsp salt",
                    "1/4 tsp black pepper",
                    "Parmesan cheese for serving (optional)"
                }
            }
        };
    }
}
