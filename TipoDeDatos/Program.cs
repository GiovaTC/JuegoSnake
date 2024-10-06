using System;

namespace Funciones
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 1;
            int b = 2;

     //       Show();
     //        Sum(6,8);

            int num3 = Mul(4, 6);
            Console.WriteLine("El resultado de la multiplicacion es: " + num3);
        }


        static int Mul(int num1, int num2)
        {
            return num1 * num2;

        }


        static void Sum(int num1, int num2)
        {
            int num3 = num1 + num2;
            Console.WriteLine("El resultado de la suma es: "+ num3);
        }

        static void Show()
        {
            Console.WriteLine("Hola, eres un texto que se imprime desde una funcion");
        }
    }
}
