using System;

// Oven tilat
enum OviTila { Lukossa, Kiinni, Auki }

class Program
{
    static void Main()
    {
        OviTila ovi = OviTila.Lukossa;
        string komento;

        while (true)
        {
            // Tulostetaan oven tila
            Console.Write("Ovi on ");
            switch (ovi)
            {
                case OviTila.Lukossa: Console.Write("Lukossa."); break;
                case OviTila.Kiinni: Console.Write("Kiinni."); break;
                case OviTila.Auki: Console.Write("Auki."); break;
            }
            Console.Write(" Mitä haluat tehdä? ");
            komento = Console.ReadLine();

            // Käsitellään komennot
            if (komento == "poista lukitus" && ovi == OviTila.Lukossa)
            {
                ovi = OviTila.Kiinni;
            }
            else if (komento == "avaa" && ovi == OviTila.Kiinni)
            {
                ovi = OviTila.Auki;
            }
            else if (komento == "sulje" && ovi == OviTila.Auki)
            {
                ovi = OviTila.Kiinni;
            }
            else if (komento == "lukitse" && ovi == OviTila.Kiinni)
            {
                ovi = OviTila.Lukossa;
            }
            else
            {
                Console.WriteLine("Virheellinen komento!");
            }
        }
    }
}
