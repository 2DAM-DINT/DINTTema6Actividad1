using ChatBot.clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChatBot
{
    public partial class MainWindow : Window
    {
        public List<Mensaje> Mensajes { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Mensajes = new List<Mensaje>();
            listaMensajes.DataContext = Mensajes;
        }

        private void Enviar_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Mensajes.Add(new Mensaje(Mensaje.Emisor.Usuario, textoEscrito.Text));
            Mensajes.Add(new Mensaje(Mensaje.Emisor.Robot, "Lo siento, estoy un poco cansado para hablar."));
            textoEscrito.Text = "";
            listaMensajes.DataContext = Mensajes;
        }

        private void Enviar_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = textoEscrito != null && textoEscrito.Text != "";
        }
    }
}
