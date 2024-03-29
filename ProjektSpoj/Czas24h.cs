using System;

public class Program
{
    public static void Main2()
    {
        string[] napis = null;
        Czas24h t = null;

        // wczytanie i parsowanie napisu oznaczającego godzinę, np. 2:15:27
        napis = Console.ReadLine().Split(':');
        int[] czas = Array.ConvertAll(napis, int.Parse);
        try
        {
            t = new Czas24h(czas[0], czas[1], czas[2]);
        }
        catch (ArgumentException)
        {
            Console.WriteLine("error");
            return;
        }

        // wczytanie liczby poleceń
        int liczbaPolecen = int.Parse(Console.ReadLine());

        for (int i = 1; i <= liczbaPolecen; i++)
        {
            // wczytanie polecenia
            napis = Console.ReadLine().Split(' ');
            string typPolecenia = napis[0];
            int liczba = int.Parse(napis[1]);

            // wykonanie polecenia na obiekcie t typu Czas24h
            try
            {
                switch (typPolecenia)
                {
                    case "g":
                        t.Godzina = liczba;
                        break;
                    case "m":
                        t.Minuta = liczba;
                        break;
                    case "s":
                        t.Sekunda = liczba;
                        break;
                }
            }
            catch (ArgumentException)
            {
                Console.WriteLine("error");
                return;
            }
        }
        Console.WriteLine(t);
    }
}

public class Czas24h
{
    private int liczbaSekund;

    public int Sekunda
    {
        get => liczbaSekund - Godzina * 60 * 60 - Minuta * 60;
        set => liczbaSekund = (value < 0 || value >= 60) ? throw new ArgumentException() : value + Godzina * 60 * 60 + Minuta * 60;
    }

    public int Minuta
    {
        get => (liczbaSekund / 60) % 60;
        set => liczbaSekund = (value < 0 || value >= 60) ? throw new ArgumentException() : value * 60 + Godzina * 60 * 60 + Sekunda;
    }

    public int Godzina
    {
        get => liczbaSekund / 3600;
        set => liczbaSekund = (value < 0 || value >= 24) ? throw new ArgumentException() : (value * 3600) + Minuta * 60 + Sekunda;
    }

    public Czas24h(int godzina, int minuta, int sekunda)
    {
        // uzupełnij kod zgłaszając wyjątek ArgumentException
        // w sytuacji niepoprawnych danych
        if (sekunda < 0 || sekunda >= 60)
            throw new ArgumentException(nameof(sekunda));

        if (minuta < 0 || minuta >= 60)
            throw new ArgumentException(nameof(minuta));

        if (godzina < 0 || godzina >= 24)
            throw new ArgumentException(nameof(godzina));

        liczbaSekund = sekunda + 60 * minuta + 3600 * godzina;
    }

    public override string ToString() => $"{Godzina}:{Minuta:D2}:{Sekunda:D2}";
}