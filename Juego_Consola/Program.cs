using System;
using System.Collections.Generic;
using System.Threading;

class SnakeGame
{
    static int ancho = 40; // Ancho del tablero.
    static int alto = 20;  // Alto del tablero
    static List<(int, int)> snake = new List<(int, int)>(); // Lista de posiciones de la serpiente
    static (int, int) direccion = (0, 1); // Dirección inicial (movimiento hacia la derecha)
    static (int, int) comida; // Posición de la comida
    static Random random = new Random();

    static void Main()
    {
        // Configurar el tamaño de la consola para adaptarse al tablero
        Console.SetWindowSize(ancho + 2, alto + 2); // Ajusta el tamaño de la ventana de la consola
        Console.SetBufferSize(ancho + 2, alto + 2); // Ajusta el tamaño del búfer de la consola

        // Inicializar la serpiente
        snake.Add((alto / 2, ancho / 2));

        // Generar la primera comida
        GenerarComida();

        // Configurar el bucle de juego
        while (true)
        {
            DibujarTablero();
            InputUsuario();
            MoverSerpiente();

            // Controlar la velocidad del juego
            Thread.Sleep(500); // Reducir el valor para aumentar la velocidad
        }
    }

    static void DibujarTablero()
    {
        Console.Clear();
        for (int i = 0; i < alto; i++)
        {
            for (int j = 0; j < ancho; j++)
            {
                if (i == 0 || i == alto - 1 || j == 0 || j == ancho - 1)
                {
                    Console.Write("#"); // Bordes del tablero
                }
                else if (snake.Contains((i, j)))
                {
                    Console.Write("O"); // Cuerpo de la serpiente
                }
                else if ((i, j) == comida)
                {
                    Console.Write("X"); // Comida
                }
                else
                {
                    Console.Write(" "); // Espacios vacíos
                }
            }
            Console.WriteLine();
        }
    }

    static void InputUsuario()
    {
        if (Console.KeyAvailable)
        {
            var tecla = Console.ReadKey(true).Key;
            switch (tecla)
            {
                case ConsoleKey.UpArrow:
                    direccion = (-1, 0);
                    break;
                case ConsoleKey.DownArrow:
                    direccion = (1, 0);
                    break;
                case ConsoleKey.LeftArrow:
                    direccion = (0, -1);
                    break;
                case ConsoleKey.RightArrow:
                    direccion = (0, 1);
                    break;
            }
        }
    }

    static void MoverSerpiente()
    {
        var cabeza = snake[0];
        var nuevaCabeza = (cabeza.Item1 + direccion.Item1, cabeza.Item2 + direccion.Item2);

        // Verificar colisiones con el borde del tablero o con el propio cuerpo
        if (nuevaCabeza.Item1 <= 0 || nuevaCabeza.Item1 >= alto - 1 || nuevaCabeza.Item2 <= 0 || nuevaCabeza.Item2 >= ancho - 1 || snake.Contains(nuevaCabeza))
        {
            Console.Clear();
            Console.WriteLine("¡Game Over!");
            Environment.Exit(0);
        }

        // Mover la serpiente
        snake.Insert(0, nuevaCabeza);

        // Verificar si la serpiente come la comida
        if (nuevaCabeza == comida)
        {
            GenerarComida();
        }
        else
        {
            snake.RemoveAt(snake.Count - 1); // Eliminar la última parte de la serpiente si no come
        }
    }

    static void GenerarComida()
    {
        int x, y;
        do
        {
            x = random.Next(1, alto - 1);
            y = random.Next(1, ancho - 1);
        } while (snake.Contains((x, y)));

        comida = (x, y);
    }
}
