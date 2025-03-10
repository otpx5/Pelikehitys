using System;
using System.Collections.Generic;

class Tavara
{
    public double Paino { get; }
    public double Tilavuus { get; }

    public Tavara(double paino, double tilavuus)
    {
        Paino = paino;
        Tilavuus = tilavuus;
    }

    public override string ToString() => GetType().Name;
}

class Nuoli : Tavara { public Nuoli() : base(0.1, 0.05) { } }
class Jousi : Tavara { public Jousi() : base(1, 4) { } }
class Köysi : Tavara { public Köysi() : base(1, 1.5) { } }
class Vesi : Tavara { public Vesi() : base(2, 2) { } }
class Ruoka : Tavara { public Ruoka() : base(1, 0.5) { } }
class Miekka : Tavara { public Miekka() : base(5, 3) { } }

class Reppu
{
    private List<Tavara> tavarat = new List<Tavara>();
    private int maxTavaroidenMäärä;
    private double maxPaino;
    private double maxTilavuus;

    public Reppu(int maxTavaroidenMäärä, double maxPaino, double maxTilavuus)
    {
        this.maxTavaroidenMäärä = maxTavaroidenMäärä;
        this.maxPaino = maxPaino;
        this.maxTilavuus = maxTilavuus;
    }

    public bool Lisää(Tavara tavara)
    {
        if (tavarat.Count >= maxTavaroidenMäärä ||
            KokonaisPaino + tavara.Paino > maxPaino ||
            KokonaisTilavuus + tavara.Tilavuus > maxTilavuus)
        {
            return false;
        }

        tavarat.Add(tavara);
        return true;
    }

    public int TavaroidenMäärä => tavarat.Count;
    public double KokonaisPaino => LaskePaino();
    public double KokonaisTilavuus => LaskeTilavuus();

    private double LaskePaino()
    {
        double summa = 0;
        foreach (var tavara in tavarat)
            summa += tavara.Paino;
        return summa;
    }

    private double LaskeTilavuus()
    {
        double summa = 0;
        foreach (var tavara in tavarat)
            summa += tavara.Tilavuus;
        return summa;
    }

    public override string ToString()
    {
        return tavarat.Count == 0 ? "Reppu on tyhjä." : $"Reppussa on seuraavat tavarat: {string.Join(", ", tavarat)}";
    }
}

class Program
{
    static void Main()
    {
        Reppu reppu = new Reppu(10, 30, 20);
        Dictionary<int, Tavara> valikko = new Dictionary<int, Tavara>
        {
            {1, new Nuoli()},
            {2, new Jousi()},
            {3, new Köysi()},
            {4, new Vesi()},
            {5, new Ruoka()},
            {6, new Miekka()}
        };

        while (true)
        {
            Console.WriteLine(reppu.ToString());
            Console.WriteLine($"Reppu: {reppu.TavaroidenMäärä}/10 tavaraa, {reppu.KokonaisPaino}/30 painoa, {reppu.KokonaisTilavuus}/20 tilavuus.");
            Console.WriteLine("Mitä haluat lisätä?");
            Console.WriteLine("1 - Nuoli\n2 - Jousi\n3 - Köysi\n4 - Vettä\n5 - Ruokaa\n6 - Miekka");

            if (int.TryParse(Console.ReadLine(), out int valinta) && valikko.ContainsKey(valinta))
            {
                if (reppu.Lisää(valikko[valinta]))
                {
                    Console.WriteLine("Tavara lisätty!");
                }
                else
                {
                    Console.WriteLine("Repun kapasiteetti ei riitä!");
                }
            }
            else
            {
                Console.WriteLine("Virheellinen valinta.");
            }
        }
    }
}

