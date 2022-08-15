using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oefening_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string familienaam, voornaam, suggestie;
            int keuze;

            PasSchermkleurenAan();

            DrukTitel();

            familienaam = LeesNaam("\tGeef je familienaam: ");
            voornaam = LeesNaam("\tGeef je voornaam: ");

            keuze = LeesKeuze($"\n\t{voornaam.ToLower()} {familienaam.ToUpper()}, welke hobby beoefen je? ");

            while (keuze != 8)
            {
                suggestie = BepaalSuggestie(keuze);

                DrukSuggestie(suggestie);

                DrukOpEnter("\tDruk op enter om volgende suggestie!");

                keuze = LeesKeuze($"\n\t{voornaam.ToLower()} {familienaam.ToUpper()}, welke hobby beoefen je nog uit? ");

            }

            DrukOpEnter("\tDruk op enter om verder te gaan!");
        }

        #region Methodes
        private static void PasSchermkleurenAan()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            Console.Title = "Oefening 2";
        }
        private static void DrukTitel()
        {
            string titel = "Opvragen algemene informatie";

            Console.WriteLine("\t{0}", titel);
            Console.WriteLine("\t{0}", new string('*', titel.Length));
        }
        private static string LeesNaam(string vraag)
        {
            string naam;
            do
            {
                Console.Write(vraag);
                naam = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(naam));

            return naam;
        }
        private static int LeesKeuze(string vraag)
        {
            string invoer, overzicht = "\t1. Handwerk (breien, haken, ...)\n" +
                                       "\t2. Kleding maken \n" +
                                       "\t3. Interieur inrichten \n" +
                                       "\t4. Voetballen \n" +
                                       "\t5. Fietsen \n" +
                                       "\t6. Fotografie\n" +
                                       "\t7. Lopen\n" +
                                       "\t8. Geen";
            int keuze;

            do
            {
                Console.Clear();
                Console.WriteLine(overzicht);

                Console.Write(vraag);
                invoer = Console.ReadLine();
            } while (!int.TryParse(invoer, out keuze) || keuze < 1 || keuze > 8);

            return keuze;
        }
        private static string BepaalSuggestie(int keuze)
        {
            string suggestie = "Wij suggereren als tijdschrift \"";

            switch (keuze)
            {
                case 1:
                    suggestie += "Anna";
                    break;
                case 2:
                    suggestie += "Knippie";
                    break;
                case 3:
                    suggestie += "VtWonen";
                    break;
                case 4:
                    suggestie += "Voetbal International";
                    break;
                case 5:
                    suggestie += "Wandelen & Fietsen";
                    break;
                case 6:
                    suggestie += "Zoom NL";
                    break;
                case 7:
                    suggestie += "Runners";
                    break;
            }

            suggestie += "\" aan.";

            return suggestie;
        }
        private static void DrukSuggestie(string suggestie)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n{0}\n{0}\n\t{1}\n{0}\n{0}\n", new string(' ', suggestie.Length + 8), suggestie);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.White;
        }
        private static void DrukOpEnter(string boodschap)
        {
            Console.WriteLine();
            Console.Write(boodschap);
            Console.ReadLine();
        }

        #endregion
    }
}
