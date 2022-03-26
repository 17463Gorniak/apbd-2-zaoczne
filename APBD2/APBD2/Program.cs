using APBD2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace APBD2
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var path = args[0];

            //var fi = new FileInfo(path);
            FileInfo fi = new(path);

            var fileContent = new List<string>();

            using (StreamReader stream = new(fi.OpenRead()))
            {
                // Analogicznie co ""
                //string line = string.Empty;

                string line = null;

                while ((line = await stream.ReadLineAsync()) != null)
                {
                    fileContent.Add(line);
                }
                //stream.Dispose();
            }

            foreach (var item in fileContent)
            {
                Console.WriteLine(item);
            }


            //foreach (var item in File.ReadLines(path)){}

            // DateTime - typ dla daty 

            /* Typy danych mają metodę Parse, która ma kilka przeciążeń. Zazwyczaj jest możliwość przekazania stringa jako argument, który powinien
               zostać sparsowany na typ docelowy

               Dla przykładu: DateTime.Parse("2022-03-20") 
            */


            /* Należy przygotować HashSet przechowujący studentów pamiętając, że musimy nadpisać domyślny comparator naszym własnym
               W tym celu podczas inicjalizacji należy utworzyć obiekt naszej klasy comparatora. Dzięki temu porównywanie będzie odbywało się
               tak jak tego oczekujemy
            */
            HashSet<Student> hashSet = new(new OwnComparer());

            // hashSet.Add() -> metoda dodająca elementy do setu. Zwraca true jeżeli udało się dodać element lub false w przecwinym przypadku


            /* Jeżeli chcemy sprawdzić czy string jest poprawny, tj. np. nie jest pusty najlepiej skorzystać z wbudowanej metody
             * 
             * string.IsNullOrWhiteSpace(str)
             * 
             * Sprawdza ona czy podany jako argument element nie jest:
             * a) nullem
             * b) pusty ("")
             * c) składa się tylko z białych znaków (np. spacje, taby)
             * 
             * Jest jeszcze metoda:
             * 
             * string.IsNullOrEmpty(str)
             * 
             * Wtedy sprawdzane są punkty a i b z powyższej listy (bez c).
             */


            /* Zapis do pliku można zrealizować podobnym sposobem jak zaprezentowany odczyt. W tym celu korzystam z obiektu klasy StreamWriter:
             * 
             * StreamWriter stream = new(path)
             * 
             * Do konstruktora trzeba przekazać ścieżkę dla pliku. Jeżeli plik pod daną ścieżką nie istnieje, StreamWriter utworzy go.
             * Jeżeli istnieje to zostanie wyczyszczony i na nowo nastąpi pisanie do niego.
             * 
             * Do zapisu najlepiej wykorzystać metodę stream.WriteLine(line) -> przekazując jako argument linię, która powinna zostać zapisana do pliku
             * 
             * PROSZĘ PAMIĘTAĆ O ZWOLNIENIU ZASOBÓW PRZYDZIELONYCH OBIEKTOWI (najlepiej skorzystać z using)
             */


            /* Żeby zserializować hashSet (bądź ogólnie obiektów C#) na JSON, wystarczy skorzystać z wbudowanej przestrzeni nazw System.Text.Json
             * W tym celu skorzystamy z klasy JsonSerializer i wywołamy metodę Serialize przekazując jako argument kolekcję (bądź obiekt), 
             * który powinien zostać zserializowany do JSONa. W wyniku otrzymamy reprezentację JSONową kolekcji zwróconą w postaci stringa.
             * 
             * Przykład: var json = JsonSerializer.Serialize(set)
             * 
             */

        }
    }
}
