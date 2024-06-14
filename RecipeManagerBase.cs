using System.Linq;

namespace RecipeApp
{
    public class RecipeManagerBase
    {

        public string DisplayRecipe(string recipeName)
        {
            var recipe = recipes.FirstOrDefault(r => r.Name == recipeName);
            if (recipe != null)
            {
                string result = $"Recipe: {recipe.Name}\n";
                foreach (var ingredient in recipe.Ingredients)
                {
                    result += $"{ingredient.Quantity * recipe.Scale} {ingredient.Unit} of {ingredient.Name} (Calories: {ingredient.Calories}, Food Group: {ingredient.FoodGroup})\n";
                }

                double totalCalories = recipe.Ingredients.Sum(i => i.Calories * i.Quantity * recipe.Scale);
                result += $"Total Calories: {totalCalories}\n";

                if (totalCalories > 300)
                {
                    result += "Warning: This recipe exceeds 300 calories!\n";
                }

                result += "\nSteps:\n";
                foreach (var step in recipe.Steps)
                {
                    result += step + "\n";
                }

                return result;
            }
            else
            {
                return "Recipe not found.\n";
            }
        }
    }
}