using System.Windows.Input;

namespace ChatBot.clases
{
    public static class ComandosChatBot
    {
        public static readonly RoutedUICommand Enviar = new RoutedUICommand
        (
            "Enviar",
            "Enviar",
            typeof(ComandosChatBot),
            new InputGestureCollection
            {
                new KeyGesture(Key.Enter)
            }
        );

        public static readonly RoutedUICommand Limpiar = new RoutedUICommand
        (
            "Limpiar",
            "Limpiar",
            typeof(ComandosChatBot),
            new InputGestureCollection
            {
                new KeyGesture(Key.N, ModifierKeys.Control)
            }
        );

        public static readonly RoutedUICommand Guardar = new RoutedUICommand
        (
            "Guardar",
            "Guardar",
            typeof(ComandosChatBot),
            new InputGestureCollection
            {
                new KeyGesture(Key.G, ModifierKeys.Control)
            }
        );

        public static readonly RoutedUICommand Salir = new RoutedUICommand
        (
            "Salir",
            "Salir",
            typeof(ComandosChatBot),
            new InputGestureCollection
            {
                new KeyGesture(Key.S, ModifierKeys.Control)
            }
        );

        public static readonly RoutedUICommand Configurar = new RoutedUICommand
        (
            "Configurar",
            "Configurar",
            typeof(ComandosChatBot),
            new InputGestureCollection
            {
                new KeyGesture(Key.C, ModifierKeys.Control)
            }
        );

        public static readonly RoutedUICommand Comprobar = new RoutedUICommand
        (
            "Comprobar",
            "Comprobar",
            typeof(ComandosChatBot),
            new InputGestureCollection
            {
                new KeyGesture(Key.O, ModifierKeys.Control)
            }
        );

        public static readonly RoutedUICommand Cancelar = new RoutedUICommand
        (
            "Cancelar",
            "Cancelar",
            typeof(ComandosChatBot),
            new InputGestureCollection
            {
                new KeyGesture(Key.Escape)
            }
        );
    }
}
