using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Przepisy.Models;

namespace Przepisy.Services
{
    public class RecipeService
    {
        private readonly string _filePath = "przepisy.json";

        public List<Recipe> LoadRecipes()
        {
            try
            {
                if (File.Exists(_filePath))
                {
                    string json = File.ReadAllText(_filePath);
                    return JsonSerializer.Deserialize<List<Recipe>>(json) ?? new List<Recipe>();
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Błąd ładowania: " + ex.Message, "BłąD", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
            return new List<Recipe>();
        }

        public void SaveRecipes(List<Recipe> recipes)
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(recipes, options);
                File.WriteAllText(_filePath, json);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Błąd zapisu: " + ex.Message, "BłąD", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }
    }
}
