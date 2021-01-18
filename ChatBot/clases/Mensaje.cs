using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace ChatBot.clases
{
    public class Mensaje : INotifyPropertyChanged
    {
        public enum Emisor { Hombre, Mujer, Otro, Robot }

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

        public static string[] GenerosValidos
        {
            get
            {
                string[] generosValidos;

                List<string> listaGeneros = Enum.GetNames(typeof(Mensaje.Emisor)).ToList();
                listaGeneros.Remove(Mensaje.Emisor.Robot.ToString());
                generosValidos = listaGeneros.ToArray();

                return generosValidos;
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

        public override string ToString()
        {
            return $"{Remitente}\n" +
                   $"{Texto}";
        }
    }
}
