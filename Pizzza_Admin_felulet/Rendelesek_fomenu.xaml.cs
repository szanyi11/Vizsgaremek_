using System;
using System.Collections.Generic;
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

namespace Pizzza_Admin_felulet
{
    /// <summary>
    /// Interaction logic for Rendelesek_fomenu.xaml
    /// </summary>
    public partial class Rendelesek_fomenu : Window
    {
        string kapcsolat = (App.Current as App).beconfig(); //SQL Elérése a config fájlból!

        public class Adatok
        {
            public int rajtszam { get; set; }
            public string idopont { get; set; }
            public string enev { get; set; }
            public Adatok(int _rajtszam, string _idopont, string _enev)
            {
                rajtszam = _rajtszam;
                idopont = _idopont;
                enev = _enev;
            }
        }
        public Rendelesek_fomenu()
        {
            InitializeComponent();
        }

        private void button_bezar_Click(object sender, RoutedEventArgs e) // Az egész program bezárása.
        {
            if (MessageBox.Show("Biztos, hogy bezárja a programot?", "Adminisztrációs felület bezárása", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                this.Close();
        }

        private void button_home_Click(object sender, RoutedEventArgs e) //Vissza a Főoldalra!
        {
            Fomenu F_menu = new Fomenu();
            F_menu.Show();
            this.Close();
        }

        private void button_fomenube_Click(object sender, RoutedEventArgs e) //Vissza a Főoldalra menü oldalra!
        {
            Fomenu etlapf_menu = new Fomenu();
            etlapf_menu.Show();
            this.Close();
        }

        private void button_kismeret_Click(object sender, RoutedEventArgs e)  //Kis Méretezés a tálcára
        {
            this.WindowState = WindowState.Minimized;
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e) //Rendelesek_fomenu ablakának mozgatása
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();

            }
        }
    }
}
