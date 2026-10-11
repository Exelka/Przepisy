using System.Windows;
using Przepisy.Models;

namespace Przepisy.Views
{
    public partial class RecipeDetailsWindow : Window
    {
        public RecipeDetailsWindow(Recipe recipe)
        {
            InitializeComponent();
            Title = recipe.Nazwa;
            DataContext = recipe;
        }

        private void Zamknij_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
