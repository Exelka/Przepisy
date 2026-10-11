using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Przepisy.Models;
using Przepisy.Services;

namespace Przepisy.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly RecipeService _recipeService;
        private List<Recipe> _allRecipes;

        public ObservableCollection<Recipe> Recipes { get; } = new ObservableCollection<Recipe>();

        public ObservableCollection<string> Categories { get; } = new ObservableCollection<string>
        {
            "Wszystkie",
            "Śniadanie",
            "Obiad",
            "Kolacja",
            "Deser",
            "Przekąska"
        };

        public ObservableCollection<string> SortOptions { get; } = new ObservableCollection<string>
        {
            "Nazwa",
            "Czas",
            "Trudność",
            "Kategoria"
        };

        private string _searchText = "";

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged();
                ApplyFilter();
            }
        }

        private string _selectedCategory = "Wszystkie";

        public string SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                _selectedCategory = value;
                OnPropertyChanged();
                ApplyFilter();
            }
        }

        private string _selectedSort = "Nazwa";

        public string SelectedSort
        {
            get => _selectedSort;
            set
            {
                _selectedSort = value;
                OnPropertyChanged();
                ApplyFilter();
            }
        }

        private Recipe _selectedRecipe;

        public Recipe SelectedRecipe
        {
            get => _selectedRecipe;
            set
            {
                _selectedRecipe = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand DetailsCommand { get; }
        public ICommand RefreshCommand { get; }

        public event Action<Recipe> AddRequested;
        public event Action<Recipe> EditRequested;
        public event Action<Recipe> DeleteRequested;
        public event Action<Recipe> DetailsRequested;

        public MainViewModel()
        {
            _recipeService = new RecipeService();

            AddCommand = new RelayCommand(o => AddRequested?.Invoke(null));
            EditCommand = new RelayCommand(o => { if (SelectedRecipe != null) EditRequested?.Invoke(SelectedRecipe); });
            DeleteCommand = new RelayCommand(o => { if (SelectedRecipe != null) DeleteRequested?.Invoke(SelectedRecipe); });
            DetailsCommand = new RelayCommand(o => { if (SelectedRecipe != null) DetailsRequested?.Invoke(SelectedRecipe); });
            RefreshCommand = new RelayCommand(o => LoadRecipes());

            LoadRecipes();
        }

        public void LoadRecipes()
        {
            _allRecipes = _recipeService.LoadRecipes();
            ApplyFilter();
        }

        public void AddRecipe(Recipe recipe)
        {
            _allRecipes.Add(recipe);
            _recipeService.SaveRecipes(_allRecipes);
            ApplyFilter();
        }

        public void UpdateRecipe(Recipe recipe)
        {
            var index = _allRecipes.FindIndex(r => r.Id == recipe.Id);
            if (index >= 0)
            {
                _allRecipes[index] = recipe;
                _recipeService.SaveRecipes(_allRecipes);
                ApplyFilter();
            }
        }

        public void DeleteRecipe(Recipe recipe)
        {
            _allRecipes.RemoveAll(r => r.Id == recipe.Id);
            _recipeService.SaveRecipes(_allRecipes);
            ApplyFilter();
        }

        private void ApplyFilter()
        {
            if (_allRecipes == null) return;

            IEnumerable<Recipe> query = _allRecipes;

            if (!string.IsNullOrWhiteSpace(SearchText))
            {
                query = query.Where(r => r.Nazwa.ToLower().Contains(SearchText.ToLower()));
            }

            if (SelectedCategory != "Wszystkie")
            {
                query = query.Where(r => r.Kategoria == SelectedCategory);
            }

            switch (SelectedSort)
            {
                case "Czas":
                    query = query.OrderBy(r => r.CzasPrzygotowania);
                    break;
                case "Trudność":
                    query = query.OrderBy(r => r.Trudnosc);
                    break;
                case "Kategoria":
                    query = query.OrderBy(r => r.Kategoria);
                    break;
                default:
                    query = query.OrderBy(r => r.Nazwa);
                    break;
            }

            Recipes.Clear();
            foreach (var recipe in query)
            {
                Recipes.Add(recipe);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
