using Biblioteka;
namespace Baza
{
    struct Kontakty
    {
        public Class1.Osoba [] Osoby;
        public uint LiczbaOsob;

        public static void WprowadzKontakt(ref Kontakty kontakty)
        {
            if(kontakty.LiczbaOsob >= kontakty.Osoby.Length)
            {
                throw new Exception("Baza jest pełna");
            }

            Class1.Osoba.WprowadzOsobe(out kontakty.Osoby[kontakty.LiczbaOsob]);
            kontakty.LiczbaOsob++;
        }

        public static void WypiszKontakty(Kontakty kontakty)
        {
            for(int i = 0; i < kontakty.LiczbaOsob; i++)
            {
                Console.Write("{0}. ", i + 1);
                Class1.Osoba.WypiszOsobe(kontakty.Osoby[i]);
                Console.WriteLine();
                if ((i + 1) % Console.WindowHeight == 0)
                {
                    Console.ReadKey();
                }
            }
            Console.ReadKey();
        }

        public static void UtworzKontakty(out Kontakty kontakty, uint liczbaKontaktow)
        {
            kontakty.Osoby = new Class1.Osoba[liczbaKontaktow];
            kontakty.LiczbaOsob = 0;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Kontakty mojeKontakty;
            Kontakty.UtworzKontakty(out mojeKontakty, 5);
            char c;
            do
            {
                c = Menu();
                switch (c)
                {
                    case 'a':
                    case 'A':
                        Kontakty.WprowadzKontakt(ref mojeKontakty);
                        break;
                    case 'b':
                    case 'B':
                        Kontakty.WypiszKontakty(mojeKontakty);
                        break;
                }
            }
            while (!(c == 'k' || c == 'K'));
        }

        static char Menu()
        {
            Console.Clear();
            Console.WriteLine("\n\t\tA - Dodaj kontakt");
            Console.WriteLine("\n\t\tB - Wypisz wszystkie kontakty");
            return Console.ReadKey().KeyChar;
        }


    }
}
