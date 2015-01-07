using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KvittoLabb
{
    class Program
    {
        static void Main(string[] args)
        {

            // Deklarera variabler
            double totalsumma = 0;
            int erhallet = 0;
            double avrundatBelopp = 0;
            double vaxel = 0;
            uint total = 0;

            int femhundra = 0;
            int hundra = 0;
            int femtio = 0;
            int tjugo = 0;
            int tia = 0;
            int femma = 0;
            int enkrona = 0;

            // Läs in värden
            while (true)
            {
                try
                {

                    Console.Write("Ange totalsumma: ");
                    totalsumma = double.Parse(Console.ReadLine());

                    if (totalsumma < 1)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\nFEL! Summa måste vara över 1");
                        Console.ResetColor();
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Totalsumma är {0:c}", totalsumma);
                    }

                    Console.Write("Ange erhållet belopp: ");
                    erhallet = int.Parse(Console.ReadLine());

                    if (erhallet < totalsumma)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\nFEL! För lite erhållet");
                        Console.ResetColor();
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Erhållet är {0:c}", totalsumma);
                    }

                    break;

                }
                catch (Exception)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\nFEL! Ange belopp\n");
                    Console.ResetColor();
                }
            }

            //Beräkna

            total = (uint)Math.Round(totalsumma);
            avrundatBelopp = total - totalsumma;

            vaxel = erhallet - total;

            // beräkna växeln
            femhundra = (int)vaxel / 500;
            hundra = ((int)vaxel % 500) / 100;
            femtio = (((int)vaxel % 500) % 100) / 50;
            tjugo = ((((int)vaxel % 500) % 100) % 50) / 20;
            tia = (((((int)vaxel % 500) % 100) % 50) % 20) / 10;
            femma = ((((((int)vaxel % 500) % 100) % 50) % 20) % 10) / 5;
            enkrona = (((((((int)vaxel % 500) % 100) % 50) % 20) % 10) % 5) / 1;


            //presentera kvitto

            Console.WriteLine("\nKVITTO");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("{0,-16} : {1,9:#,##0.00} kr", "Totalt", totalsumma);
            Console.WriteLine("{0,-16} : {1,9:#,##0.00} kr", "Öresavrundning", avrundatBelopp);
            Console.WriteLine("{0,-16} : {1,9:#,##0.00} kr", "Att Betala", total);
            Console.WriteLine("{0,-16} : {1,9:#,##0.00} kr", "Erhållet", erhallet);
            Console.WriteLine("{0,-16} : {1,9:#,##0.00} kr", "Växel", vaxel);
            Console.WriteLine("--------------------------------");

            //Växel presentation.....Vet om att det lär vara repeterad kod men 
            //                       det var så här jag kunde göra det hemma

            if (femhundra >= 1)
            {
                Console.WriteLine("{0,-16} : {1,2} st", " 500-lappar", femhundra);
            }

            if (hundra >= 1)
            {
                Console.WriteLine("{0,-16} : {1,2} st", " 100-lappar", hundra);
            }

            if (femtio >= 1)
            {
                Console.WriteLine("{0,-16} : {1,2} st", "  50-lappar", femtio);
            }

            if (tjugo >= 1)
            {
                Console.WriteLine("{0,-16} : {1,2} st", "  20-lappar", tjugo);
            }

            if (tia >= 1)
            {
                Console.WriteLine("{0,-16} : {1,2} st", "  10-kronor", tia);
            }

            if (femma >= 1)
            {
                Console.WriteLine("{0,-16} : {1,2} st", "   5-kronor", femma);
            }

            if (enkrona >= 1)
            {
                Console.WriteLine("{0,-16} : {1,2} st", "   1-kronor", enkrona);
            }
        }
    }
}
