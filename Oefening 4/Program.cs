using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oefening_4
{
    class Program
    {
        static void Main(string[] args)
        {
            string reiziger, metgezel, reisdoel, boodschapVertrekdatum;
            DateTime vertrekdatum = DateTime.Today.AddMonths(2), datumTerugreis,
            geboortedatumReiziger, geboortedatumMetgezel = DateTime.Today;
            int aantalOvernachtingen = 7;

            PasSchermkleurenAan();

            reiziger = LeesNaam("Geef je naam?");
            metgezel = LeesNaam($"\n(Vul 'alleen' in indien je een solo reis maakt)\nWie is je metgezel, {reiziger.ToUpper()}? ");

            geboortedatumReiziger = LeesGeboortedatum($"{reiziger.ToUpper()}, geef je geboortedatum? ");

            boodschapVertrekdatum = reiziger;

            if (metgezel.ToLower() != "alleen")
            {
                geboortedatumMetgezel = LeesGeboortedatum($"Geef de geboortedatum van \"{metgezel}\": ");
                boodschapVertrekdatum += $" en {metgezel}";
            }

            boodschapVertrekdatum += $", we stellen als vertrekdatum {vertrekdatum.ToLongDateString()} voor." +
                $" Je kan deze datum nog veranderen! ";

            reisdoel = LeesReisdoelIn();

            PasVertrekdatumAan(boodschapVertrekdatum, ref vertrekdatum);
            PasAantalOvernachtingenAan($"\nAantal overnachtingen: {aantalOvernachtingen} dagen ", ref aantalOvernachtingen);

            datumTerugreis = BepaalDatumTerugreis(vertrekdatum, aantalOvernachtingen);

            DrukReisinformatie(reiziger, metgezel, geboortedatumReiziger, geboortedatumMetgezel, reisdoel, vertrekdatum, datumTerugreis);

            DrukOpEnter("Druk op enter om verder te gaan!");
        }

        #region Methodes
        private static void PasSchermkleurenAan()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            Console.Title = "Oefening 4";
        }
        private static void DrukOpEnter(string boodschap)
        {
            Console.WriteLine();
            Console.Write(boodschap);
            Console.ReadLine();
        }
        private static string LeesNaam(string vraag)
        {
            string naam;

            do
            {
                Console.Write($"{vraag} ");
                naam = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(naam) || naam.Length < 2);

            return naam;
        }
        private static DateTime LeesDatum(string vraag)
        {
            string invoer;
            DateTime datum;

            do
            {
                Console.Write($"{vraag} ");
                invoer = Console.ReadLine();
            } while (!DateTime.TryParse(invoer, out datum));

            return datum;
        }
        private static DateTime LeesGeboortedatum(string vraag)
        {
            DateTime geboortedatum;
            int maximumleeftijd = 100;

            do
            {
                geboortedatum = LeesDatum(vraag);
            } while (DateTime.Now.AddYears(-geboortedatum.Year).Year > maximumleeftijd);

            return geboortedatum;
        }
        private static void PasVertrekdatumAan(string vraag, ref DateTime datum)
        {
            string invoer;

            do
            {
                Console.WriteLine("\nIndien de voorgestelde datum ok is, druk op enter! ");
                Console.Write(vraag);
                invoer = Console.ReadLine();

                if (invoer == string.Empty)
                {
                    invoer = datum.ToShortDateString();
                }

            } while (!DateTime.TryParse(invoer, out datum) || datum < DateTime.Today.AddDays(1));

        }
        private static int LeesAantalDagen(string vraag)
        {
            string invoer;
            int aantalDagen;

            do
            {
                Console.Write(vraag);
                invoer = Console.ReadLine();
            } while (!int.TryParse(invoer, out aantalDagen) || aantalDagen < 1);

            return aantalDagen;
        }
        private static void PasAantalOvernachtingenAan(string boodschap, ref int aantalDagen)
        {
            string invoer;

            do
            {
                Console.WriteLine(boodschap);
                Console.Write("Ben je akkoord, druk 'J' of 'N'? ");
                invoer = Console.ReadLine().ToUpper();
            } while (invoer != "J" && invoer != "N");

            if (invoer == "N")
            {
                aantalDagen = LeesAantalDagen("Geef het gewenst aantal overnachtingen (min. 1): ");
            }

        }
        private static string LeesReisdoelIn()
        {
            string invoer;

            do
            {
                Console.Write("Naar waar gaat de reis? ");
                invoer = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(invoer));

            return invoer;
        }

        private static DateTime BepaalDatumTerugreis(DateTime datum, int aantalDagen)
        {
            DateTime datumTerugreis = datum.AddDays(aantalDagen);

            return datumTerugreis;
        }
        private static void DrukReisinformatie(string deelnemer1, string deelnemer2,
            DateTime geboortedatumDeelnemer1, DateTime geboortedatumDeelnemer2,
            string bestemming,
            DateTime vertrekdatum, DateTime datumTerugreis)
        {
            string titel = $"Reisinformatie: {bestemming}";

            Console.Clear();
            Console.WriteLine(titel);
            Console.WriteLine(new string('-', titel.Length));

            Console.WriteLine($"Deelnemer(s): {deelnemer1} geboren op {geboortedatumDeelnemer1.ToLongDateString()}");

            if (deelnemer2.ToLower() != "alleen")
            {
                Console.WriteLine(new string(' ', 14) + $"{deelnemer2} geboren op {geboortedatumDeelnemer2.ToLongDateString()}");
            }

            Console.WriteLine($"\nVertrekdatum: {vertrekdatum.ToLongDateString()}");
            Console.WriteLine($"Terugreisdatum: {datumTerugreis.ToLongDateString()}");

        }

        #endregion
    }
}
