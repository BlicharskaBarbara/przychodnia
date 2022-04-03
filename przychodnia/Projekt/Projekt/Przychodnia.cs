using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Projekt
{
    [Serializable]
    [XmlInclude(typeof(Lekarz))]
    [XmlInclude(typeof(Pacjent))]
    public class Przychodnia
    {
        /// <summary>
        /// utowrzenie list zawierających wszystkich lekarzy w przychodni oraz wszystkich pacjentów
        /// </summary>
        private List<Lekarz> lekarze;
        private List<Pacjent> pacjenci;
        /// <summary>
        /// utowrzenie właściwości do pól
        /// </summary>
        public List<Pacjent> Pacjenci { get => pacjenci; set => pacjenci = value; }
        public List<Lekarz> Lekarze { get => lekarze; set => lekarze = value; }
        /// <summary>
        /// konstruktor nieparametryczny, w którym inicjalizujemy nasze listy
        /// </summary>
        public Przychodnia()
        {
            Lekarze = new List<Lekarz>();
            Pacjenci = new List<Pacjent>();   

        }
        /// <summary>
        /// metoda dodająca pacjenta do listy pacjentów
        /// </summary>
        /// <param name="pacjent">pacjent,który ma być dodany do listy pacjentów</param>
        public void DodajPacjenta(Pacjent pacjent)
        {
            Pacjenci.Add(pacjent);
        }
        /// <summary>
        /// metoda dodająca lekarza do listy lekarzy
        /// </summary>
        /// <param name="lekarz">lekarz, który ma być dodany do listy lekarzy</param>

        public void DodajLekarza(Lekarz lekarz)
        {
            Lekarze.Add(lekarz);
        }
        /// <summary>
        /// Metoda sprawdzająca czy osoba o danym peselu jest pacjentem zarejestrowanym w naszej przychodni
        /// </summary>
        /// <param name="PESEL">pesel, na podstawie którego sprawdzamy czy dana osoba jest pacjentem naszej przychodni</param>
        /// <returns>true, jeżeli osoba o danym numerze pesel jest pacjentem w naszej przychodni</returns>
        public bool JestPacjentem(string PESEL)
        {
            foreach (Pacjent pacjent in pacjenci)
            {
                if (pacjent.Pesel == PESEL)
                    return true;
            }

            return false;
        }
        /// <summary>
        /// Metoda sprawdzająca czy dana osoba jest pacjentem w naszej przychodni
        /// </summary>
        /// <param name="pacjent">Pacjent, którego obecność sprawdzamy w naszej przychodni</param>
        /// <returns>true, jeżeli wskazany pacjent jest na liście pacjentów naszej przychodni</returns>
        public bool JestPacjentem(Pacjent pacjent)
        {
            foreach (Pacjent p in pacjenci)
            {
                if (p.Equals(pacjent))
                    return true;
            }

            return false;
        }
        /// <summary>
        /// Metoda usuwająca pacjenta o danym numerze pesel z listy pacjentow
        /// </summary>
        /// <param name="PESEL">Pesel, na podstawie którego wyszukujemy osobę do usunięcia</param>
        public void UsunPacjenta(string PESEL)
        {
            foreach (Pacjent p in pacjenci)
            {
                if (p.Pesel == PESEL)
                {
                    Pacjenci.Remove(p);
                    break; //zakonczenie petli, bo po co szukac dalej jak juz usuniemy
                }
            }
        }
        /// <summary>
        /// Metoda wyszukująca pacjenta po numerze pesel
        /// </summary>
        /// <param name="pesel">Pesel pacjenta służący do identyfikacji osoby, którą chcemy wyszukać</param>
        /// <returns>Pacjenta o podanym numerze pesel</returns>

        public Pacjent WyszukajPacjenta(string pesel)
        {
            return Pacjenci.FirstOrDefault(p => p.Pesel == pesel);
        }
        /// <summary>
        /// Metoda sortująca pacjentów 
        /// </summary>
        public void Sortuj()
        {
            Pacjenci.Sort(); //wykorzystuje sortowanie z CompareTo z Osoby
        }
        /// <summary>
        /// Metoda wyświetlająca wizyty danego pacjenta
        /// </summary>
        /// <param name="p">Pacjent, którego wizyty chcemy wyświetlić</param>
        /// <returns>Listę wizyt wskazanego pacjenta</returns>

        public List<Wizyta> WyswietlWizyty(Pacjent p)
        {
            List<Wizyta> wizytyPacjenta = new List<Wizyta>();
            foreach (Lekarz l in lekarze)
            {
                foreach (Wizyta w in l.Terminarz)
                {
                    if (w.Pacjent == p)
                    {
                        wizytyPacjenta.Add(w);
                    }
                }
            }
            return wizytyPacjenta;
        }

        /// <summary>
        /// Metoda umożliwiająca rezygnacje z wizyty
        /// </summary>
        /// <param name="w">wizyta, z której użytkownik chce zrezygnować</param>
        public void ZrezygnujzWizyty(Wizyta w)
        {
            foreach (Lekarz l in lekarze)
            {
                foreach (Wizyta wiz in l.Terminarz)
                {
                    if (wiz.Pacjent == w.Pacjent && wiz.Data == w.Data)
                    {
                        l.Terminarz.Remove(wiz);
                        break;
                    }
                }
            }
            foreach (Lekarz l in lekarze)
            {
                foreach (Wizyta wiz in l.Terminarz)
                {
                    if (wiz.Pacjent == w.Pacjent && wiz.Data == w.Data)
                    {
                        l.WolneTerminy.Add(wiz.Data);
                    }
                }
            }

        }


        /// <summary>
        /// metoda ToString() wypisująca do konsoli lekarzy zawartych w liscie lekarzy i pacjentów z listy pacjentów
        /// </summary>
        /// <returns></returns>
        /// 

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(); //tworze obiekt
            sb.AppendLine("Przychodnia: "); //dodaje info Przychodnia //apend dodaje kilka info string
            
            
            foreach (Lekarz lekarz in Lekarze)
            {
                sb.AppendLine("Lekarz: " + lekarz.ToString());
            }
            
            foreach (Pacjent pacjent in pacjenci) //dla kazdego pacjenta dodaje opis pacjenta
            {
                sb.AppendLine("Pacjent: " + pacjent.ToString());
            }
            return sb.ToString();
        }
        
       

        /// <summary>
        /// Metoda serializująca przychodnię do XML
        /// </summary>
        /// <param name="nazwaPliku">nazwa pliku, do którego chcemy zapisać dane z serializacji</param>
        public void ZapiszXML(string nazwaPliku) //nazwa to ten zespol.xml co mamy w programie
        {
            var stream = new FileStream(nazwaPliku, FileMode.Create);
            var xmlSerializer = new XmlSerializer(this.GetType());
            xmlSerializer.Serialize(stream, this);
            stream.Close();
        }
        /// <summary>
        /// Metoda odczytująca przychodnię z pliku XML
        /// </summary>
        /// <param name="nazwaPliku">nazwa pliku, który chcemy odczytać</param>
        /// <returns>obiekt klasy Przychodnia odczytany z pliku</returns>
        public static Przychodnia OdczytXML(string nazwaPliku)
        {
            var stream = new FileStream(nazwaPliku, FileMode.Open);
            var xmlSerializer = new XmlSerializer(typeof(Przychodnia));
            var przychodnia = xmlSerializer.Deserialize(stream) as Przychodnia;
            stream.Close();
            return przychodnia;
        }
    }
}
