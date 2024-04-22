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

namespace Pizzza_Admin_felulet.Etlap_menu
{
    /// <summary>
    /// Interaction logic for etlap_menu_feltethozzaadasa_modositasa.xaml
    /// </summary>
    public partial class etlap_menu_feltethozzaadasa_modositasa : Window
    {
        string kapcsolat = (App.Current as App).beconfig(); //SQL Elérése a config fájlból!
        
        public etlap_menu_feltethozzaadasa_modositasa()
        {
            InitializeComponent();
            feltet_lekerdez();
            textBox_ujfeltet.Focus();
        }

        void feltet_ara_lekerdez()
        {
            listBox_feltetar.Items.Clear();
            string kivalasztottfeltet = listBox_jelenlegifeltetek.SelectedItem.ToString();
            string sql = "SELECT feltet_ar FROM feltet WHERE feltet_nev = @KivalasztottFeltet";
            MySqlConnection con = new MySqlConnection(kapcsolat);
            con.Open();
            MySqlCommand msqlc = new MySqlCommand(sql, con);
            msqlc.Parameters.AddWithValue("@kivalasztottFeltet", kivalasztottfeltet);
            MySqlDataReader msdr = msqlc.ExecuteReader();
            while (msdr.Read())
            {
                listBox_feltetar.Items.Add($"{msdr[0]}");

            }
            listBox_feltetar.SelectedIndex = 0;
            msdr.Close();
            con.Close();
        }
        void feltet_lekerdez()   //Feltét elérése az adatbázisból
        {
            listBox_jelenlegifeltetek.Items.Clear();
            MySqlConnection con = new MySqlConnection(kapcsolat);
            con.Open();
            string sql = "SELECT `feltet_nev` FROM `feltet`";
            MySqlCommand msqlc = new MySqlCommand(sql, con);
            MySqlDataReader msdr = msqlc.ExecuteReader();
            while (msdr.Read())
            {
                string tipusnev = msdr["feltet_nev"].ToString();
                if (!string.IsNullOrEmpty(tipusnev))
                {
                    listBox_jelenlegifeltetek.Items.Add(tipusnev);
                    listBox_jelenlegifeltetek.SelectedIndex = 0;

                }
            }
            msdr.Close();
            con.Close();

        }

        void feltet_feltolt() //Feltét  feltöltése az adatbázisba
        {
            MySqlConnection con = new MySqlConnection(kapcsolat);
            con.Open();
            string sql = $"INSERT INTO `feltet` (`feltet_nev`, `feltet_ar`) VALUES (@FeltetNev, @FeltetAr)";
            MySqlCommand msqlc = new MySqlCommand(sql, con);
            msqlc.Parameters.AddWithValue("@FeltetNev", textBox_ujfeltet.Text);
            msqlc.Parameters.AddWithValue("@FeltetAr", textBox_feltetara.Text);
            msqlc.ExecuteNonQuery();
            con.Close();

        }

