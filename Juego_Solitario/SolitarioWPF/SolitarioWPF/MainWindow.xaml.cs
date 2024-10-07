using System;
using System.IO;
using System.Windows;
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
                DeckImage.Source = new BitmapImage(new Uri(imageFiles[0])); // Imagen para el mazo
                WasteImage.Source = new BitmapImage(new Uri(imageFiles[1])); // Imagen para la pila de descarte
                // Asignar cartas a las fundaciones
                Foundation1.Source = new BitmapImage(new Uri(imageFiles[2])); // Imagen para fundación 1
                Foundation2.Source = new BitmapImage(new Uri(imageFiles[3])); // Imagen para fundación 2
                Foundation3.Source = new BitmapImage(new Uri(imageFiles[4])); // Imagen para fundación 3
                Foundation4.Source = new BitmapImage(new Uri(imageFiles[5])); // Imagen para fundación 4

                // Asignar cartas a las pilas del tableau
                Tableau1.Source = new BitmapImage(new Uri(imageFiles[6])); // Imagen para tableau 1
                Tableau2.Source = new BitmapImage(new Uri(imageFiles[7])); // Imagen para tableau 2
                Tableau3.Source = new BitmapImage(new Uri(imageFiles[8])); // Imagen para tableau 3
                Tableau4.Source = new BitmapImage(new Uri(imageFiles[9])); // Imagen para tableau 4
                Tableau5.Source = new BitmapImage(new Uri(imageFiles[10])); // Imagen para tableau 5
                Tableau6.Source = new BitmapImage(new Uri(imageFiles[11])); // Imagen para tableau 6
                Tableau7.Source = new BitmapImage(new Uri(imageFiles[12])); // Imagen para tableau 7
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
            if (jugadasRealizadas < 3)
            {
                MoverCarta(DeckImage, WasteImage);
                jugadasRealizadas++;
            }
            else
            {
                MessageBox.Show("Se han realizado 3 jugadas. Reinicia el juego para continuar.");
            }
        }

        private void WasteButton_Click(object sender, RoutedEventArgs e)
        {
            if (jugadasRealizadas < 3)
            {
                MoverCarta(WasteImage, Foundation1);
                jugadasRealizadas++;
            }
            else
            {
                MessageBox.Show("Se han realizado 3 jugadas. Reinicia el juego para continuar.");
            }
        }

        private void TableauButton_Click(object sender, RoutedEventArgs e)
        {
            // Lógica para mover cartas entre el tableau y otras pilas (ejemplo: desde el tableau a la fundación)
            if (jugadasRealizadas < 3)
            {
                // Supongamos que movemos una carta del tableau a la fundación
                MoverCarta(Tableau1, Foundation2); // Puedes modificar esto según tu lógica
                jugadasRealizadas++;
            }
            else
            {
                MessageBox.Show("Se han realizado 3 jugadas. Reinicia el juego para continuar.");
            }
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
