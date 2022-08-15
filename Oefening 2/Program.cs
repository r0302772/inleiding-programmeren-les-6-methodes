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
            // declaratie
            string familienaam, voornaam, invoer, suggestie;
            string titel = "Opvragen algemene informatie";
            int keuze;
            string overzicht =
                "\t1. Handwerk (breien, haken, ...)\n" +
                "\t2. Kleding maken \n" +
                "\t3. Interieur inrichten \n" +
                "\t4. Voetballen \n" +
                "\t5. Fietsen \n" +
                "\t6. Fotografie\n" +
                "\t7. Lopen\n" +
                "\t8. Geen";

            // schermkleuren aanpassen
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            Console.Title = "Oefening 2";

            // inlezen

            Console.WriteLine("\t{0}", titel);
            Console.WriteLine("\t{0}", new string('*', titel.Length));

            do
            {
                Console.Write("\tGeef je familienaam: ");
                familienaam = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(familienaam));

            do
            {
                Console.Write("\tGeef je voornaam: ");
                voornaam = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(voornaam));

            // -----
            // PR 1
            // -----
            do
            {
                Console.Clear();
                Console.WriteLine(overzicht);

                Console.Write("\n\t{0} {1}, welke hobby beoefen je? ", voornaam.ToLower(), familienaam.ToUpper());
                invoer = Console.ReadLine();
            } while (!int.TryParse(invoer, out keuze) || keuze < 1 || keuze > 8);

            // ------
            // PR 2
            // ------

            while (keuze != 8)
            {
                // ------
                // PR 3
                // ------

                // bewerking uitvoeren

                suggestie = "Wij suggereren als tijdschrift \"";

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

                // resultaat tonen

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n{0}\n{0}\n\t{1}\n{0}\n{0}\n", new string(' ', suggestie.Length + 8), suggestie);
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.BackgroundColor = ConsoleColor.White;

                // wachten op enter
                Console.WriteLine();
                Console.Write("\tDruk op enter om volgende suggestie!");
                Console.ReadLine();

                // -----
                // PR 4
                // -----
                do
                {
                    Console.Clear();
                    Console.WriteLine(overzicht);

                    Console.Write("\n\t{0} {1}, welke hobby beoefen je nog uit? ", voornaam.ToLower(), familienaam.ToUpper());
                    invoer = Console.ReadLine();
                } while (!int.TryParse(invoer, out keuze) || keuze < 1 || keuze > 8);
            }

            // wachten op enter
            Console.WriteLine();
            Console.Write("\tDruk op enter om verder te gaan!");
            Console.ReadLine();
        }
    }
}
