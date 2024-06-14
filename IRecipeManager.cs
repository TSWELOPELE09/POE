using System.Collections.Generic;

namespace RecipeApp
{
    public interface IRecipeManager
    {
        void AddIngredient(string recipeName, string name, double quantity, string unit, double calories, string foodGroup);
        void AddRecipe(string name);
        void AddStep(string recipeName, string step);
        void ClearRecipe(string recipeName);
        string DisplayRecipe(string recipeName);
        List<RecipeManager.Recipe> GetRecipes();
        void ResetScale(string recipeName);
        void ScaleRecipe(string recipeName, double factor);
    }
}