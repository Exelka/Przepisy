using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Przepisy.Models;
using Przepisy.ViewModels;

namespace Przepisy.Views
{
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _viewModel;
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
            ApplyTheme(_isDarkTheme);
            ThemeToggleButton.Content = _isDarkTheme ? "Jasny motyw" : "Ciemny motyw";
        }

        private void ApplyTheme(bool dark)
        {
            if (dark)
            {
                SetBrush("WindowBackgroundBrush", "#FF1E1E1E");
                SetBrush("WindowForegroundBrush", "#FFFFFFFF");
                SetBrush("HeaderBackgroundBrush", "#FF1B5E20");
                SetBrush("ToolbarBackgroundBrush", "#FF252525");
                SetBrush("InputBackgroundBrush", "#FF2D2D2D");
                SetBrush("InputForegroundBrush", "#FFFFFFFF");
                SetBrush("InputBorderBrush", "#FF444444");
                SetBrush("ButtonBackgroundBrush", "#FF388E3C");
                SetBrush("ButtonForegroundBrush", "#FFFFFFFF");
                SetBrush("ButtonHoverBrush", "#FF4CAF50");
                SetBrush("CardBackgroundBrush", "#FF2D2D2D");
                SetBrush("CardBorderBrush", "#FF444444");
                SetBrush("CardHoverBorderBrush", "#FF81C784");
                SetBrush("CardTitleBrush", "#FF81C784");
                SetBrush("CardTextBrush", "#FFB0B0B0");
                SetBrush("CardTimeBrush", "#FF81C784");
                SetBrush("BadgeBackgroundBrush", "#FF388E3C");
                SetBrush("DifficultyEasyBrush", "#FF388E3C");
                SetBrush("DifficultyMediumBrush", "#FFB26A00");
                SetBrush("DifficultyHardBrush", "#FFC62828");
            }
            else
            {
                SetBrush("WindowBackgroundBrush", "#FFFFFFFF");
                SetBrush("WindowForegroundBrush", "#FF1E1E1E");
                SetBrush("HeaderBackgroundBrush", "#FF2E7D32");
                SetBrush("ToolbarBackgroundBrush", "#FFF5F5F5");
                SetBrush("InputBackgroundBrush", "#FFFFFFFF");
                SetBrush("InputForegroundBrush", "#FF1E1E1E");
                SetBrush("InputBorderBrush", "#FF4CAF50");
                SetBrush("ButtonBackgroundBrush", "#FF4CAF50");
                SetBrush("ButtonForegroundBrush", "#FFFFFFFF");
                SetBrush("ButtonHoverBrush", "#FF388E3C");
                SetBrush("CardBackgroundBrush", "#FFFFFFFF");
                SetBrush("CardBorderBrush", "#FFE0E0E0");
                SetBrush("CardHoverBorderBrush", "#FF4CAF50");
                SetBrush("CardTitleBrush", "#FF2E7D32");
                SetBrush("CardTextBrush", "#FF666666");
                SetBrush("CardTimeBrush", "#FF4CAF50");
                SetBrush("BadgeBackgroundBrush", "#FF4CAF50");
                SetBrush("DifficultyEasyBrush", "#FF4CAF50");
                SetBrush("DifficultyMediumBrush", "#FFFF9800");
                SetBrush("DifficultyHardBrush", "#FFF44336");
            }
        }

        private void SetBrush(string key, string color)
        {
            var newColor = (Color)ColorConverter.ConvertFromString(color);
            Application.Current.Resources[key] = new SolidColorBrush(newColor);
        }
    }
}
