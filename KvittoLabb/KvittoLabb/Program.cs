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
            int vaxelover = 0;

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
                        return;
                    }
                            
                    Console.WriteLine("Totalsumma är {0:c}", totalsumma);

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
                   
                        Console.WriteLine("Erhållet är {0:c}", erhallet);
                    

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
            vaxelover = (int)vaxel % 500;
            hundra = vaxelover / 100;
            vaxelover = vaxelover % 100;
            femtio = vaxelover / 50;
            vaxelover = vaxelover % 50;
            tjugo = vaxelover / 20;
            vaxelover = vaxelover % 20;
            tia = vaxelover / 10;
            vaxelover = vaxelover % 10;
            femma = vaxelover / 5;
            vaxelover = vaxelover % 5;
            enkrona = vaxelover / 1;


            //presentera kvitto

            Console.WriteLine("\nKVITTO");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("{0,-16} : {1,11:c2}", "Totalt", totalsumma);
            Console.WriteLine("{0,-16} : {1,11:c2}", "Öresavrundning", avrundatBelopp);
            Console.WriteLine("{0,-16} : {1,11:c2}", "Att Betala", total);
            Console.WriteLine("{0,-16} : {1,11:c2}", "Erhållet", erhallet);
            Console.WriteLine("{0,-16} : {1,11:c2}", "Växel", vaxel);
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
