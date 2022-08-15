using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oefening_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // declaratie
            string activiteit, invoer, smsAntwoord, persoon;
            bool benJeVrij;
            DateTime datumUurActiviteit;

            // schermkleuren aanpassen
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            Console.Title = "Oefening 1 - " + DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();

            Console.WriteLine("\tOntvangen SMS-bericht\n");

            // --------------------------------
            // PR 1 inlezen kritieke waarde
            // --------------------------------
            do
            {
                Console.Write("\tVoor welke activiteit kreeg je een sms-bericht (stop = geen)? ");
                activiteit = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(activiteit));

            // --------------------------------
            // PR 2 controle kritieke waade
            // --------------------------------
            while (activiteit.ToLower() != "geen")
            {
                // ------------------------
                // PR 3 sms behandelen
                // ------------------------
                do
                {
                    Console.Write("\tGeef datum en uur dat \"{0}\" zal doorgaan? ", activiteit);
                    invoer = Console.ReadLine();
                } while (DateTime.TryParse(invoer, out datumUurActiviteit) == false || datumUurActiviteit < DateTime.Now);

                do
                {
                    Console.Write("\tBen je vrij op {0} ('true' of 'false')? ");
                    invoer = Console.ReadLine();
                } while (!bool.TryParse(invoer, out benJeVrij));

                do
                {
                    Console.Write("\tVan wie was het smsje? ");
                    persoon = Console.ReadLine();
                } while (string.IsNullOrWhiteSpace(persoon));

                smsAntwoord = persoon.ToUpper();

                // bewerking uitvoeren
                if (benJeVrij == true)
                {
                    smsAntwoord += ", ik zal er zijn! ";
                }
                else
                {
                    smsAntwoord += ", spijtig, het zal voor een andere keer zijn!";
                }

                // resultaat tonen
                Console.WriteLine("\n\tOp {0} om {1} - {2}\n", datumUurActiviteit.ToLongDateString(), datumUurActiviteit.ToShortTimeString(), smsAntwoord);

                // --------------------------------
                // PR 4 inlezen kritieke waarde
                // --------------------------------
                do
                {
                    Console.Write("\tVoor welke activiteit kreeg je nog een sms-bericht (stop = geen)? ");
                    activiteit = Console.ReadLine();
                } while (string.IsNullOrWhiteSpace(activiteit));

            }

            // wachten op enter
            Console.WriteLine();
            Console.Write("\tDruk op enter om verder te gaan!");
            Console.ReadLine();
        }
    }
}
