using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RitaMedAsterisker
{
    class Program
    {
        static void Main(string[] args)
        {

            
            for (int row = 0; row <= 24; row++) // Starten för den loop som skriver ut *
            {
                switch (row % 3) // Färgkodar raderna
                {
                    case 0:                       
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;

                    case 1:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        break;

                    case 2:
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    
                }

                if (row % 2 == 0) // Lägger till ett mellanslag varje rad som klassas "True"
                {
                    Console.Write(" "); 
                }

                for (int col = 0; col <= 38; col++) // Skriver ut de * som krävs genom att loopa
                {

                    Console.Write("* "); 

                }
                Console.WriteLine();

            }
            Console.ResetColor(); // återställer färglagd consol till default


        }
    }
}
