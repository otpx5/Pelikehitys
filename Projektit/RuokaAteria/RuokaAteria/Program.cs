using System;
using System.Collections.Generic;

// Määritellään enumeraattorit pääraaka-aineelle, lisukkeelle ja kastikkeelle
enum PaaraakaAine { Nautaa, Kanaa, Kasviksia }
enum Lisuke { Perunaa, Riisia, Pastaa }
enum Kastike { Pippuri, Chili, Tomaatti, Curry }

// Luokka aterialle
class Ateria
{
    public PaaraakaAine Paaraaka { get; set; }
    public Lisuke Lisuke { get; set; }
    public Kastike Kastike { get; set; }

    public override string ToString()
    {
        return $"{Paaraaka} ja {Lisuke} {Kastike}-kastikkeella";
    }
}

class Program
{
    static void Main()
    {
        List<Ateria> ateriat = new List<Ateria>();

        for (int i = 0; i < 1; i++) // Käyttäjä voi tehdä yhden aterian
        {
            Console.WriteLine("Valitse ateria:");
            Ateria ateria = new Ateria();

            Console.Write("Pääraaka-aine (nautaa, kanaa, kasviksia): ");
            ateria.Paaraaka = (PaaraakaAine)Enum.Parse(typeof(PaaraakaAine), Console.ReadLine(), true);

            Console.Write("Lisukkeet (perunaa, riisia, pastaa): ");
            ateria.Lisuke = (Lisuke)Enum.Parse(typeof(Lisuke), Console.ReadLine(), true);

            Console.Write("Kastike (pippuri, chili, tomaatti, curry): ");
            ateria.Kastike = (Kastike)Enum.Parse(typeof(Kastike), Console.ReadLine(), true);

            ateriat.Add(ateria);
        }

        Console.WriteLine("\nValitsemasi annos:");
        foreach (var ateria in ateriat)
        {
            Console.WriteLine(ateria);
        }
    }
}