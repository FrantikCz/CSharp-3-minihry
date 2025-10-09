using System;

class Program
{
    static void Main()
    {
        int velikost = 10;
        char[,] mapa = new char[velikost, velikost];
        Random rnd = new Random();

        // naplníme mapu prázdnými poli
        for (int i = 0; i < velikost; i++)
            for (int j = 0; j < velikost; j++)
                mapa[i, j] = '.';

        // start a cíl
        int hracX = 0, hracY = 0;
        int cilX = velikost - 1, cilY = velikost - 1;
        mapa[hracX, hracY] = 'P';
        mapa[cilX, cilY] = 'C';

        // přidáme náhodné překážky
        int pocetPrekazek = velikost * 2;
        for (int k = 0; k < pocetPrekazek; k++)
        {
            int x, y;
            do
            {
                x = rnd.Next(velikost);
                y = rnd.Next(velikost);
            } while ((x == hracX && y == hracY) || (x == cilX && y == cilY));

            mapa[x, y] = '#';
        }

        // hlavní smyčka
        while (true)
        {
            Console.Clear();
            VykresliMapu(mapa);

            if (hracX == cilX && hracY == cilY)
            {
                Console.WriteLine("Gratuluji, našel jsi cíl!");
                break;
            }

            Console.Write("Tvůj tah (WASD): ");
            char tah = Console.ReadKey().KeyChar;
            Console.WriteLine();

            int novyX = hracX, novyY = hracY;

            switch (char.ToLower(tah))
            {
                case 'w': novyX--; break;
                case 's': novyX++; break;
                case 'a': novyY--; break;
                case 'd': novyY++; break;
            }

            if (novyX >= 0 && novyX < velikost &&
                novyY >= 0 && novyY < velikost &&
                mapa[novyX, novyY] != '#')
            {
                mapa[hracX, hracY] = '.';
                hracX = novyX;
                hracY = novyY;
                mapa[hracX, hracY] = 'P';
            }
        }

        Console.WriteLine("Stiskni ENTER pro konec...");
        Console.ReadLine();
    }

    static void VykresliMapu(char[,] mapa)
    {
        int n = mapa.GetLength(0);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
                Console.Write(mapa[i, j] + " ");
            Console.WriteLine();
        }
    }
}
