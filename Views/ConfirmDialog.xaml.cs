using System.Windows;

namespace Przepisy.Views
{
    public partial class ConfirmDialog : Window
    {
        public ConfirmDialog(string message)
        {
            InitializeComponent();
            MessageText.Text = message;
        }

        private void Tak_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Nie_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
