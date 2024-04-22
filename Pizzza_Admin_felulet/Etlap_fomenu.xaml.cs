using Pizzza_Admin_felulet.Etlap_menu;
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
    /// Interaction logic for Etlap_fomenu.xaml
    /// </summary>
    /// 
    
    public partial class Etlap_fomenu : Window
    {
       
        public Etlap_fomenu()
        {
            InitializeComponent();
           
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e) //Étlap_főmenü ablakának mozgatása
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();

            }
        }
        private void button_home_Click(object sender, RoutedEventArgs e) //Vissza a Főoldalra!
        {
            Fomenu F_menu = new Fomenu();
            F_menu.Show();
            this.Close();
        }

        private void button_bezar_Click(object sender, RoutedEventArgs e) // Az egész program bezárása.
        {
            if (MessageBox.Show("Biztos, hogy bezárja a programot?", "Adminisztrációs felület bezárása", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                this.Close();
        }

        private void button_termektipusa_Click(object sender, RoutedEventArgs e) //A termék típusa menü megnyitása
        {
            etlap_menu_termektipusa termektipusa_m = new etlap_menu_termektipusa();
            termektipusa_m.Show();
            this.Close();
        }

        private void button_etlapmodositasa_Click(object sender, RoutedEventArgs e) //Az étlap menü megnyitása.
        {
            etlap_menu_etlapmodositasa etlapmodositasa_m = new etlap_menu_etlapmodositasa();
            etlapmodositasa_m.Show();
            this.Close();
        }

        private void button_ujtermekfelvitele_Click(object sender, RoutedEventArgs e) // Az új termék felvitele menü megnyitása.
        {
            Etlap_menu_ujtermek ujtermek_m = new Etlap_menu_ujtermek();
            ujtermek_m.Show();
            this.Close();
        }

        private void button_vissza_Click(object sender, RoutedEventArgs e) //Vissza a Főoldalra menü oldalra!
        { 
            Fomenu etlapf_menu = new Fomenu();
            etlapf_menu.Show();
            this.Close();
        }

        private void button_kismeret_Click(object sender, RoutedEventArgs e)    //Kis Méretezés a tálcára
        {
            this.WindowState = WindowState.Minimized;
        }

        private void button_feltetletrehoz_modosit_Click(object sender, RoutedEventArgs e) //A Feltét létrehoz/módosít menü megnyitása.
        {
            etlap_menu_feltethozzaadasa_modositasa feltethozzadasa_menu = new etlap_menu_feltethozzaadasa_modositasa();
            feltethozzadasa_menu.Show();
            this.Close();
        }
    }
}
