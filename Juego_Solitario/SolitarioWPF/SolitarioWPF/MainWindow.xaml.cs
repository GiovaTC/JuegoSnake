using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace SolitarioWPF
{
    public partial class MainWindow : Window
    {
        private int jugadasRealizadas = 0;

        public MainWindow()
        {
            InitializeComponent();
            IniciarJuego();
        }

        private void IniciarJuego()
        {
            string folderPath = @"D:\playingcardsassetsmaster\png"; // Reemplaza con la ruta de tu carpeta de imágenes.
            string[] imageFiles = ObtenerRutasDeImagenes(folderPath);

            if (imageFiles.Length > 0)
            {
                // Asignar cartas a las imágenes del mazo, pila de descarte, fundaciones y tableau
                DeckImage.Source = new BitmapImage(new Uri(imageFiles[0]));
                WasteImage.Source = new BitmapImage(new Uri(imageFiles[1]));
                Foundation1.Source = new BitmapImage(new Uri(imageFiles[2]));
                Foundation2.Source = new BitmapImage(new Uri(imageFiles[3]));
                Foundation3.Source = new BitmapImage(new Uri(imageFiles[4]));
                Foundation4.Source = new BitmapImage(new Uri(imageFiles[5]));
                Tableau1.Source = new BitmapImage(new Uri(imageFiles[6]));
                Tableau2.Source = new BitmapImage(new Uri(imageFiles[7]));
                Tableau3.Source = new BitmapImage(new Uri(imageFiles[8]));
                Tableau4.Source = new BitmapImage(new Uri(imageFiles[9]));
                Tableau5.Source = new BitmapImage(new Uri(imageFiles[10]));
                Tableau6.Source = new BitmapImage(new Uri(imageFiles[11]));
                Tableau7.Source = new BitmapImage(new Uri(imageFiles[12]));
            }
        }

        private string[] ObtenerRutasDeImagenes(string folderPath)
        {
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
            MoverCarta(DeckImage, WasteImage);
        }

        private void WasteButton_Click(object sender, RoutedEventArgs e)
        {
            // Aquí podrías implementar la lógica de mover una carta de la pila de descarte a una fundación
            MoverCarta(WasteImage, Foundation1); // Mueve la carta al lugar correspondiente (cambia según tu lógica)
        }

        private void TableauButton_Click(object sender, RoutedEventArgs e)
        {
            // Aquí implementas la lógica para mover cartas entre el tableau y las fundaciones o entre las columnas
            MoverCarta(Tableau1, Foundation2); // Modifica según tu lógica
        }

        private void MoverCarta(UIElement from, UIElement to)
        {
            Point fromPosition = from.TransformToAncestor(this).Transform(new Point(0, 0));
            Point toPosition = to.TransformToAncestor(this).Transform(new Point(0, 0));

            var animation = new DoubleAnimation
            {
                From = fromPosition.Y,
                To = toPosition.Y,
                Duration = TimeSpan.FromSeconds(1),
                AutoReverse = false,
                EasingFunction = new QuadraticEase() { EasingMode = EasingMode.EaseInOut }
            };

            TranslateTransform transform = new TranslateTransform();
            from.RenderTransform = transform;

            transform.BeginAnimation(TranslateTransform.YProperty, animation);

            animation.Completed += (s, e) =>
            {
                from.Visibility = Visibility.Collapsed; // Ocultar la carta de origen después de moverla
                to.Visibility = Visibility.Visible; // Mostrar la carta de destino si está oculta
            };
        }
    }
}
