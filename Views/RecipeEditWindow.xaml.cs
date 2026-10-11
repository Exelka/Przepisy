using System.Windows;
using Przepisy.Models;

namespace Przepisy.Views
{
    public partial class RecipeEditWindow : Window
    {
        public Recipe Recipe { get; private set; }
        private bool _isEdit;

        public RecipeEditWindow(Recipe recipe = null)
        {
            InitializeComponent();
            _isEdit = recipe != null;
            Recipe = recipe ?? new Recipe { Id = new System.Random().Next(10000) };

            NazwaBox.Text = Recipe.Nazwa;
            KategoriaBox.Text = Recipe.Kategoria;
            CzasBox.Text = Recipe.CzasPrzygotowania.ToString();
            TrudnoscBox.Text = Recipe.Trudnosc;
            SkladnikiBox.Text = Recipe.Skladniki;
            InstrukcjeBox.Text = Recipe.Instrukcje;

            Title = _isEdit ? "Edytuj przepis" : "Dodaj przepis";
        }

        private void Zapisz_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NazwaBox.Text) || string.IsNullOrWhiteSpace(SkladnikiBox.Text))
            {
                MessageBox.Show("Nazwa i składniki są wymagane!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(CzasBox.Text, out int czas))
            {
                MessageBox.Show("Czas musi być liczbą!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Recipe.Nazwa = NazwaBox.Text;
            Recipe.Kategoria = KategoriaBox.Text;
            Recipe.CzasPrzygotowania = czas;
            Recipe.Trudnosc = TrudnoscBox.Text;
            Recipe.Skladniki = SkladnikiBox.Text;
            Recipe.Instrukcje = InstrukcjeBox.Text;

            DialogResult = true;
        }

        private void Anuluj_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
