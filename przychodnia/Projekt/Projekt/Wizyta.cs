using Projekt;
using System;

namespace Projekt
{
    [Serializable]
    public class Wizyta //klasa ktora spina do kupy rzeczy
    { 
        /// <summary>
        /// utworzenie właściwości dla pól klasy Wizyta
        /// </summary>
        public DateTime Data { get; set; }
        public Pacjent Pacjent { get; set; }
        /// <summary>
        /// utowrzenie konstruktorów: parametrycznego i nieparametrycznego
        /// </summary>
        public Wizyta() { }

        public Wizyta(DateTime data, Pacjent pacjent)
        {
            Data = data;
            Pacjent = pacjent;
        }
        /// <summary>
        /// metoda ToString() utowrzona dla klasy  Wizyta
        /// </summary>
        /// <returns>data wizyty oraz pacjenta, do którego należy wizyta</returns>
        public override string ToString()
        {
            return $"data: {Data}, pacjent: {Pacjent}";
        }
    }
}