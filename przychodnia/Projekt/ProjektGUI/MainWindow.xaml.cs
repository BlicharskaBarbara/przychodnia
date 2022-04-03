using Projekt;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjektGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Przychodnia przychodnia;
             
        public MainWindow()
        {
            InitializeComponent();
        }

        private void listViewLekarz_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listViewLekarz.SelectedIndex > -1)
            {
                var lekarz = listViewLekarz.SelectedItem as Lekarz;
                var terminy = lekarz.PodajWolneTerminy();

                listViewTerminy.ItemsSource = new ObservableCollection<DateTime>(terminy);
            }

        }
        private void btnDodajWizyte_Click(object sender, RoutedEventArgs e)
        {

           
            Lekarz l = przychodnia.Lekarze[listViewLekarz.SelectedIndex];
            Pacjent p = przychodnia.Pacjenci[listViewPacjent.SelectedIndex];
            var terminy = l.PodajWolneTerminy();
            listViewTerminy.ItemsSource = new ObservableCollection<DateTime>(terminy);
            l.DodajWizyte(terminy[listViewTerminy.SelectedIndex], p);

            przychodnia.ZapiszXML("przychodnia.xml");

        }

        private void btnWyswietl_Click(object sender, RoutedEventArgs e)
        {
            Pacjent p = przychodnia.Pacjenci[listViewPacjent.SelectedIndex];
            var wizyty = przychodnia.WyswietlWizyty(p);
            lstWizyty.ItemsSource = new ObservableCollection<Wizyta>(wizyty);

        }

        private void btnSortuj_Click(object sender, RoutedEventArgs e)
        {
            przychodnia.Sortuj();
            przychodnia.ZapiszXML("przychodnia.xml");
            listViewPacjent.ItemsSource = new ObservableCollection<Pacjent>(przychodnia.Pacjenci);

        }



        private void btnZrezygnuj_Click(object sender, RoutedEventArgs e)
        {
            Wizyta w = lstWizyty.SelectedItem as Wizyta;
            przychodnia.ZrezygnujzWizyty(w);
            przychodnia.ZapiszXML("przychodnia.xml");
            Pacjent p = przychodnia.Pacjenci[listViewPacjent.SelectedIndex];
            var wizyty = przychodnia.WyswietlWizyty(p);
            lstWizyty.ItemsSource = new ObservableCollection<Wizyta>(wizyty);
        }

        private void UsunPacjenta_Click(object sender, RoutedEventArgs e)
        {
            Pacjent p = przychodnia.Pacjenci[listViewPacjent.SelectedIndex];
            przychodnia.UsunPacjenta(p.Pesel);
            przychodnia.ZapiszXML("przychodnia.xml");
            listViewPacjent.ItemsSource = new ObservableCollection<Pacjent>(przychodnia.Pacjenci);
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            Pacjent pac = new Pacjent();
            PacjentWindow okno = new PacjentWindow(pac);
            bool? result = okno.ShowDialog();
            if (result == true)
            {
                przychodnia.DodajPacjenta(pac); 
                listViewPacjent.ItemsSource = new ObservableCollection<Pacjent>(przychodnia.Pacjenci);
            }
        }
        private void MenuWyjdz_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MenuOtworz_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string filename = dlg.FileName;
                przychodnia = Przychodnia.OdczytXML(filename);
                if (przychodnia is object)
                {
                    listViewLekarz.ItemsSource = new ObservableCollection<Lekarz>(przychodnia.Lekarze);
                    listViewPacjent.ItemsSource = new ObservableCollection<Pacjent>(przychodnia.Pacjenci);
                }
            }

        }

    }
}
