using System;

namespace SentenciaIfElseIf
{
    class Program
    {
     
        static void Main(string[] args)
        {

            bool fundillo_mea = true;
            TimeSpan time2 = new TimeSpan(08, 0, 0);

            Console.WriteLine("Hola tienda deportiva: ");
            if (fundillo_mea && AbiertoOcerradoFund("ropa y accesorios", time2))
            {
                Console.WriteLine("hora de apertura: "+ time2);
            }
            else
            {
                Console.WriteLine("cerrado"+ "Hora de ciere: "+ time2 + "");
            }
        }

        static bool AbiertoOcerradoFund(string name, TimeSpan time)
        {
            TimeSpan time3 = new TimeSpan(08, 0, 0);
            TimeSpan time4 = new TimeSpan(24, 0, 0);

            if (name == "ropa y accesorios" && time == (time3) && time < time4 )
            {
                Console.WriteLine("local abierto, en el centro Comercial !, ");
                return true;
            }
            else if (name == "No es ropa y accesorios") 
            {
                return false;
            }
            else
            {
                Console.WriteLine("Promocion no completada");
                return true;
            }
        }
    }
}