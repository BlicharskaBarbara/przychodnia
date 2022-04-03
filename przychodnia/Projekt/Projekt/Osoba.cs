using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Projekt
{
    public enum EnumPlec { kobieta, mężczyzna }
    [Serializable]
    abstract public class Osoba : IEquatable<Osoba>
    {
        /// <summary>
        /// Utworzenie pól klasy
        /// </summary>
        string imie;
        string nazwisko;
        EnumPlec plec;
        string telefon;
        string pesel;
        /// <summary>
        /// Utworzenie właściwości dla pól klasy
        /// </summary>
        public string Imie { get => imie; set => imie = value; }
        public string Nazwisko { get => nazwisko; set => nazwisko = value; }
        public EnumPlec Plec { get => plec; set => plec = value; }
        public string Telefon
        {
            get => telefon;
            set
            {
                Regex regex = new Regex(@"^[0-9]{9}$");
                if (!regex.IsMatch(value))
                {
                    throw new BlednyNumerTelefonuException("Podano bledny format numeru telefonu!");
                }
                else
                {
                    telefon = value;
                }
            }
        }
        public string Pesel
        {
            get => pesel;
            set
            {
                Regex r = new Regex(@"^\d{11}");
                if (!r.IsMatch(value))
                {
                    throw new BlednyPeselException("Podano bledny PESEL!");
                }
                pesel = value;
            }
        }

        /// <summary>
        /// Stworzenie konstruktorów nieparametrycznych i parametrycznych
        /// </summary>
        public Osoba() { }
        public Osoba(string imie, string nazwisko, EnumPlec plec, string telefon, string pesel) : this()
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.plec = plec;
            Telefon = telefon; 
            Pesel = pesel; 
        }
        /// <summary>
        /// Metoda umożliwiająca formatowanie tsktu(pierwszy znak jest dużą literą)
        /// </summary>
        /// <param name="text">tekst, który chcemy sformatować</param>
        /// <returns></returns>
        public string Formatuj(string text)
        {
            return text.Substring(0, 1).ToUpper() + text.Substring(1).ToLower();
        }
        /// <summary>
        /// Metoda ToString() umożliwiająca wypisanie danych osoby w konsoli
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Formatuj(Imie)} {Formatuj(Nazwisko)}, Płeć: {Plec}, Nr telefonu: {Telefon}";
        }
        /// <summary>
        /// Metoda porównująca osoby na podstawie peselu
        /// </summary>
        /// <param name="other">Osoba, do której chcemy porównać osobę</param>
        /// <returns>true, jeżeli pesel osoby wskazanej jest taki sam</returns>
        public bool Equals(Osoba other)
        {
            return Pesel.Equals(other.Pesel);
        }
    }
}
