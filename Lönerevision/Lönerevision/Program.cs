using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lönerevision
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)        // Anropar mina metoder och avgör om beräkningen kan gå vidare
            {
                try
                {
                    int count = ReadInt("Ange minst 2 löner för att starta beräkning: ");

                    if (count < 2)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    else
                    {
                        ProcessSalaries(count);
                    }


                }
                catch (ArgumentOutOfRangeException)
                {

                    Console.WriteLine();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Du måste mata in minst 2 löner för att starta en beräkning");
                    Console.ResetColor();

                }

                Console.WriteLine();        //Lägger in så att det är Esc-knappen som avslutar min beräkning annars så startar en ny beräkning
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Tryck tangent för en ny beräkning - ESC avslutar.");
                Console.ResetColor();

                if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                {
                    return;
                }
            }

        }

        static int ReadInt(string prompt) // Läs in antal löner som ska beräknas
        {

            while (true)
            {

                Console.Write(prompt);
                string input = Console.ReadLine();

                try
                {

                    int antalLoner = int.Parse(input);
                    return antalLoner;

                }
                catch (FormatException)
                {

                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("FEL! '{0}' kan inte tolkas som ett heltal!", input);
                    Console.WriteLine();
                    Console.ResetColor();  
                  
                }
            }

        }

        static void ProcessSalaries(int count)
        {

            //deklarera array variabel

            int[] antal = new int[count];

            // Mata in antal löner i array
            Console.WriteLine("");
            for (int i = 0; i < antal.Length; i++)
            {

                antal[i] = ReadInt(string.Format("Ange lön nummer {0}: ", i + 1));
            
            }
            Console.WriteLine("\n------------------------------");

            //Skapar kopian för att kunna arbeta med löner som ska ska användas sorterade
            int[] antalClone = (int[])antal.Clone();

            //sortarar min klonade array
            Array.Sort(antalClone);

            //Beräkna medianen
            if (count % 2 == 0)
            {
                int medianLon1 = antalClone[antalClone.Length / 2 - 1];         //Denna beräkningen är ifall medianen måste räknas ut mellan två löner
                int medianLon2 = antalClone[antalClone.Length / 2];
                Console.WriteLine("MedianLön: {0,17:C0}", (medianLon1 + medianLon2) / 2);

            }
            else
            {
                int median = antalClone[antalClone.Length / 2];                 //De beräkningen är för en ensam lön som blir median
                Console.WriteLine("Medianlön: {0,17:C0}", median);
            }
            Console.WriteLine("Medellön: {0,18:C0}", antalClone.Average());
            Console.WriteLine("Lönespridning: {0,13:C0}", antalClone.Max() - antalClone.Min());
            Console.WriteLine("-------------------------------");

            for (int i = 0; i < count; i++)         //Skriver ut de osorterade inskrivna lönerna och listar dom tre st per rad
            {
                if (i % 3 == 0)
                {

                    Console.WriteLine("");

                }

                Console.Write("{0,9}", antal[i]);
            }

        }


    }
 
}
