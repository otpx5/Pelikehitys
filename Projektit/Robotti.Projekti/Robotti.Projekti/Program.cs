using System;

public class Robotti
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool OnKäynnissä { get; set; }
    public RobottiKäsky?[] Käskyt { get; } = new RobottiKäsky?[3];

    public void Suorita()
    {
        foreach (RobottiKäsky? käsky in Käskyt)
        {
            käsky?.Suorita(this);
            Console.WriteLine($"[{X} {Y} {OnKäynnissä}]");
        }
    }
}

public abstract class RobottiKäsky
{
    public abstract void Suorita(Robotti robotti);
}

class Käynnistä : RobottiKäsky
{
    public override void Suorita(Robotti robotti)
    {
        robotti.OnKäynnissä = true;
    }
}

class Sammuta : RobottiKäsky
{
    public override void Suorita(Robotti robotti)
    {
        robotti.OnKäynnissä = false;
    }
}

class YlösKäsky : RobottiKäsky
{
    public override void Suorita(Robotti robotti)
    {
        if (robotti.OnKäynnissä)
            robotti.Y++;
    }
}

class AlasKäsky : RobottiKäsky
{
    public override void Suorita(Robotti robotti)
    {
        if (robotti.OnKäynnissä)
            robotti.Y--;
    }
}

class VasenKäsky : RobottiKäsky
{
    public override void Suorita(Robotti robotti)
    {
        if (robotti.OnKäynnissä)
            robotti.X--;
    }
}

class OikeaKäsky : RobottiKäsky
{
    public override void Suorita(Robotti robotti)
    {
        if (robotti.OnKäynnissä)
            robotti.X++;
    }
}

class Program
{
    static void Main()
    {
        Robotti robotti = new Robotti();
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("Mitä komentoja syötetään robotille? Vaihtoehdot: Käynnistä, Sammuta, Ylös, Alas, Oikea, Vasen.");
            string syöte = Console.ReadLine();
            switch (syöte.ToLower())
            {
                case "käynnistä":
                    robotti.Käskyt[i] = new Käynnistä();
                    break;
                case "sammuta":
                    robotti.Käskyt[i] = new Sammuta();
                    break;
                case "ylös":
                    robotti.Käskyt[i] = new YlösKäsky();
                    break;
                case "alas":
                    robotti.Käskyt[i] = new AlasKäsky();
                    break;
                case "vasen":
                    robotti.Käskyt[i] = new VasenKäsky();
                    break;
                case "oikea":
                    robotti.Käskyt[i] = new OikeaKäsky();
                    break;
                default:
                    Console.WriteLine("Virheellinen komento.");
                    i--;
                    break;
            }
        }
        robotti.Suorita();
    }
}