        void feltet_torol() // Feltét törlése az adatbázisban
        {



            if (listBox_jelenlegifeltetek.SelectedItem != null)
            {


                string kivalasztottfeltet = listBox_jelenlegifeltetek.SelectedItem.ToString();
                MySqlConnection con = new MySqlConnection(kapcsolat);
                con.Open();
                string sql = "DELETE FROM `feltet` WHERE `feltet_nev` = @kivalasztottFeltet";
                MySqlCommand msqlc = new MySqlCommand(sql, con);
                msqlc.Parameters.AddWithValue("@kivalasztottFeltet", kivalasztottfeltet);
                msqlc.ExecuteNonQuery();
                con.Close();
            }

            else
            {
                MessageBox.Show("Válasszon ki egy feltétet a törléshez!", "Feltét törlése", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }

        void feltetneve_modosit() // Feltét Nevének Módosítása az adatbázisban
        {

            listBox_feltetar.Items.Clear();
            string kivalasztottFeltet = listBox_jelenlegifeltetek.SelectedItem.ToString();
            string ujFeltet = textBox_modosit_feltet.Text;
            MySqlConnection con = new MySqlConnection(kapcsolat);
            con.Open();
            string sql = "UPDATE `feltet` SET `feltet_nev` = @UjFeltet  WHERE `feltet_nev` = @kivalasztottFeltet";
            MySqlCommand msqlc = new MySqlCommand(sql, con);
            msqlc.Parameters.AddWithValue("@UjFeltet", ujFeltet);
            msqlc.Parameters.AddWithValue("@kivalasztottFeltet", kivalasztottFeltet);
            MySqlDataReader msdr = msqlc.ExecuteReader();
            msdr.Close();
            con.Close();
        }

        void feltetara_modosit() // Feltét árának Módosítása az adatbázisban
        {


            string kivalasztottFeltet = listBox_jelenlegifeltetek.SelectedItem.ToString();
            string ujFeltet = textBox_ujfeltetara.Text;
            MySqlConnection con = new MySqlConnection(kapcsolat);
            con.Open();
            string sql = "UPDATE `feltet` SET `feltet_ar` = @UjAr  WHERE `feltet_nev` = @kivalasztottFeltet";
            MySqlCommand msqlc = new MySqlCommand(sql, con);
            msqlc.Parameters.AddWithValue("@UjAr", ujFeltet);
            msqlc.Parameters.AddWithValue("@kivalasztottFeltet", kivalasztottFeltet);
            MySqlDataReader msdr = msqlc.ExecuteReader();
            msdr.Close();
            con.Close();
        }
        private void button_bezar_Click(object sender, RoutedEventArgs e) // Az egész program bezárása.
        {
            if (MessageBox.Show("Biztos, hogy bezárja a programot?", "Adminisztrációs felület bezárása", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                this.Close();
        }

        private void button_kismeret_Click(object sender, RoutedEventArgs e) //Kis Méretezés a tálcára
        {
            this.WindowState = WindowState.Minimized;

        }

        private void button_home_Click(object sender, RoutedEventArgs e) //Vissza a Főoldalra!
        {
            Fomenu F_menu = new Fomenu();
            F_menu.Show();
            this.Close();
        }

        private void textBox_ujfeltet_TextChanged(object sender, TextChangedEventArgs e) //Új feltét hozzáadásakor ne lehessen üres mezőt hozzáadni
        {
            if (textBox_ujfeltet.Text != "" && textBox_feltetara.Text !="") button_feltet_hozzaad.IsEnabled = true;
            else button_feltet_hozzaad.IsEnabled = false;
        }

        private void button_feltet_modosit_Click(object sender, RoutedEventArgs e)  //Meglévő feltét módosítása
        {
            if (listBox_jelenlegifeltetek.SelectedItem != null)
            {

                if (MessageBox.Show("Biztos, hogy módosítja a Feltétet?", "Meglévő Feltét módosítása", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    feltetneve_modosit();
                    listBox_jelenlegifeltetek.Items.Clear();
                    feltet_lekerdez();
                    MessageBox.Show("A Feltét neve módosult!", "Meglévő Feltét módosítása", MessageBoxButton.OK, MessageBoxImage.Information);
                    textBox_modosit_feltet.Text = "";
                }

            }
        }

        private void button_ar_modosit_Click(object sender, RoutedEventArgs e) //Meglévő feltét  ÁR módosítása
        {
            

                if (MessageBox.Show("Biztos, hogy módosítja a Feltét árát?", "Meglévő Feltét árának módosítása", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    feltetara_modosit();
                    listBox_feltetar.Items.Clear();
                    feltet_lekerdez(); 
                    MessageBox.Show("A Feltét ára módosult!", "Meglévő Feltét árának módosítása", MessageBoxButton.OK, MessageBoxImage.Information);
                    textBox_ujfeltetara.Text = "";
                }
            
        }
    


        private void button_tipus_torles_Click(object sender, RoutedEventArgs e)    //Meglévő feltét  törlése
        {
            try
            {


                if (listBox_jelenlegifeltetek.SelectedItem != null)
                {
                    if (MessageBox.Show("Biztos, hogy törli a feltétet?", "Feltét törlése", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        feltet_torol();
                        listBox_feltetar.Items.Clear();
                        listBox_jelenlegifeltetek.Items.Clear();
                        feltet_lekerdez();
                        MessageBox.Show("A feltét sikeresen törölve.", "Feltét törlése", MessageBoxButton.OK, MessageBoxImage.Information);
                    }

                }
                else
                {
                    MessageBox.Show("Válasszon ki egy Feltétet a törléshez!", "Feltét törlése", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch

            {
                MessageBox.Show("Ameddig használja a Feltétet addig nem törölheti!", "Feltét törlése", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        

        private void Window_MouseDown(object sender, MouseButtonEventArgs e) //etlap_menu_feltéthozzáadása ablakának mozgatása
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();

            }
        }

        private void button_vissza_Click(object sender, RoutedEventArgs e)  //Vissza az Étlap Főmenü oldalra!
        {
            Etlap_fomenu etlapf_menu = new Etlap_fomenu();
            etlapf_menu.Show();
            this.Close();
        }

        private void textBox_feltetures_hozzaadas_TextChanged(object sender, TextChangedEventArgs e) //Ha feltét neve és ára üres ne engedélyezze a gombot!
        {
            if (textBox_ujfeltet.Text != "" && textBox_feltetara.Text !="") button_feltet_hozzaad.IsEnabled = true;
            else button_feltet_hozzaad.IsEnabled = false;
        }

        private void textBox_feltetar_modosit_TextChanged(object sender, TextChangedEventArgs e) // Ha nincs kiválasztva elem és nincs megadva név akkor ne engedélyezze a gombot az ár módosításához!
        {
            if (textBox_ujfeltetara.Text != "" && listBox_feltetar.SelectedIndex != -1) button_feltet_modosit_ar.IsEnabled = true;
            else button_feltet_modosit_ar.IsEnabled = false;
        }

        private void button_feltet_hozzaad_Click(object sender, RoutedEventArgs e) //Feltét Hozáadása az adatbázishoz!
        {
            string kivalasztott_feltet = textBox_ujfeltet.Text.ToLower();
            bool megegyezo = false;
            foreach (var item in listBox_jelenlegifeltetek.Items)
            {
                if (item.ToString().ToLower() == kivalasztott_feltet)
                {
                    megegyezo = true;
                    MessageBox.Show("A megadott feltét neve már egyszer szerepel a feltétek között!.", "Feltét hozzáadása", MessageBoxButton.OK, MessageBoxImage.Information);
                    textBox_ujfeltet.Text="";
                    textBox_feltetara.Text ="";
                    textBox_ujfeltet.Focus();
                    break;
                    
                }
            }
                if (!megegyezo)
                {
                    if (MessageBox.Show("Biztos, hogy hozzáadja a feltétet?", "Új Feltét hozzáadása", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        feltet_feltolt();
                        if (MessageBox.Show("A feltét sikeresen hozzáadva.", "Feltét hozzáadása", MessageBoxButton.OK, MessageBoxImage.Information) == MessageBoxResult.OK)
                            listBox_jelenlegifeltetek.Items.Clear(); // Amikor hozzáadjuk az elemeket a listához akkor frissítse a listát. 
                        feltet_lekerdez();

                    }
                    textBox_ujfeltet.Text = ""; //Gomb megnyomásakor legyen újra üres a textBox_ujfeltet-nek a textboxja
                    textBox_feltetara.Text = "";    //Gomb megnyomásakor legyen újra üres a textBox_feltetara-nak a textboxja
                    textBox_ujfeltet.Focus();

            }  
            
        }

       
        private void textBox_ujfeltetneve_TextChanged(object sender, TextChangedEventArgs e) // Ha nincs kiválasztva elem és nincs megadva név akkor ne engedélyezze a gombot a feltét nevének megváltoztatásához!
        {
            if (textBox_modosit_feltet.Text != "" && listBox_jelenlegifeltetek.SelectedIndex != -1) button_feltet_modosit.IsEnabled = true;
            else button_feltet_modosit.IsEnabled = false;
        }

        private void listBox_jelenlegifeltetek_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBox_jelenlegifeltetek.SelectedIndex !=-1)
            {
                feltet_ara_lekerdez();
            }
        }
    }
    
    
}
