using System.ComponentModel;

namespace ChatBot.clases
{
    public class Mensaje : INotifyPropertyChanged
    {
        public enum Emisor { Usuario, Robot }

        private Emisor remitente;
        public Emisor Remitente
        {
            get { return this.remitente; }
            set
            {
                if (this.remitente != value)
                {
                    this.remitente = value;
                    this.NotifyPropertyChanged("Remitente");
                }
            }
        }

        private string texto;
        public string Texto
        {
            get { return this.texto; }
            set
            {
                if (this.texto != value)
                {
                    this.texto = value;
                    this.NotifyPropertyChanged("Texto");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Mensaje(Emisor remitente, string texto)
        {
            Remitente = remitente;
            Texto = texto;
        }

        public void NotifyPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
