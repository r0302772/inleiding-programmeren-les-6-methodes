using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oefening_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string symbool1, symbool2, streepSymbool1, streepSymbool2, ploegnaam;
            int lengteSjaal, breedteSjaal, minimumLengte = 4, lengtePloegnaam = 5;

            PasSchermkleurenAan();

            ploegnaam = LeesNaam($"Van welke ploeg wens je de sjaal af te drukken (\"{new string('*', lengtePloegnaam)}\" = stop)? ", lengtePloegnaam);

            while (ploegnaam != new string('*', lengtePloegnaam))
            {
                DrukTitel(ploegnaam);

                symbool1 = LeesSymbool("Geef symbool 1: ", "");

                symbool2 = LeesSymbool("Geef symbool 2: ", symbool1);

                lengteSjaal = LeesGetal("Hoe lang", minimumLengte);

                breedteSjaal = LeesGetal("Hoe breed", lengteSjaal / 2);

                streepSymbool1 = BepaalStreep(symbool1, breedteSjaal);
                streepSymbool2 = BepaalStreep(symbool2, breedteSjaal);

                DrukSjaal(streepSymbool1, streepSymbool2, lengteSjaal);

                ploegnaam = LeesNaam($"Van welke ploeg wens je de sjaal af te drukken (\"{new string('*', lengtePloegnaam)}\" = stop)? ", lengtePloegnaam);
            }

            DrukOpEnter();
        }

        #region Methodes
        private static void PasSchermkleurenAan()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            Console.Title = "Oefening 3";
        }
        private static string LeesNaam(string vraag, int lengte)
        {
            string ploegnaam;

            do
            {
                Console.Write(vraag);
                ploegnaam = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(ploegnaam) || ploegnaam.Length < lengte);

            return ploegnaam;
        }
        private static void DrukOpEnter()
        {
            Console.WriteLine();
            Console.Write("Druk op enter om verder te gaan!");
            Console.ReadLine();
        }
        private static void DrukTitel(string naam)
        {
            string titel = "Supporterssjaal";

            Console.WriteLine($"\n{titel} {naam}");
            Console.WriteLine(new string('*', titel.Length + naam.Length + 1));
        }
        private static string LeesSymbool(string vraag, string vergelijkendSymbool)
        {
            string invoer;

            do
            {
                Console.Write(vraag);
                invoer = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(invoer) || invoer == vergelijkendSymbool);

            return invoer;
        }
        private static int LeesGetal(string vraagOnderdeel, int minimumwaarde)
        {
            string invoer;
            int waarde;

            do
            {
                Console.Write($"{vraagOnderdeel} moet de sjaal worden (min. {minimumwaarde})? ");
                invoer = Console.ReadLine();
            } while (!int.TryParse(invoer, out waarde) || waarde < minimumwaarde);

            return waarde;
        }
        private static string BepaalStreep(string symbool, int breedte)
        {
            return new string(Convert.ToChar(symbool), breedte);
        }
        private static void DrukSjaal(string streep1, string streep2, int lengte)
        {
           string sjaal = "\n";

            for (int i = 1; i <= lengte; i++)
            {
                if (i % 2 == 0)
                {
                    sjaal += streep2;
                }
                else
                {
                    sjaal += streep1;
                }

                sjaal += "\n";
            }
            
            Console.WriteLine($"{sjaal}");
        }

        #endregion
    }
}
