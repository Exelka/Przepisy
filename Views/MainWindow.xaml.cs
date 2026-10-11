using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Przepisy.Models;
using Przepisy.ViewModels;

namespace Przepisy.Views
{
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _viewModel;
        private ResourceDictionary _darkDictionary;
        private bool _isDarkTheme;

        public MainWindow()
        {
            InitializeComponent();

            _viewModel = new MainViewModel();
            _viewModel.AddRequested += OnAddRequested;
            _viewModel.EditRequested += OnEditRequested;
            _viewModel.DeleteRequested += OnDeleteRequested;
            _viewModel.DetailsRequested += OnDetailsRequested;

            DataContext = _viewModel;
        }

        private void OnAddRequested(Recipe recipe)
        {
            var window = new RecipeEditWindow();
            if (window.ShowDialog() == true)
            {
                _viewModel.AddRecipe(window.Recipe);
            }
        }

        private void OnEditRequested(Recipe recipe)
        {
            var window = new RecipeEditWindow(recipe);
            if (window.ShowDialog() == true)
            {
                _viewModel.UpdateRecipe(window.Recipe);
            }
        }

        private void OnDeleteRequested(Recipe recipe)
        {
            var confirm = new ConfirmDialog($"Czy na pewno usunąć przepis \"{recipe.Nazwa}\"?");
            if (confirm.ShowDialog() == true)
            {
                _viewModel.DeleteRecipe(recipe);
            }
        }

        private void OnDetailsRequested(Recipe recipe)
        {
            var window = new RecipeDetailsWindow(recipe);
            window.ShowDialog();
        }

        private void Card_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (sender is Border card && card.DataContext is Recipe recipe)
            {
                _viewModel.SelectedRecipe = recipe;
                _viewModel.DetailsCommand.Execute(null);
            }
        }

        private void ThemeToggle_Click(object sender, RoutedEventArgs e)
        {
            _isDarkTheme = !_isDarkTheme;

            if (_isDarkTheme)
            {
                _darkDictionary = new ResourceDictionary
                {
                    Source = new Uri("Resources/DarkTheme.xaml", UriKind.Relative)
                };
                Application.Current.Resources.MergedDictionaries.Add(_darkDictionary);
                ThemeToggleButton.Content = "Jasny motyw";
            }
            else
            {
                if (_darkDictionary != null)
                {
                    Application.Current.Resources.MergedDictionaries.Remove(_darkDictionary);
                }
                ThemeToggleButton.Content = "Ciemny motyw";
            }
        }
    }
}
