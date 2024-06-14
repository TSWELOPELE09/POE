using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipeApp
{
    public class RecipeManager
    {
        public class Recipe
        {
            public string Name { get; set; }
            public List<(string Name, double Quantity, string Unit, double Calories, string FoodGroup)> Ingredients { get; set; }
            public List<string> Steps { get; set; }
            public double Scale { get; set; }

            public Recipe(string name)
            {
                Name = name;
                Ingredients = new List<(string, double, string, double, string)>();
                Steps = new List<string>();
                Scale = 1.0;
            }
        }

        private List<Recipe> recipes = new List<Recipe>();

        public void AddRecipe(string name)
        {
            recipes.Add(new Recipe(name));
        }

        public void AddIngredient(string recipeName, string name, double quantity, string unit, double calories, string foodGroup)
        {
            var recipe = recipes.FirstOrDefault(r => r.Name == recipeName);
            if (recipe != null)
            {
                recipe.Ingredients.Add((name, quantity, unit, calories, foodGroup));
            }
        }

        public void AddStep(string recipeName, string step)
        {
            var recipe = recipes.FirstOrDefault(r => r.Name == recipeName);
            if (recipe != null)
            {
                recipe.Steps.Add(step);
            }
        }

        public void ScaleRecipe(string recipeName, double factor)
        {
            var recipe = recipes.FirstOrDefault(r => r.Name == recipeName);
            if (recipe != null)
            {
                recipe.Scale *= factor;
                for (int i = 0; i < recipe.Ingredients.Count; i++)
                {
                    recipe.Ingredients[i] = (
                        recipe.Ingredients[i].Name,
                        recipe.Ingredients[i].Quantity * factor,
                        recipe.Ingredients[i].Unit,
                        recipe.Ingredients[i].Calories,
                        recipe.Ingredients[i].FoodGroup
                    );
                }
            }
        }

        public void ResetScale(string recipeName)
        {
            var recipe = recipes.FirstOrDefault(r => r.Name == recipeName);
            if (recipe != null)
            {
                recipe.Scale = 1.0;
            }
        }

        public void ClearRecipe(string recipeName)
        {
            recipes.RemoveAll(r => r.Name == recipeName);
        }

        public List<Recipe> GetRecipes()
        {
            return recipes.OrderBy(r => r.Name).ToList();
        }

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

        internal string GetFoodGroup(int option)
        {
            throw new NotImplementedException();
        }
    }

}
             




    
    


 
