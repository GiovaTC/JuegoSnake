using System.Windows;

namespace SolitarioWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            IniciarJuego();
        }

        private void IniciarJuego()
        {
            // Lógica para inicializar el juego y distribuir las cartas
        }

        private void DeckButton_Click(object sender, RoutedEventArgs e)
        {
            // Lógica para manejar el clic en el mazo (Deck)
        }

        private void WasteButton_Click(object sender, RoutedEventArgs e)
        {
            // Lógica para manejar el clic en la pila de descarte (Waste)
        }

        // Aquí puedes añadir más métodos para manejar la lógica del juego
    }
}
