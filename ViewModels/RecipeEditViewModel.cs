using System.Collections.ObjectModel;
using Przepisy.Models;

namespace Przepisy.ViewModels
{
    public class RecipeEditViewModel
    {
        public Recipe Recipe { get; }

        public ObservableCollection<string> Categories { get; } = new ObservableCollection<string>
        {
            "Śniadanie",
            "Obiad",
            "Kolacja",
            "Deser",
            "Przekąska"
        };

        public ObservableCollection<string> Trudnosci { get; } = new ObservableCollection<string>
        {
            "Łatwy",
            "Średni",
            "Trudny"
        };

        public RecipeEditViewModel(Recipe recipe)
        {
            Recipe = recipe;
        }
    }
}
