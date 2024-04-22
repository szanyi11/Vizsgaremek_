using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace Pizzza_Admin_felulet.Etlap_menu
{
    /// <summary>
    /// Interaction logic for etlap_menu_termektipusa.xaml
    /// </summary>
    public partial class etlap_menu_termektipusa : Window
    {
        string kapcsolat = (App.Current as App).beconfig(); //SQL Elérése a config fájlból!
        public etlap_menu_termektipusa()
        {
            InitializeComponent();
            termek_tipusa_lekerdez();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e) //etlap_menu_termektipusa ablakának mozgatása
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();

            }
        }
        void termek_tipusa_lekerdez()   //Típus elérése az adatbázisból
        {
            MySqlConnection con = new MySqlConnection(kapcsolat);
            con.Open();
            string sql = "SELECT `tipus_nev` FROM `tipus`";
            MySqlCommand msqlc = new MySqlCommand(sql, con);
            MySqlDataReader msdr = msqlc.ExecuteReader();
            while (msdr.Read())
            {
                string tipusnev = msdr["tipus_nev"].ToString();
                if (!string.IsNullOrEmpty(tipusnev))
                {
                    listBox_jelenlegitipusok.Items.Add(tipusnev);
                    listBox_jelenlegitipusok.SelectedIndex = 0;

                }
            }
            msdr.Close();
            con.Close();
            
        }       
        void termek_tipusa_feltolt() //Típus feltöltése az adatbázisba
        {
            
                string[] ujTipus = textBox_ujtipus.Text.Split(',');
                MySqlConnection con = new MySqlConnection(kapcsolat);
                con.Open();
                string sql = $"INSERT INTO `tipus`(`tipus_nev`) VALUES";
                for (int item = 0; item < ujTipus.Length; item++)
                {
                    sql += $"(@UjTipus{item}),";
                }
                sql = sql.TrimEnd(',');
                MySqlCommand msqlc = new MySqlCommand(sql, con);

                for (int item = 0; item < ujTipus.Length; item++)
                {
                    msqlc.Parameters.AddWithValue($"@UjTipus{item}", ujTipus[item]);
                }
                msqlc.ExecuteNonQuery();
                con.Close();
   
        }

        void termek_modosit() // Termék Módosítása az adatbázisban
        {

            
                string kivalasztottTipus = listBox_jelenlegitipusok.SelectedItem.ToString();
                string ujTipus = textBox_modosit_tipus.Text;
                MySqlConnection con = new MySqlConnection(kapcsolat);
                con.Open();
                string sql = "UPDATE `tipus` SET `tipus_nev` = @ujTipus WHERE `tipus_nev` = @kivalasztottTipus";
                MySqlCommand msqlc = new MySqlCommand(sql, con);
                msqlc.Parameters.AddWithValue("@ujTipus", ujTipus);
                msqlc.Parameters.AddWithValue("@kivalasztottTipus", kivalasztottTipus);
                MySqlDataReader msdr = msqlc.ExecuteReader();
                msdr.Close();
                con.Close();        
        }

        void termek_torol() // Termék Módosítása az adatbázisban
        {
            


                if (listBox_jelenlegitipusok.SelectedItem != null)
                {


                    string kivalasztottTipus = listBox_jelenlegitipusok.SelectedItem.ToString();
                    MySqlConnection con = new MySqlConnection(kapcsolat);
                    con.Open();
                    string sql = "DELETE FROM `tipus` WHERE `tipus_nev` = @kivalasztottTipus";
                    MySqlCommand msqlc = new MySqlCommand(sql, con);
                    msqlc.Parameters.AddWithValue("@kivalasztottTipus", kivalasztottTipus);
                    msqlc.ExecuteNonQuery();
                    con.Close();
                }

                else
                {
                    MessageBox.Show("Válasszon ki egy típust a törléshez!", "Típus törlése", MessageBoxButton.OK, MessageBoxImage.Error);
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

        private void button_vissza_Click(object sender, RoutedEventArgs e)  //Vissza az Étlap Főmenü oldalra!
        {
            Etlap_fomenu etlapf_menu = new Etlap_fomenu();
            etlapf_menu.Show();
            this.Close();
        }
        private void button_kismeret_Click(object sender, RoutedEventArgs e) //Kis Méretezés a tálcára
        {
            this.WindowState = WindowState.Minimized;

        }

        private void textBox_ujtipus_TextChanged(object sender, TextChangedEventArgs e) //Új típus hozzáadásakor ne lehessen üres mezőt hozzáadni
        {
            if (textBox_ujtipus.Text !="") button_tipus_hozzaad.IsEnabled = true;
            else button_tipus_hozzaad.IsEnabled = false;


        }

        private void button_tipus_hozzaad_Click(object sender, RoutedEventArgs e) //Új típus hozzáadása
        {
            string kivalasztott_feltet = textBox_ujtipus.Text.ToLower();
            bool megegyezo = false;
            foreach (var item in listBox_jelenlegitipusok.Items)
            {
                if (item.ToString().ToLower() == kivalasztott_feltet)
                {
                    megegyezo = true;
                    MessageBox.Show("A megadott típus neve már egyszer szerepel a típusok között!", "Feltét hozzáadása", MessageBoxButton.OK, MessageBoxImage.Information);
                    textBox_ujtipus.Text = "";
                    textBox_ujtipus.Focus();
                    break;

                }
            }
            if (!megegyezo)
            {
                if (MessageBox.Show("Biztos, hogy hozzáadja a típust?", "Új típus hozzáadása", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    termek_tipusa_feltolt();
                    if (MessageBox.Show("A típus sikeresen hozzáadva.", "Típus hozzáadása", MessageBoxButton.OK, MessageBoxImage.Information) == MessageBoxResult.OK)
                        listBox_jelenlegitipusok.Items.Clear(); // Amikor hozzáadjuk az elemeket a listához akkor frissítse a listát. 
                    termek_tipusa_lekerdez();
                    textBox_ujtipus.Focus();

                }
                textBox_ujtipus.Text = ""; //Gomb megnyomásakor legyen újra üres a ujtipus.textbox
            } 
        }

        private void button_tipus_torles_Click(object sender, RoutedEventArgs e) //Meglévő típusok törlése
        {
            try
            {
                if (listBox_jelenlegitipusok.SelectedItem != null)
                {
                    if (MessageBox.Show("Biztos, hogy törli a Típust? Ha letörli a Típust, akkor a típus összes adata elveszik!", "Típus törlése", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        if (MessageBox.Show("Biztos, benne, hogy letörli a típust az összes eddigi adatával együtt?", "Típus törlése", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            termek_torol();
                            listBox_jelenlegitipusok.Items.Clear();
                            termek_tipusa_lekerdez();
                            MessageBox.Show("A típus sikeresen törölve.", "Típus törlése", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        
                    }

                }
                else
                {
                    MessageBox.Show("Válasszon ki egy típust a törléshez!", "Típus törlése", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch

            {
                MessageBox.Show("Ameddig használja a típust addig nem törölheti!", "Típus törlése", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        

        private void button_tipus_modosit_Click(object sender, RoutedEventArgs e) //Meglévő típus módosítása
        {
            try
            {
                if (listBox_jelenlegitipusok.SelectedItem != null)
                {

                    if (MessageBox.Show("Biztos, hogy módosítja a típust?", "Meglévő típus módosítása", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        termek_modosit();
                        listBox_jelenlegitipusok.Items.Clear();
                        termek_tipusa_lekerdez();
                        MessageBox.Show("A típus neve módosult!", "Meglévő típus módosítása", MessageBoxButton.OK, MessageBoxImage.Information);
                        textBox_modosit_tipus.Text = "";
                    }

                }

            }
            catch 
            {

                MessageBox.Show("Ameddig használja a típust addig nem módosíthatja!", "Meglévő Típus Módosítása", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox_modosit_tipus.Text = "";
            }
        }

        private void textBox_modosit_tipus_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textBox_modosit_tipus.Text != "" && listBox_jelenlegitipusok.Items != listBox_jelenlegitipusok.SelectedItem )button_tipus_modosit.IsEnabled = true;
            else button_tipus_modosit.IsEnabled = false;

        }

        
    }
}
