using System.Windows;
using Przepisy.Models;
using Przepisy.Services;
using Przepisy.ViewModels;

namespace Przepisy.Views
{
    public partial class MainWindow : Window
    {
        private MainViewModel _viewModel;
        private RecipeService _recipeService;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MainViewModel();
            _recipeService = new RecipeService();
            DataContext = _viewModel;
            RecipesGrid.ItemsSource = _viewModel.Recipes;
        }

        private void AddRecipe_Click(object sender, RoutedEventArgs e)
        {
            var editWindow = new RecipeEditWindow();
            if (editWindow.ShowDialog() == true)
            {
                Refresh();
            }
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void Refresh()
        {
            _viewModel = new MainViewModel();
            DataContext = _viewModel;
            RecipesGrid.ItemsSource = _viewModel.Recipes;
        }
    }
}
