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
            // declaratie
            string symbool1, symbool2, sjaal, streepSymbool1, streepSymbool2, ploegnaam, invoer;
            string titel = "Supporterssjaal";
            int lengteSjaal, breedteSjaal, minimumLengte = 4, lengtePloegnaam = 5;

            // schermkleuren aanpassen
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            Console.Title = "Oefening 3";

            // PR 1
            do
            {
                Console.Write("Van welke ploeg wens je de sjaal af te drukken (\"{0}\" = stop)? ", new string('*', lengtePloegnaam));
                ploegnaam = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(ploegnaam) || ploegnaam.Length < lengtePloegnaam);

            // PR 2
            while (ploegnaam != new string('*', lengtePloegnaam))
            {

                //titel drukken
                Console.WriteLine("\n{0} {1}", titel, ploegnaam);
                Console.WriteLine(new string('*', titel.Length + ploegnaam.Length + 1));

                // inlezen
                do
                {
                    Console.Write("Geef symbool 1: ");
                    symbool1 = Console.ReadLine();
                } while (string.IsNullOrWhiteSpace(symbool1) || symbool1.Length != 1);

                do
                {
                    Console.Write("Geef symbool 2: ");
                    symbool2 = Console.ReadLine();
                } while (string.IsNullOrWhiteSpace(symbool2) || symbool2.Length != 1 || symbool2 == symbool1);

                do
                {
                    Console.Write("Hoe lang moet de sjaal worden (min. {0})? ", minimumLengte);
                    invoer = Console.ReadLine();
                } while (!int.TryParse(invoer, out lengteSjaal) || lengteSjaal < minimumLengte);

                do
                {
                    Console.Write("Hoe breed moet de sjaal worden (min. {0}? ", lengteSjaal / 2);
                    invoer = Console.ReadLine();
                } while (!int.TryParse(invoer, out breedteSjaal) || breedteSjaal < lengteSjaal / 2);


                // sjaalstrepen opbouwen
                streepSymbool1 = new string(Convert.ToChar(symbool1), breedteSjaal);
                streepSymbool2 = new string(Convert.ToChar(symbool2), breedteSjaal);

                // sjaal opbouwen
                sjaal = "\n";

                for (int i = 1; i <= lengteSjaal; i++)
                {
                    if (i % 2 == 0)
                    {
                        sjaal += streepSymbool2;
                    }
                    else
                    {
                        sjaal += streepSymbool1;
                    }

                    sjaal += "\n";
                }

                // resultaat tonen
                Console.WriteLine(sjaal);

                // PR 4
                do
                {
                    Console.Write("Van welke ploeg wens je de sjaal af te drukken (\"{0}\" = stop)? ", new string('*', lengtePloegnaam));
                    ploegnaam = Console.ReadLine();
                } while (string.IsNullOrWhiteSpace(ploegnaam) || ploegnaam.Length < lengtePloegnaam);

            }

            // wachten op enter
            Console.WriteLine();
            Console.Write("Druk op enter om verder te gaan!");
            Console.ReadLine();
        }
    }
}
