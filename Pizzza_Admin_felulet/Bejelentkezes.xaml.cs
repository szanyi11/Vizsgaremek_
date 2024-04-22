using MySql.Data.MySqlClient;
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
    /// Interaction logic for Bejelentkezes.xaml
    /// </summary>
    public partial class Bejelentkezes : Window
    {
        string kapcsolat = (App.Current as App).beconfig(); //SQL Elérése a config fájlból!
        public Bejelentkezes()
        {
            InitializeComponent();
            textBox_fehasznalonev_input.Focus(); //Program indulásakor a Focus a textBox_fehasznalonev-en legyen
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e) //Bejelentkezés ablakának mozgatása
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();

            }
        }

        private void button_bezar_Click(object sender, RoutedEventArgs e) //Az egész program bezárása.
        {
            if (MessageBox.Show("Biztos, hogy bezárja a programot?", "Adminisztrációs felület bezárása", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            this.Close();


        }

        private void button_bejelentkezes_Click(object sender, RoutedEventArgs e) //Bejelentkezés az ADMIN felületbe.
        {
            try
            {

                string sql = "SELECT admin_felhasznalon FROM admin WHERE admin_felhasznalon = @felhasznalo AND admin_jelszo = @jelszo";
                MySqlConnection con = new MySqlConnection(kapcsolat);
                con.Open();
                MySqlCommand msqlc = new MySqlCommand(sql, con);
                msqlc.Parameters.AddWithValue("@felhasznalo", textBox_fehasznalonev_input.Text);
                msqlc.Parameters.AddWithValue("@jelszo", passwordBox_jelszo_input.Password);
                MySqlDataReader msdr = msqlc.ExecuteReader();
                string felh_id = "";
                while (msdr.Read())
                {
                    felh_id = msdr[0].ToString();
                }
                msdr.Close();
                con.Close();
                if (felh_id !="")
                {
                    Fomenu Fomenu_fel = new Fomenu();
                    Fomenu_fel.Show();
                    this.Close();
                }
                else MessageBox.Show("Nem megelelőek a bejelentkezési adatok!", "Hiba a bejelentkezés során", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch
            {
                MessageBox.Show("Hiba történt a bejelentkezés során!", "Hiba a bejelentkezés során", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void bejelentkezes(object sender, TextChangedEventArgs e) //Ha üres a textbox tiltsa le a bejelenetkezés gombot!
        {


            if (textBox_fehasznalonev_input.Text != "" && passwordBox_jelszo_input.Password != "") button_bejelentkezes.IsEnabled = true;
            else button_bejelentkezes.IsEnabled = false;


        }

        private void button_kismeret_Click(object sender, RoutedEventArgs e) //Kis Méretezés a tálcára
        {
            this.WindowState = WindowState.Minimized;

        }

        private void passwordBox_jelszo_input_PasswordChanged(object sender, RoutedEventArgs e) //Ha üres a textbox tiltsa le a bejelenetkezés gombot!
        {
            if (textBox_fehasznalonev_input.Text != "" && passwordBox_jelszo_input.Password != "") button_bejelentkezes.IsEnabled = true;
            else button_bejelentkezes.IsEnabled = false;
        }
    }
}
