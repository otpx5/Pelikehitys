using System;

namespace NuoliPeli
{
    // Enum nuolen kärjille
    public enum NuolenKarki
    {
        Puu = 3,
        Teras = 5,
        Timantti = 50
    }

    // Enum nuolen perille
    public enum NuolenPera
    {
        Lehti = 0,
        Kanansulka = 1,
        Kotkansulka = 5
    }

    // Nuoli-luokka
    public class Nuoli
    {
        // Private-luokkamuuttujat
        private NuolenKarki karki;
        private NuolenPera pera;
        private double varrenPituusCm;

        // Konstruktori
        public Nuoli(NuolenKarki karki, NuolenPera pera, double varrenPituusCm)
        {
            this.karki = karki;
            this.pera = pera;
            this.varrenPituusCm = varrenPituusCm;
        }

        // Getter-metodit
        public NuolenKarki GetKarki()
        {
            return karki;
        }

        public NuolenPera GetPera()
        {
            return pera;
        }

        public double GetVarrenPituus()
        {
            return varrenPituusCm;
        }

        // Metodi hinnan laskemiseksi
        public double PalautaHinta()
        {
            double karkiHinta = (double)karki;
            double peraHinta = (double)pera;
            double varsiHinta = varrenPituusCm * 0.05;
            return karkiHinta + peraHinta + varsiHinta;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Valitse nuolen osat seuraavasti:\n");

            // Käyttäjän valinta kärjestä
            Console.WriteLine("Valitse kärki: (1) Puu, (2) Teräs, (3) Timantti");
            int karkiValinta = int.Parse(Console.ReadLine() ?? "1");
            NuolenKarki karki = karkiValinta switch
            {
                1 => NuolenKarki.Puu,
                2 => NuolenKarki.Teras,
                3 => NuolenKarki.Timantti,
                _ => NuolenKarki.Puu
            };

            // Käyttäjän valinta perästä
            Console.WriteLine("Valitse perä: (1) Lehti, (2) Kanansulka, (3) Kotkansulka");
            int peraValinta = int.Parse(Console.ReadLine() ?? "1");
            NuolenPera pera = peraValinta switch
            {
                1 => NuolenPera.Lehti,
                2 => NuolenPera.Kanansulka,
                3 => NuolenPera.Kotkansulka,
                _ => NuolenPera.Lehti
            };

            // Käyttäjän syöttö varren pituudesta
            Console.WriteLine("Syötä varren pituus (60-100 cm):");
            if (!double.TryParse(Console.ReadLine(), out double varrenPituus) || varrenPituus < 60 || varrenPituus > 100)
            {
                Console.WriteLine("Virheellinen pituus. Käytetään oletusarvoa 60 cm.");
                varrenPituus = 60;
            }

            // Luodaan uusi nuoli
            Nuoli nuoli = new Nuoli(karki, pera, varrenPituus);

            // Käytetään gettereitä tietojen näyttämiseen
            Console.WriteLine("\nNuolen tiedot:");
            Console.WriteLine($"Kärki: {nuoli.GetKarki()}");
            Console.WriteLine($"Perä: {nuoli.GetPera()}");
            Console.WriteLine($"Varren pituus: {nuoli.GetVarrenPituus()} cm");

            // Lasketaan ja näytetään hinta
            double hinta = nuoli.PalautaHinta();
            Console.WriteLine($"\nValmistamasi nuolen hinta on {hinta:F2} kultaa.");
        }
    }
}
