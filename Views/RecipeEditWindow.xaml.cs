using System;
using System.Windows;
using Przepisy.Models;
using Przepisy.ViewModels;

namespace Przepisy.Views
{
    public partial class RecipeEditWindow : Window
    {
        public Recipe Recipe { get; private set; }

        public RecipeEditWindow(Recipe recipe = null)
        {
            InitializeComponent();

            Recipe = recipe == null ? new Recipe { Id = new Random().Next(10000) } : Copy(recipe);
            DataContext = new RecipeEditViewModel(Recipe);
            CzasBox.Text = Recipe.CzasPrzygotowania == 0 ? "" : Recipe.CzasPrzygotowania.ToString();

            Title = recipe == null ? "Dodaj przepis" : "Edytuj przepis";
        }

        private static Recipe Copy(Recipe recipe)
        {
            return new Recipe
            {
                Id = recipe.Id,
                Nazwa = recipe.Nazwa,
                Kategoria = recipe.Kategoria,
                CzasPrzygotowania = recipe.CzasPrzygotowania,
                Trudnosc = recipe.Trudnosc,
                Skladniki = recipe.Skladniki,
                Instrukcje = recipe.Instrukcje
            };
        }

        private void Zapisz_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Recipe.Nazwa) || string.IsNullOrWhiteSpace(Recipe.Skladniki))
            {
                MessageBox.Show("Nazwa i składniki są wymagane!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(CzasBox.Text, out int czas))
            {
                MessageBox.Show("Czas musi być liczbą!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Recipe.CzasPrzygotowania = czas;
            DialogResult = true;
        }

        private void Anuluj_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
