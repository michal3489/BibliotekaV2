using System;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteka
{
    class Ksiazka
    {
        public string Tytul { get; set; }
        public string Autor { get; set; }
        public int RokWydania { get; set; }

        public override string ToString()
        {
            return $"Tytuł: {Tytul}, Autor: {Autor}, Rok wydania: {RokWydania}";
        }
    }

    class Program
    {
        static List<Ksiazka> ksiazki = new List<Ksiazka>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nWybierz akcję:");
                Console.WriteLine("1. Dodaj książkę");
                Console.WriteLine("2. Wyświetl wszystkie książki");
                Console.WriteLine("3. Wyszukaj książkę po tytule");
                Console.WriteLine("4. Zakończ");

                string wybor = Console.ReadLine();

                switch (wybor)
                {
                    case "1":
                        DodajKsiazke();
                        break;
                    case "2":
                        WyswietlKsiazki();
                        break;
                    case "3":
                        WyszukajKsiazke();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Nieprawidłowy wybór.");
                        break;
                }
            }
        }

        static void DodajKsiazke()
        {
            Console.Write("Podaj tytuł książki: ");
            string tytul = Console.ReadLine();
            Console.Write("Podaj autora książki: ");
            string autor = Console.ReadLine();
            Console.Write("Podaj rok wydania książki: ");
            if (int.TryParse(Console.ReadLine(), out int rok))
            {
                ksiazki.Add(new Ksiazka { Tytul = tytul, Autor = autor, RokWydania = rok });
                Console.WriteLine("Książka została dodana.");
            }
            else
            {
                Console.WriteLine("Nieprawidłowy rok wydania.");
            }
        }

        static void WyswietlKsiazki()
        {
            if (ksiazki.Count == 0)
            {
                Console.WriteLine("Brak książek w bibliotece.");
                return;
            }

            foreach (var ksiazka in ksiazki)
            {
                Console.WriteLine(ksiazka);
            }
        }

        static void WyszukajKsiazke()
        {
            Console.Write("Podaj tytuł książki do wyszukania: ");
            string szukanyTytul = Console.ReadLine();

            var znalezioneKsiazki = ksiazki.Where(k => k.Tytul.Contains(szukanyTytul, StringComparison.OrdinalIgnoreCase)).ToList();

            if (znalezioneKsiazki.Count == 0)
            {
                Console.WriteLine("Nie znaleziono książek o podanym tytule.");
            }
            else
            {
                Console.WriteLine("Znalezione książki:");
                foreach (var ksiazka in znalezioneKsiazki)
                {
                    Console.WriteLine(ksiazka);
                }
            }
        }
    }
}