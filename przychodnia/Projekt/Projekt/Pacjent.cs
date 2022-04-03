using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Projekt
{
    [Serializable]
    public class Pacjent : Osoba, IComparable<Pacjent>
    {
        /// <summary>
        /// pole daty urodzenia
        /// </summary>
        /// 
        DateTime dataUrodzenia;

        /// <summary>
        /// właściwość dla pola dataUrodzenia
        /// </summary>
        public DateTime DataUrodzenia { get => dataUrodzenia; set => dataUrodzenia = value; }
        /// <summary>
        /// konstruktory nieparametryczne i parametryczne
        /// </summary>
        public Pacjent() : base() { }
        public Pacjent(string imie, string nazwisko, EnumPlec plec, string telefon, string pesel, DateTime dataUrodzenia) : base(imie, nazwisko, plec, telefon, pesel)
        {
            this.dataUrodzenia = dataUrodzenia;
        }
        /// <summary>
        /// Metoda umożliwiająca obliczenie wieku pacjenta
        /// </summary>
        /// <returns>wiek pacjenta</returns>
        public int WiekPacjenta()
        {
            int wiek;
            DateTime today = DateTime.Today; //pobranie dzisiejszej daty
            int rok1 = today.Year;
            int rok2 = DataUrodzenia.Year;
            wiek = rok1 - rok2;
            return wiek;
        }
        /// <summary>
        /// Metoda ToString() wypisująca dane pacjenta na konsolę
        /// </summary>
        /// <returns>string zawierający dane pacjenta</returns>
        public override string ToString()
        {
            return base.ToString() + $"Pesel: {Pesel}, Data Urodzenia: {dataUrodzenia.ToShortDateString()}, Wiek pacjenta: {WiekPacjenta()} lat";
        }
        /// <summary>
        /// Metoda porównująca pacjentów
        /// </summary>
        /// <param name="other">Pacjent z którym porówujemy</param>
        /// <returns></returns>

        public int CompareTo(Pacjent other)
        {
            if (Nazwisko.Equals(other.Nazwisko))
                return Imie.CompareTo(other.Imie);

            return Nazwisko.CompareTo(other.Nazwisko);
        }
    }
}
