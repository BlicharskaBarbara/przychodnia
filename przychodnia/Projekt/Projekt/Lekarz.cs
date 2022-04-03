using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    
    public enum EnumSpecjalizacja { pediatra, ortopeda, neurolog, okulista, chirurg }
    [Serializable]
    public class Lekarz : Osoba
    {
        /// <summary>
        /// tworzenie pól zawierających listy 
        /// </summary>
        List<EnumSpecjalizacja> specjalizacje;
        List<Wizyta> terminarz; 
        List<DateTime> wolneTerminy;
        /// <summary>
        /// tworzenie właściwości dla utworzonych pól
        /// </summary>
        public List<EnumSpecjalizacja> Specjalizacje { get => specjalizacje; set => specjalizacje = value; }
        public List<Wizyta> Terminarz { get => terminarz;  }
        public List<DateTime> WolneTerminy { get => wolneTerminy; set => wolneTerminy = value; }
        /// <summary>
        /// tworzenie konstruktorów nieparametrycznych i parametrycznych
        /// </summary>
        public Lekarz() : base()
        {
            specjalizacje = new List<EnumSpecjalizacja>();
            terminarz = new List<Wizyta>();
            wolneTerminy = new List<DateTime>();
        }
        public Lekarz(string imie, string nazwisko, EnumPlec plec, string telefon, string pesel) : base(imie, nazwisko, plec, telefon, pesel)
        {
            specjalizacje = new List<EnumSpecjalizacja>();
            terminarz = new List<Wizyta>();
        }
        /// <summary>
        /// Metoda umożliwiająca dodanie specjalizacji do listy specjalizacji danego lekarza
        /// </summary>
        /// <param name="s">specjalizacja, którą chcemy dodać dla lekarza</param>
        public void DodajSpecjalizacje(EnumSpecjalizacja s)
        {
            if (Specjalizacje.Contains(s))
                throw new Exception("Ten lekarz juz ma ta specjalizacje");
            specjalizacje.Add(s);
        }
        /// <summary>
        /// Metoda umożliwiająca dodanie wizyty do terminarza lekarza
        /// </summary>
        /// <param name="termin">termin wizyty, którą chcemy dodać</param>
        /// <param name="pacjent">pacjent, którego wizytę chcemy dodać</param>

        public void DodajWizyte(DateTime termin, Pacjent pacjent)
        {
            Terminarz.Add(new Wizyta(termin, pacjent));
            foreach (DateTime d in wolneTerminy)
            {
                if (d == termin)
                {
                    wolneTerminy.Remove(d);
                    break;
                }
            }
        }
        /// <summary>
        /// Metoda umożliwiająca dodanie wolnych terminów dla lekarza
        /// </summary>
        /// <returns>Listę wolnych terminów lekarza</returns>
        public List<DateTime> PodajWolneTerminy() 
        {
            DateTime dzis = DateTime.Now;
            

            for (int i = 0; i < 7; i++)
            {
                DateTime danyDzien = new DateTime(dzis.Year, dzis.Month, dzis.Day, 8, 0, 0).AddDays(i);
                DateTime data = new DateTime(dzis.Year, dzis.Month, dzis.Day, 8, 0, 0).AddDays(i);
                for (; data < danyDzien.AddHours(8); data = data.AddMinutes(30)) 
                {
                    var wizyta = Terminarz.FirstOrDefault(w => w.Data == data); 

                    if (wizyta == null)
                        wolneTerminy.Add(data);
                }
            }
            return wolneTerminy;
        }
        /// <summary>
        /// Metoda ToString() umożliwiająca wypisanie danych lekarza do konsoli
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Imie} {Nazwisko}, Plec: {Plec}, \nSpecjalizacje: ");
            foreach (EnumSpecjalizacja s in Specjalizacje)
            {
                sb.Append(s.ToString() + " ");
            }
            sb.Append("\n");
            sb.AppendLine($"numer telefonu: {Telefon.Substring(0,3)}-{Telefon.Substring(3,3)}-{Telefon.Substring(6,3)}");
            return sb.ToString();

        }
    }
}
