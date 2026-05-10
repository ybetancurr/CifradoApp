using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using CifradoApp.Core;
using CifradoApp.Helpers;

namespace CifradoApp.Forms
{
    public partial class DecryptForm : UserControl
    {
        public DecryptForm()
        {
            InitializeComponent();
            txtNumero.Focus();
        }

        private void btnDescifrar_Click(object sender, RoutedEventArgs e)
        {
            string input = txtNumero.Text.Trim();

            if (!InputValidator.EsNumeroValido(input))
            {
                MostrarError(InputValidator.ObtenerMensajeError(input));
                return;
            }

            string resultado = CifradoService.DescifrarNumero(input);
            MostrarResultado(input, resultado);
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtNumero.Clear();
            resultCard.Visibility = Visibility.Hidden;
            txtNumero.Focus();
        }

        // ── Helpers visuales ──────────────────────────────────────

        private void MostrarResultado(string entrada, string resultado)
        {
            resultCard.Visibility = Visibility.Visible;

            // Acento verde en el borde de la card
            resultCard.BorderBrush = new SolidColorBrush(Color.FromRgb(29, 158, 117));

            lblResultado.Foreground = new SolidColorBrush(Color.FromRgb(15, 110, 86));
            lblResultado.Text = resultado;

            lblSubtitulo.Text = $"Número cifrado ingresado: {entrada}";
        }

        private void MostrarError(string mensaje)
        {
            resultCard.Visibility = Visibility.Visible;

            // Acento rojo en el borde de la card
            resultCard.BorderBrush = new SolidColorBrush(Color.FromRgb(200, 60, 60));

            lblResultado.Foreground = new SolidColorBrush(Color.FromRgb(163, 45, 45));
            lblResultado.Text = "Error";

            lblSubtitulo.Text = mensaje;
        }
    }
}