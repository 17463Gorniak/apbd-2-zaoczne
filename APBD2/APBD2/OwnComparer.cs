using APBD2.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace APBD2
{
    // Własny comparator, którego celem będzie porównywanie studentów przed wstawieniem ich do setu
    public class OwnComparer : IEqualityComparer<Student>
    {
        public bool Equals(Student x, Student y)
        {
            // Najlepiej będzie porównywać obiekty budując stringa z properties klasy student (imie,nazwisko,index)
            // W momencie gdy nastąpi porównanie 2 stringów i będą one równe będzie oznaczało, że mamy do czynienia z duplikatem
            // W tym celu wykorzystany zostanie StringComparer
            // InvarianCulture -> https://docs.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo.invariantculture?view=net-6.0

            return StringComparer
                .InvariantCultureIgnoreCase
                .Equals($"{x.Name} {x.Surname} {x.Index}", $"{y.Name} {y.Surname} {y.Index}");
        }

        public int GetHashCode([DisallowNull] Student obj)
        {
            // Metoda Equals korzysta z metody GetHashCode. Jej celem jest zamiana porównywanych obiektów
            // (w tym przypadku zbudowanych przez nas stringów) na liczby. Komputerowi łatwiej będzie porównać liczby niż teksty
            // W metodzie Equals budujemy z czego powinien być wyliczony HashCode
            return StringComparer
                .InvariantCultureIgnoreCase
                .GetHashCode($"{obj.Name} {obj.Surname} {obj.Index}");
        }
    }
}
