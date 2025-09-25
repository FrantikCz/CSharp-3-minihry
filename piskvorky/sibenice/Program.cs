using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Slova, která se mohou hádat
        string[] slova = { "kokos", "planeta", "banana", "topení", "lama" };
        Random rnd = new Random();
        string tajneSlovo = slova[rnd.Next(slova.Length)];

        // Stav hry
        HashSet<char> hadanaPismena = new HashSet<char>();
        int chyby = 0;
        int maxChyb = 6;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Šibenice ===");
            Console.WriteLine($"Chyby: {chyby}/{maxChyb}");
            Console.Write("Slovo: ");

            // Vykreslení slova s mezerami
            bool celeUhodnute = true;
            foreach (char c in tajneSlovo)
            {
                if (hadanaPismena.Contains(c))
                {
                    Console.Write(c + " ");
                }
                else
                {
                    Console.Write("_ ");
                    celeUhodnute = false;
                }
            }
            Console.WriteLine();

            // Kontrola vítězství
            if (celeUhodnute)
            {
                Console.WriteLine("\nVyhrál jsi, gratuluji!");
                break;
            }

            // Kontrola prohry
            if (chyby >= maxChyb)
            {
                Console.WriteLine($"\nProhrál jsi! Slovo bylo: {tajneSlovo}");
                break;
            }

            // Zadání písmene
            Console.Write("\nZadej písmeno: ");
            string vstup = Console.ReadLine().ToLower();

            if (string.IsNullOrWhiteSpace(vstup) || vstup.Length != 1)
            {
                Console.WriteLine("Zadej jen jedno písmeno.");
                Console.ReadKey();
                continue;
            }

            char pismeno = vstup[0];

            // Pokud už bylo použito
            if (hadanaPismena.Contains(pismeno))
            {
                Console.WriteLine("Toto písmeno už jsi zkoušel.");
                Console.ReadKey();
                continue;
            }

            hadanaPismena.Add(pismeno);

            // Pokud není ve slově → chyba
            if (!tajneSlovo.Contains(pismeno))
            {
                chyby++;
            }
        }

        Console.WriteLine("\nStiskni ENTER pro ukončení...");
        Console.ReadLine();
    }
}
