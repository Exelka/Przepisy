using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Przepisy.Models;
using Przepisy.Services;

namespace Przepisy.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly RecipeService _recipeService;
        private ObservableCollection<Recipe> _recipes;
        private string _searchText = "";

        public ObservableCollection<Recipe> Recipes
        {
            get => _recipes;
            set
            {
                _recipes = value;
                OnPropertyChanged();
            }
        }

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged();
                FilterRecipes();
            }
        }

        public MainViewModel()
        {
            _recipeService = new RecipeService();
            Recipes = new ObservableCollection<Recipe>(_recipeService.LoadRecipes());
        }

        private void FilterRecipes()
        {
            var all = _recipeService.LoadRecipes();
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                Recipes = new ObservableCollection<Recipe>(all);
            }
            else
            {
                var filtered = all.FindAll(r => r.Nazwa.ToLower().Contains(SearchText.ToLower()));
                Recipes = new ObservableCollection<Recipe>(filtered);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
