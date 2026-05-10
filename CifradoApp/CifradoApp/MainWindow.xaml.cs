using System.Windows;
using CifradoApp.Forms;

namespace CifradoApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MainContent.Content = new EncryptForm();
        }

        private void btnCifrar_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new EncryptForm();
        }

        private void btnDescifrar_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new DecryptForm();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}