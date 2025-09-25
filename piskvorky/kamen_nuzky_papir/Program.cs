using System;

class Program
{
    static void Main(string[] args)
    {
        string[] moznosti = { "kámen", "nůžky", "papír" };
        Random rnd = new Random();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Kámen, nůžky, papír ===");
            Console.WriteLine("1 - kámen");
            Console.WriteLine("2 - nůžky");
            Console.WriteLine("3 - papír");
            Console.WriteLine("0 - konec hry");
            Console.Write("Vyber číslo: ");

            string volba = Console.ReadLine();

            if (volba == "0")
                break;

            int hracIndex;
            if (!int.TryParse(volba, out hracIndex) || hracIndex < 1 || hracIndex > 3)
            {
                Console.WriteLine("Neplatná volba, zkus to znovu...");
                Console.ReadKey();
                continue;
            }

            hracIndex--; 
            string hracTah = moznosti[hracIndex];

            int pocitacIndex = rnd.Next(0, 3);
            string pocitacTah = moznosti[pocitacIndex];

            Console.WriteLine($"\nTy: {hracTah}");
            Console.WriteLine($"Počítač: {pocitacTah}\n");

            if (hracTah == pocitacTah)
            {
                Console.WriteLine("Remíza!");
            }
            else if ((hracTah == "kámen" && pocitacTah == "nůžky") ||
                     (hracTah == "nůžky" && pocitacTah == "papír") ||
                     (hracTah == "papír" && pocitacTah == "kámen"))
            {
                Console.WriteLine("Vyhrál jsi!");
            }
            else
            {
                Console.WriteLine("Prohrál jsi!");
            }

            Console.WriteLine("\nStiskni libovolnou klávesu pro další hru...");
            Console.ReadKey();
        }

        Console.WriteLine("Hra ukončena.");
    }
}
