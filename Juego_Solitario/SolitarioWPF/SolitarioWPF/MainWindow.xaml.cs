using System;
using System.Diagnostics.Metrics;
using System.IO;
using System.Net.NetworkInformation;
using System.Windows;
using System.Windows.Media.Imaging;

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
            string folderPath = @"D:\playingcardsassetsmaster\png"; // Reemplaza con la ruta de tu carpeta de imágenes
            string[] imageFiles = ObtenerRutasDeImagenes(folderPath);

            if (imageFiles.Length > 0)
            {
                // Asigna las imágenes a las pilas (esto es solo un ejemplo para la primera imagen)
                DeckImage.Source = new BitmapImage(new Uri(imageFiles[0])); // Imagen para el mazo
                WasteImage.Source = new BitmapImage(new Uri(imageFiles[1])); // Imagen para la pila de descarte
                Foundation1.Source = new BitmapImage(new Uri(imageFiles[2])); // Imagen para fundación 1
                                                                              // Continúa asignando las imágenes según sea necesario para el resto de las pilas y áreas de fundación
            }
        }


        private string[] ObtenerRutasDeImagenes(string folderPath)
        {
            // Obtén todas las imágenes .png en la carpeta especificada
            try
            {
                return Directory.GetFiles(folderPath, "*.png", SearchOption.AllDirectories);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener las imágenes: {ex.Message}");
                return Array.Empty<string>();
            }
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
