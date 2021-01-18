using ChatBot.clases;
using ChatBot.ventanas;
using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace ChatBot
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Mensaje> Mensajes { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Mensajes = new ObservableCollection<Mensaje>();
            listaMensajes.DataContext = Mensajes;
        }

        private void Enviar_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Mensajes.Add(
                new Mensaje(
                    (Mensaje.Emisor) Enum.Parse(
                        typeof(Mensaje.Emisor), 
                        Properties.Settings.Default.generoUsuario), textoEscrito.Text));
            Mensajes.Add(new Mensaje(Mensaje.Emisor.Robot, "Lo siento, estoy un poco cansado para hablar."));
            textoEscrito.Text = "";
        }

        private void Enviar_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = textoEscrito != null && textoEscrito.Text != "";
        }

        private void Limpiar_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Mensajes.Clear();
        }

        private void GestionarConversacion_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = listaMensajes != null && listaMensajes.Items.Count > 0;
        }

        private void Guardar_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "TXT File (*.txt) |*.txt";
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, String.Join("\n", Mensajes), Encoding.UTF8);
        }

        private void Salir_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }

        private void Configurar_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DialogoConfiguracion configuracion = new DialogoConfiguracion();
            configuracion.Owner = this;
            configuracion.ColorFondoChat = Properties.Settings.Default.colorFondo;
            configuracion.ColorMensajesUsuario = Properties.Settings.Default.colorUsuario;
            configuracion.ColorMensajesBot = Properties.Settings.Default.colorBot;
            configuracion.GeneroEmisor = (Mensaje.Emisor) Enum.Parse(
                typeof(Mensaje.Emisor), Properties.Settings.Default.generoUsuario);

            if (configuracion.ShowDialog() == true)
            {
                Properties.Settings.Default.colorFondo = configuracion.ColorFondoChat;
                Properties.Settings.Default.colorUsuario = configuracion.ColorMensajesUsuario;
                Properties.Settings.Default.colorBot = configuracion.ColorMensajesBot;
                Properties.Settings.Default.generoUsuario = configuracion.GeneroEmisor.ToString();
            }

        }

        private void Comprobar_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Conexión correcta con el servidor del Bot", "Comprobar conexión", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
