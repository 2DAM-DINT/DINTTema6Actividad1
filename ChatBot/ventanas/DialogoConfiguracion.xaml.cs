using ChatBot.clases;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace ChatBot.ventanas
{
    public partial class DialogoConfiguracion : Window
    {
        public string ColorFondoChat { get; set; }

        public string ColorMensajesUsuario { get; set; }

        public string ColorMensajesBot { get; set; }

        public string GeneroEmisor { get; set; }


        public DialogoConfiguracion()
        {
            InitializeComponent();
            DataContext = this;
            colorFondo.ItemsSource = typeof(Colors).GetProperties();
            colorUsuario.ItemsSource = typeof(Colors).GetProperties();
            colorBot.ItemsSource = typeof(Colors).GetProperties();
            generoUsuario.ItemsSource = Mensaje.GenerosValidos;
        }

        private void Enviar_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBoxResult resultado = MessageBox.Show(
                "¿Seguro que desea cambiar la configuración " +
                "con tu elección actual?\n" +
                $"Color de fondo: {ColorFondoChat}\n" +
                $"Color del usuario: {ColorMensajesUsuario}\n" +
                $"Color del bot: {ColorMensajesBot}\n" +
                $"Genero del usuario: {GeneroEmisor}\n",
                "Confirmación",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);
            if (resultado == MessageBoxResult.Yes)
                DialogResult = true;
        }

        private void Cancelar_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBoxResult resultado = MessageBox.Show(
                "¿Seguro que desea cancelar la configuración?", 
                "Confirmación", 
                MessageBoxButton.YesNo, 
                MessageBoxImage.Question);
            if (resultado == MessageBoxResult.Yes)
                Close();
        }
    }
}
