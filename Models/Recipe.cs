using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Przepisy.Models
{
    public class Recipe : INotifyPropertyChanged
    {
        private int _id;
        private string _nazwa = "";
        private string _kategoria = "";
        private int _czasPrzygotowania;
        private string _trudnosc = "";
        private string _skladniki = "";
        private string _instrukcje = "";

        public int Id
        {
            get => _id;
            set { _id = value; OnPropertyChanged(); }
        }

        public string Nazwa
        {
            get => _nazwa;
            set { _nazwa = value; OnPropertyChanged(); }
        }

        public string Kategoria
        {
            get => _kategoria;
            set { _kategoria = value; OnPropertyChanged(); }
        }

        public int CzasPrzygotowania
        {
            get => _czasPrzygotowania;
            set { _czasPrzygotowania = value; OnPropertyChanged(); }
        }

        public string Trudnosc
        {
            get => _trudnosc;
            set { _trudnosc = value; OnPropertyChanged(); }
        }

        public string Skladniki
        {
            get => _skladniki;
            set { _skladniki = value; OnPropertyChanged(); }
        }

        public string Instrukcje
        {
            get => _instrukcje;
            set { _instrukcje = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
