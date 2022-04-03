using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Shapes;
using Projekt;

namespace ProjektGUI
{
    /// <summary>
    /// Interaction logic for PacjentWindow.xaml
    /// </summary>
    public partial class PacjentWindow : Window
    {
        Pacjent pacjent;
        public PacjentWindow()
        {
            InitializeComponent();
        }
        public PacjentWindow(Pacjent p) : this()
        {
            pacjent = p;
            txtPesel.Text = pacjent.Pesel;
            txtImie.Text = pacjent.Imie;
            txtNazwisko.Text = pacjent.Nazwisko;
            txtDataUr.Text = $"{pacjent.DataUrodzenia:dd-MMM-yyyy}";
            CbmBoxPlec.Text = (pacjent.Plec == EnumPlec.kobieta) ? "Kobieta" : "Mężczyzna";

        }
        private void btnZatwierdz_Click(object sender, RoutedEventArgs e)
        {
            if (txtPesel.Text != "" || txtImie.Text != "" || txtNazwisko.Text != "")
            {
                pacjent.Pesel = txtPesel.Text;
                pacjent.Imie = txtImie.Text;
                pacjent.Nazwisko = txtNazwisko.Text;
                DateTime.TryParseExact(txtDataUr.Text, new[] { "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yy", "dd-MMM-yy", "dd-MM-yyyy" }, null, DateTimeStyles.None, out DateTime date);
                pacjent.DataUrodzenia = date;
                if (CbmBoxPlec.Text == "kobieta")
                {
                    pacjent.Plec = EnumPlec.kobieta;
                }
                else
                {
                    pacjent.Plec=EnumPlec.mężczyzna;
                }
                DialogResult = true;
            }
            else
            {
                DialogResult = false;
            }

            

        }
        private void btnAnuluj_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
 
} 
    

