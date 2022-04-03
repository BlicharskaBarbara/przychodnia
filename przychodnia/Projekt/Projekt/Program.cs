using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    class Program
    {
        static void Main(string[] args)
        {
            //try
            //{
            //    Pacjent pa1 = new Pacjent("kasia", "nowak", EnumPlec.kobieta, "15ad635122", "814367263712367", new System.DateTime(2001, 12, 22));
            //    Console.WriteLine(pa1);
            //}
            //catch (BlednyNumerTelefonuException e)
            //{
            //    Console.WriteLine(e.Message);
            //}

            Przychodnia przychodnia = new Przychodnia();

            Lekarz l1 = new Lekarz("Kamil", "Ślimak", EnumPlec.mężczyzna, "123232123", "84226589145");
            l1.DodajSpecjalizacje(EnumSpecjalizacja.chirurg);
            l1.DodajSpecjalizacje(EnumSpecjalizacja.neurolog);

            Lekarz l2 = new Lekarz("Aneta", "Nowak", EnumPlec.kobieta, "495726548", "85664157892");
            l2.DodajSpecjalizacje(EnumSpecjalizacja.okulista);
            l2.DodajSpecjalizacje(EnumSpecjalizacja.pediatra);

            Lekarz l3 = new Lekarz("Katarzyna", "Kot", EnumPlec.kobieta, "431543123", "89012318723");
            l3.DodajSpecjalizacje(EnumSpecjalizacja.ortopeda);
            l3.DodajSpecjalizacje(EnumSpecjalizacja.pediatra);

            Lekarz l4 = new Lekarz("Karol", "Bik", EnumPlec.mężczyzna, "817236123", "89012318745");
            l4.DodajSpecjalizacje(EnumSpecjalizacja.okulista);

            Lekarz l5 = new Lekarz("Sebastian", "Król", EnumPlec.mężczyzna, "123432123", "56120512341");
            l5.DodajSpecjalizacje(EnumSpecjalizacja.neurolog);
            przychodnia.DodajLekarza(l1);
            przychodnia.DodajLekarza(l2);
            przychodnia.DodajLekarza(l3);
            przychodnia.DodajLekarza(l4);
            przychodnia.DodajLekarza(l5);



            Pacjent p1 = new Pacjent("Tomasz", "Kowal", EnumPlec.mężczyzna, "485135789", "49587412568", new DateTime(1999, 1, 1));
            Pacjent p2 = new Pacjent("Karol", "Krawczyk", EnumPlec.mężczyzna, "485124795", "48512489625", new DateTime(1975, 1, 2));
            Pacjent p3 = new Pacjent("Danuta", "Norek", EnumPlec.kobieta, "124578963", "25147896358", new DateTime(1995, 8, 12));
            Pacjent p4 = new Pacjent("Anna", "Tabota", EnumPlec.kobieta, "781212676", "91283782178", new DateTime(2000, 8, 15));
            Pacjent p5 = new Pacjent("Kazimierz", "Wnuk", EnumPlec.mężczyzna, "918237123", "61523615612", new DateTime(1980, 5, 12));
            Pacjent p6 = new Pacjent("Kamil", "Aleks", EnumPlec.mężczyzna, "109283890", "89120123242", new DateTime(2001, 12, 12));

            przychodnia.DodajPacjenta(p1);
            przychodnia.DodajPacjenta(p2);
            przychodnia.DodajPacjenta(p3);
            przychodnia.DodajPacjenta(p4);
            przychodnia.DodajPacjenta(p5);
            przychodnia.DodajPacjenta(p6);

            przychodnia.ZapiszXML("przychodnia.xml");
            przychodnia = Przychodnia.OdczytXML("przychodnia.xml");
            Console.WriteLine(przychodnia);
            Console.ReadKey();
        }
    }
}
