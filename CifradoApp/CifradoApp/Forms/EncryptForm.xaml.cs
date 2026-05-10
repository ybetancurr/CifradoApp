using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using CifradoApp.Core;
using CifradoApp.Helpers;

namespace CifradoApp.Forms
{
    public partial class EncryptForm : UserControl
    {
        public EncryptForm()
        {
            InitializeComponent();
            txtNumero.Focus();
        }

        private void btnCifrar_Click(object sender, RoutedEventArgs e)
        {
            string input = txtNumero.Text.Trim();

            if (!InputValidator.EsNumeroValido(input))
            {
                MostrarError(InputValidator.ObtenerMensajeError(input));
                return;
            }

            string resultado = CifradoService.CifrarNumero(input);
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

            // Acento púrpura — diferencia visual respecto a DecryptForm
            resultCard.BorderBrush = new SolidColorBrush(Color.FromRgb(124, 92, 191));

            lblResultado.Foreground = new SolidColorBrush(Color.FromRgb(83, 74, 183));
            lblResultado.Text = resultado;

            lblSubtitulo.Text = $"Número original ingresado: {entrada}";
        }

        private void MostrarError(string mensaje)
        {
            resultCard.Visibility = Visibility.Visible;

            // Acento rojo compartido con DecryptForm
            resultCard.BorderBrush = new SolidColorBrush(Color.FromRgb(200, 60, 60));

            lblResultado.Foreground = new SolidColorBrush(Color.FromRgb(163, 45, 45));
            lblResultado.Text = "Error";

            lblSubtitulo.Text = mensaje;
        }
    }
}