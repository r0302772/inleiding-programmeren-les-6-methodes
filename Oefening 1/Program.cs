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
            string activiteit, smsAntwoord, persoon;
            bool benJeVrij;
            DateTime datumUurActiviteit;

            PasSchermkleurenAan();

            DrukTitel();

            activiteit = LeesActiviteit("\tVoor welke activiteit kreeg je een sms-bericht (stop = geen)? ");

            while (activiteit.ToLower() != "geen")
            {
                datumUurActiviteit = LeesDatumUur(activiteit);

                benJeVrij = LeesBenJeVrij(datumUurActiviteit);

                persoon = LeesPersoon();

                smsAntwoord = BepaalAntwoord(persoon.ToUpper(), benJeVrij);

                Console.WriteLine($"\n\tOp {datumUurActiviteit.ToLongDateString()} om {datumUurActiviteit.ToShortTimeString()} - {smsAntwoord}\n");

                activiteit = LeesActiviteit("\tVoor welke activiteit kreeg je een sms-bericht (stop = geen)? ");

            }

            DrukOpEnter();
        }

        #region Methodes
        private static void PasSchermkleurenAan()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            Console.Title = "Oefening 1 - " + DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
        }
        private static void DrukTitel()
        {
            Console.WriteLine("\tOntvangen SMS-bericht\n");
        }
        private static string LeesActiviteit(string vraag)
        {
            string activiteit;
            do
            {
                Console.Write(vraag);
                activiteit = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(activiteit));

            return activiteit;
        }
        private static DateTime LeesDatumUur(string activiteit)
        {
            string invoer;
            DateTime datumUurActiviteit;

            do
            {
                Console.Write("\tGeef datum en uur dat \"{0}\" zal doorgaan? ", activiteit);
                invoer = Console.ReadLine();
            } while (DateTime.TryParse(invoer, out datumUurActiviteit) == false || datumUurActiviteit < DateTime.Now);

            return datumUurActiviteit;
        }
        private static bool LeesBenJeVrij(DateTime datumUurActiviteit)
        {
            string invoer;
            bool benJeVrij;

            do
            {
                Console.Write($"\tBen je vrij op {datumUurActiviteit} ('true' of 'false')? ");
                invoer = Console.ReadLine();
            } while (!bool.TryParse(invoer, out benJeVrij));

            return benJeVrij;
        }
        private static string LeesPersoon()
        {
            string persoon;

            do
            {
                Console.Write("\tVan wie was het smsje? ");
                persoon = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(persoon));

            return persoon;
        }
        private static string BepaalAntwoord(string naam, bool isVrij)
        {
            if (isVrij == true)
            {
                return naam += ", ik zal er zijn! ";
            }
            else
            {
                return naam += ", spijtig, het zal voor een andere keer zijn!";
            }

        }
        private static void DrukOpEnter()
        {
            Console.WriteLine();
            Console.Write("\tDruk op enter om verder te gaan!");
            Console.ReadLine();
        }

        #endregion
    }
}
