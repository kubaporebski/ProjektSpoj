using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSpoj
{
    public class FreqText
    {
        /// zapisany tekst
        private readonly string text;

        /// <summary>
        /// Słownik, w którym klucze oznaczają znaki, natomiast wartości to częstość występowania danego znaku (ile wystąpień danego znaku w tekście)
        /// </summary>
        public Dictionary<char, int> Frequency
        {
            get;
            private set;
        }

        /// <summary>
        /// Konstruktor.
        /// </summary>
        /// <param name="text">tekst, którego histogram znaków chcemy wyliczyć</param>
        public FreqText(string text)
        {
            this.text = text;
            Compute();
        }

        /// <summary>
        /// Obliczenie częstości występowania znaków w podanym tekście.
        /// </summary>
        private void Compute()
        {
            Frequency = new Dictionary<char, int>();
            foreach (var grp in text.GroupBy(c => c))
            {
                Frequency[grp.Key] = grp.Count();
            };
        }

        /// <summary>
        /// Wyświetlenie wg porządku alfabetycznego znaków.
        /// </summary>
        public string PrintAlphabetically
        {
            get
            {
                return string.Join(Environment.NewLine, Frequency.OrderBy(grp => grp.Key).Select(grp => $"{grp.Key}: {grp.Value}"));
            }
        }

        /// <summary>
        /// Wyświetlenie posortowane po częstotliwości występowania danego znaku malejąco.
        /// </summary>
        public string PrintSorted
        {
            get
            {
                return string.Join(Environment.NewLine, Frequency.OrderByDescending(grp => grp.Value).Select(grp => $"{grp.Key}: {grp.Value}"));
            }
        }

    }
}
