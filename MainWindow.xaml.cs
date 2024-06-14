using System;
using System.Windows;
using Microsoft.VisualBasic;

namespace RecipeApp
{
    public partial class MainWindow : Window
    {
        private RecipeManager recipeManager = new RecipeManager();

        public object OutputTextBox { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        private void AddRecipe_Click(object sender, RoutedEventArgs e)
        {
            var input = Interaction.InputBox("Enter recipe name:", "Add Recipe");
            if (!string.IsNullOrEmpty(input))
            {
                recipeManager.AddRecipe(input);
                OutputTextBox.AppendText($"Recipe '{input}' added.\n");
            }
        }

        private void AddIngredient_Click(object sender, RoutedEventArgs e)
        {
            var recipeName = Interaction.InputBox("Enter recipe name:", "Add Ingredient");
            var ingredientName = Interaction.InputBox("Enter ingredient name:", "Add Ingredient");
            var quantity = Interaction.InputBox("Enter quantity:", "Add Ingredient");
            var unit = Interaction.InputBox("Enter unit:", "Add Ingredient");
            var calories = Interaction.InputBox("Enter calories:", "Add Ingredient");

            if (double.TryParse(quantity, out double q) && double.TryParse(calories, out double c))
            {
                var foodGroupOption = Interaction.InputBox("Enter food group option (1-5):", "Add Ingredient");
                if (int.TryParse(foodGroupOption, out int option))
                {
                    var foodGroup = recipeManager.GetFoodGroup(option);
                    recipeManager.AddIngredient(recipeName, ingredientName, q, unit, c, foodGroup);
                    OutputTextBox.AppendText($"Ingredient '{ingredientName}' added to '{recipeName}'.\n");
                }
            }
        }

        private void AddStep_Click(object sender, RoutedEventArgs e)
        {
            var recipeName = Interaction.InputBox("Enter recipe name:", "Add Step");
            var step = Interaction.InputBox("Enter step:", "Add Step");
            recipeManager.AddStep(recipeName, step);
            OutputTextBox.AppendText($"Step added to '{recipeName}'.\n");
        }

        private void DisplayRecipes_Click(object sender, RoutedEventArgs e)
        {
            OutputTextBox.AppendText("Recipes:\n");
            foreach (var recipe in recipeManager.GetRecipes())
            {
                OutputTextBox.AppendText($"{recipe.Name}\n");
            }
        }

        private void DisplayRecipe_Click(object sender, RoutedEventArgs e)
        {
            var recipeName = Interaction.InputBox("Enter recipe name:", "Display Recipe");
            OutputTextBox.AppendText(recipeManager.DisplayRecipe(recipeName));
        }

        private void ScaleRecipe_Click(object sender, RoutedEventArgs e)
        {
            var recipeName = Interaction.InputBox("Enter recipe name:", "Scale Recipe");
            var scale = Interaction.InputBox("Enter scale factor:", "Scale Recipe");

            if (double.TryParse(scale, out double factor))
            {
                recipeManager.ScaleRecipe(recipeName, factor);
                OutputTextBox.AppendText($"Recipe '{recipeName}' scaled by {factor}.\n");
            }
        }

        private void ResetScale_Click(object sender, RoutedEventArgs e)
        {
            var recipeName = Interaction.InputBox("Enter recipe name:", "Reset Scale");
            recipeManager.ResetScale(recipeName);
            OutputTextBox.AppendText($"Recipe '{recipeName}' scale reset.\n");
        }

        private void ClearRecipe_Click(object sender, RoutedEventArgs e)
        {
            var recipeName = Interaction.InputBox("Enter recipe name:", "Clear Recipe");
            recipeManager.ClearRecipe(recipeName);
            OutputTextBox.AppendText($"Recipe '{recipeName}' cleared.\n");
        }
    }
}