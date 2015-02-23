using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kylskåp
{
    class Program
    {
        private const string HorizontalLine = "======================================";

        static void Main(string[] args)
        {
            // TEST 1
            ViewTestHeader("Test 1.\nTest av standardkonstruktorn");
            Cooler test1 = new Cooler();
            Console.WriteLine();
            Console.WriteLine(test1.ToString());

            // TEST 2
            ViewTestHeader("Test 2.\nTest av konstruktorn med två parametrar, <24,5 och 4>");
            Cooler test2 = new Cooler(24.5m, 4m);
            Console.WriteLine();
            Console.WriteLine(test2.ToString());
            
            // TEST 3
            ViewTestHeader("Test 3.\nTest av konstruktorn med 4 parametrar, <19.5, 4, true och false>");
            Cooler test3 = new Cooler(19.5m, 4m, true, false);
            Console.WriteLine();
            Console.WriteLine(test3.ToString());
            
            // TEST 4
            ViewTestHeader("Test 4.\nTest av kylning med metoden Tick");
            Cooler test4 = new Cooler(5.3m, 4m, true, false);
            Console.WriteLine();
            Console.WriteLine(test4.ToString());
            Run(test4, 10);

            // TEST 5
            ViewTestHeader("Test 5.\nTest av avstängt kylskåp med metoden Tick, vara avslaget och ha stängd dörr");
            Cooler test5 = new Cooler(5.3m, 4m, false, false);
            Console.WriteLine();
            Console.WriteLine(test5.ToString());
            Run(test5, 10);
            
            // TEST 6
            ViewTestHeader("Test 6.\nTest av påslaget kylskåp med metoden Tick, vara på och ha öppen dörr");
            Cooler test6 = new Cooler(10.2m, 4m, true, true);
            Console.WriteLine();
            Console.WriteLine(test6.ToString());
            Run(test6, 10);

            // TEST 7
            ViewTestHeader("Test 7.\nTest av avslaget kylskåp med metoden Tick, ha öppen dörr");
            Cooler test7 = new Cooler(19.7m, 4m, false, true);
            Console.WriteLine();
            Console.WriteLine(test7.ToString());
            Run(test7, 10);

            // TEST 8
            try
            {
                ViewTestHeader("Test 8.\nTest av egenskaperna så att undantag kastas då innertemperaturen och \nmåltemperaturen tilldelas felaktiga värden.");
                Cooler test8 = new Cooler();
                test8.InsideTemperature = 80.0m;
                Run(test8, 10);
            }
            catch (Exception)
            {

                ViewErrorMessage("\nInnertemperaturen är inte i intervallen 0 - 45°C");
            }

            try //Test av felaktig måltemperatur 
            {
                Cooler test8 = new Cooler();
                test8.TargetTemperature = -25.0m;
                Run(test8, 10);
            }
            catch (Exception)
            {
                ViewErrorMessage("Måltemperaturen är inte i intervallen 0 - 45°C");
            }

            // TEST 9
            try
            {
                ViewTestHeader("Test 9.\nTest av kontruktorerna så att undantag kastas då innertemperaturen och \nmåltemperaturen tilldelas felaktiga värden.");
                Cooler test9 = new Cooler(76.5m, 10m, true, true);
                Run(test9, 10);
            }
            catch (Exception)
            {                
                ViewErrorMessage("\nInnertemperaturen är inte i intervallen 0 - 45°C");
            }

            try
            {
                Cooler test9 = new Cooler(6.0m, -10m, true, true);
                Run(test9, 10);
            }
            catch (Exception)
            {
                ViewErrorMessage("Måltemperaturen är inte i intervallen 0 - 45°C");
            }

        }
        static void Run(Cooler cooler, int minute)
        {
            for (int ticks = 0; ticks < minute; ticks++)
            {
                cooler.Tick();
                Console.WriteLine(cooler.ToString());
            }
        }

        static void ViewErrorMessage(string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        static void ViewTestHeader(string header)
        {
            Console.WriteLine(HorizontalLine);
            Console.WriteLine(header);
        }
    }
}
