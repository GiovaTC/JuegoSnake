using System;

namespace SentenciaIfElseIf
{
    class Program
    {
     
        static void Main(string[] args)
        {

            bool areYouHungry = true;
            bool youHaveMoney = false;
            TimeSpan time2 = new TimeSpan(12, 0, 0);

            Console.WriteLine("Hola fundillo");
            if (areYouHungry && youHaveMoney && AbiertoOcerradoFund("Lonches alejo", time2))
            {
                Console.WriteLine("abierto");
            }
            else
            {
                Console.WriteLine("cerrado"+ "Hora de: "+ time2 + "");
            }
        }

        static bool AbiertoOcerradoFund(string name, TimeSpan time)
        {
            TimeSpan time3 = new TimeSpan(08, 0, 0);
            TimeSpan time4 = new TimeSpan(24, 0, 0);

            if (name == "Lonches alejo" && time == (time3) && time < time4 )
            {
                Console.WriteLine("se fue de taxi");
                return true;
            }
            else if (name == "Fundillo") 
            {
                return false;
            }
            else
            {
                Console.WriteLine("No habia caldo de pata");
                return true;
            }
        }
    }
}