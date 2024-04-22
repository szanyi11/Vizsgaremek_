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
    /// Interaction logic for Fomenu.xaml
    /// </summary>
    public partial class Fomenu : Window
    {
        public Fomenu()
        {
            InitializeComponent();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e) //Főmenü ablakának mozgatása
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();

            }
        }
        private void button_bezar_Click(object sender, RoutedEventArgs e)  //A fő programunk bezárásának eseménye
        {
            if (MessageBox.Show("Biztos, hogy bezárja a programot?", "Adminisztrációs felület bezárása", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                this.Close();
        }

        private void button_etlap_Click(object sender, RoutedEventArgs e) //Étlap Főmenüjének megnyitása
        {
            Etlap_fomenu Etlap_fmenu = new Etlap_fomenu();
            Etlap_fmenu.Show();
            this.Close();
        }

        private void button_rendelesek_Click(object sender, RoutedEventArgs e) //Rendelések Főmenüjének megnyitása
        {
            Rendelesek_fomenu Rendelesek_fmenu = new Rendelesek_fomenu();
            Rendelesek_fmenu.Show();
            this.Close();
        }

        private void button_modositasok_Click(object sender, RoutedEventArgs e) //Módosítások Főmenüjének megnyitása
        {
            Modositasok_fomenu modositasok_fmenu = new Modositasok_fomenu();
            modositasok_fmenu.Show();
            this.Close();
        }

        private void button_segitseg_Click(object sender, RoutedEventArgs e) //Segítség Főmenüjének megnyitása 
        {
            Segitseg_fomenu Segitseg_fmenu = new Segitseg_fomenu();
            Segitseg_fmenu.Show();
            this.Close();
        }

        private void button_kismeret_Click(object sender, RoutedEventArgs e) //Kis Méretezés a tálcára
        {
            this.WindowState = WindowState.Minimized;
        }

        
    }
}
