using Microsoft.Win32;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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

    public partial class etlap_menu_etlapmodositasa : Window
    {
        string cel = "";
        string kepneve;
        string kapcsolat = (App.Current as App).beconfig(); //SQL Elérése a config fájlból!
        

        public etlap_menu_etlapmodositasa() 
        {
            InitializeComponent();
            termek_tipusa_lekerdez();
            string termekneve_regi = textBox_termekneve_regi.Text;
            string termek_ara = textBox_termekara.Text;
            string termek_leiras = textBox_termekleiras_regi.Text;
        }
        void kep_kivalaszt() //Kép kiválasztása a gomb megnyomásakor
        {
            OpenFileDialog filedialog = new OpenFileDialog();
            filedialog.Title = "Válasszon ki egy képet";
            filedialog.Filter = "Kép fájlok(*.jpg, *.jpeg, *.png)|*.jpg; *.jpeg; *.png";
            if (filedialog.ShowDialog() == true)
            {
                kepneve = filedialog.FileName;
                BitmapImage bitmap = new BitmapImage(new Uri(kepneve));
                image_kivlasztott_kep.Source = bitmap;
            }   
        }
        void kepbetolteseadatbazisbol() 
        {
            string kivalasztott = comboBox_termek.SelectedItem?.ToString();
            MySqlConnection con = new MySqlConnection(kapcsolat);
            con.Open();
            string sql = "SELECT etlap2_kep FROM etlap WHERE etlap2_nev = @Kivalasztottkep";
            MySqlCommand msqlc = new MySqlCommand(sql, con);
            msqlc.Parameters.AddWithValue("@Kivalasztottkep", kivalasztott);
            string kepnev = msqlc.ExecuteScalar()?.ToString();
            if (!string.IsNullOrEmpty(kepnev))
            {
                string kepeleres = System.IO.Path.Combine(@"upload_images/",kepnev);

                if (System.IO.File.Exists(kepeleres))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(kepeleres,UriKind.Relative);
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.EndInit();
                    image_jelenlegi_kep.Source = bitmapImage; 
                }
            }
            con.Close();
            kepneve=kepnev.Split('/').Last();
            image_kivlasztott_kep.Source = null;
        }

        void termek_torol() // Feltét törlése az adatbázisban
        {



            if (comboBox_termek.SelectedItem != null)
            {
                string kivalasztotttermek = comboBox_termek.SelectedItem.ToString();
                MySqlConnection con = new MySqlConnection(kapcsolat);
                con.Open();
                string sql = "DELETE FROM `etlap` WHERE `etlap2_nev` = @KivalasztottTermek";
                MySqlCommand msqlc = new MySqlCommand(sql, con);
                msqlc.Parameters.AddWithValue("@KivalasztottTermek", kivalasztotttermek);
                msqlc.ExecuteNonQuery();
                con.Close();
            }

            else
            {
                MessageBox.Show("Válasszon ki egy feltétet a törléshez!", "Feltét törlése", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e) //etlap_menu_etlapmodositasa ablakának mozgatása
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();

            }
        }
        void termek_kivalasztott() //Termék kiválasztása és meghívása ha típus üres akkor boxok üresre állítása. És hibaüzenet
        {
               string kivalasztott = comboBox_termek.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(kivalasztott))
            {
                textBox_termekneve_regi.Text = "";
                textBox_termekara.Text = "";
                textBox_termekleiras_regi.Text = "";
            }
                MySqlConnection con = new MySqlConnection(kapcsolat);
                con.Open();
                string sql = "SELECT `etlap2_nev`,`etlap2_ar`,`etlap2_leiras` FROM etlap WHERE etlap2_nev = @Kivalasztott;";
                MySqlCommand msqlc = new MySqlCommand(sql, con);
                msqlc.Parameters.AddWithValue("@Kivalasztott", kivalasztott);
                MySqlDataReader msdr = msqlc.ExecuteReader();
                while (msdr.Read())
                {
                    textBox_termekneve_regi.Text = msdr.GetValue(0).ToString();
                    textBox_termekara.Text = msdr.GetValue(1).ToString();
                    textBox_termekleiras_regi.Text = msdr.GetValue(2).ToString();
                }
                msdr.Close();
                con.Close();
                
            
          
        }
        void termek_tipusa_lekerdez()//Típus elérése az adatbázisból
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
                    comboBox_termektipusa.Items.Add(tipusnev);
                    comboBox_termektipusa.SelectedIndex = 0;
                    
                }
            }   
            msdr.Close();
            con.Close();
        }     
        
        void termek_kivalasztasa() //Kiválasztott típusban szereplő termékek lekérdezése
        {
                comboBox_termek.Items.Clear();
                string kijelolttipus = comboBox_termektipusa.SelectedItem.ToString();
                MySqlConnection con = new MySqlConnection(kapcsolat);
                con.Open();

                string sql = "SELECT * FROM `etlap` WHERE `tipus` = @KijeloltTipus";
                MySqlCommand msqlc = new MySqlCommand(sql, con);
                msqlc.Parameters.AddWithValue("@KijeloltTipus", kijelolttipus);
                MySqlDataReader msdr = msqlc.ExecuteReader();
                while (msdr.Read())
                {
                string etlap2_nev = msdr.GetString("etlap2_nev");
                comboBox_termek.Items.Add(etlap2_nev);
                comboBox_termek.SelectedIndex= 0;
                }
                con.Close();
            
            
            
        }

        void termek_modositasa(string a, string b, string c, string d) //Kiválasztott termék módosítása az adatbázisban
        {
                string kivalasztott = comboBox_termek.SelectedItem?.ToString();
                MySqlConnection con = new MySqlConnection(kapcsolat);
                con.Open();
                string sql = $"UPDATE `etlap` SET `etlap2_nev` = @EtlapNev, `etlap2_ar` = @EtlapAr, `etlap2_leiras` = @TermekLeiras, `etlap2_kep`=@Kep WHERE `etlap2_nev` = @Kivalasztott";
                MySqlCommand msqlc = new MySqlCommand(sql, con);
                msqlc.Parameters.AddWithValue("@Kivalasztott", kivalasztott);
                msqlc.Parameters.AddWithValue("@EtlapNev", a);
                msqlc.Parameters.AddWithValue("@EtlapAr", b);
                msqlc.Parameters.AddWithValue("@TermekLeiras",c);
                msqlc.Parameters.AddWithValue("@Kep", d);
                msqlc.ExecuteNonQuery();    
                con.Close();
        }

        private void button_bezar_Click(object sender, RoutedEventArgs e) // Az egész program bezárása.
        {
            if (MessageBox.Show("Biztos, hogy bezárja a programot?", "Program bezárása", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                this.Close();
        }

        private void button_home_Click(object sender, RoutedEventArgs e)  //Vissza a Főoldalra!
        {
            Fomenu F_menu = new Fomenu();
            F_menu.Show();
            this.Close();
        }

        private void button_vissza_Click(object sender, RoutedEventArgs e) //Vissza az Étlap Főmenü oldalra!
        {
            Etlap_fomenu etlapf_menu = new Etlap_fomenu();
            etlapf_menu.Show();
            this.Close();
        }

        private void button_kismeret_Click(object sender, RoutedEventArgs e)   //Kis Méretezés a tálcára
        {
            this.WindowState = WindowState.Minimized;

        }

        private void comboBox_termektipusa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            textBox_termekneve_uj.Text = "";   //Termék típus választásakor ne maradjon az új módosítandó text-boxba szöveg
            textBox_termekara_uj.Text = "";
            textBox_termekleiras_uj.Text = "";
            termek_kivalasztasa();
        }  
            

        private void comboBox_termek_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox_termek.SelectedIndex != 0)
            {
                image_jelenlegi_kep.Source = null; //Üresre állítja a kép megjelenítésekor a kép mezőjét
            }
            termek_kivalasztott();
            //kepbetolteseadatbazisbol();
            if (comboBox_termek.SelectedItem != null)
            {
                kepbetolteseadatbazisbol();
            }


        }

        private void button_feltoltes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Random random = new Random();
                int randomszam = random.Next(1, 99999); //Random szám mely a kép duplikációja miatt van 
                string forras = kepneve;



                string ujtermek = textBox_termekneve_regi.Text;
                if (textBox_termekneve_uj.Text != "") ujtermek = textBox_termekneve_uj.Text;
                string ujar = textBox_termekara.Text;
                if (textBox_termekara_uj.Text != "") ujar = textBox_termekara_uj.Text;
                string ujleiras = textBox_termekleiras_regi.Text;
                if (textBox_termekleiras_uj.Text != "") ujleiras = textBox_termekleiras_uj.Text;
                string ujkep = kepneve;

                if (MessageBox.Show("Biztos, hogy módosítja a terméket?", "Termék módosítása", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    cel = @"upload_images/" + $"{randomszam}" + System.IO.Path.GetFileName(forras);
                    termek_modositasa(ujtermek, ujar, ujleiras, $"{randomszam}" + System.IO.Path.GetFileName(ujkep));
                    FileInfo info = new FileInfo(forras);
                    info.CopyTo(cel);
                    textBox_termekneve_uj.Text = "";
                    textBox_termekara_uj.Text = "";
                    textBox_termekleiras_uj.Text = "";
                    image_kivlasztott_kep.Source = null;

                    if (MessageBox.Show("A termék frissült!", "Termék módosítása", MessageBoxButton.OK, MessageBoxImage.Information) == MessageBoxResult.OK)
                    {
                        termek_kivalasztasa();
                    }
                }
            }
            catch 
            {
                MessageBox.Show("Nincs módosítandó termék!", "Válasszon ki egy terméket a módosításhoz!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
        


        private void button_torles_Click(object sender, RoutedEventArgs e) //Termék törlése
        {
            try
            {


                if (comboBox_termek.SelectedItem != null)
                {
                    if (MessageBox.Show("Biztos, hogy törli a terméket?", "Termék törlése", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        termek_torol();
                        comboBox_termek.Items.Clear();
                        MessageBox.Show("A Termék sikeresen törölve.", "Termék törlése", MessageBoxButton.OK, MessageBoxImage.Information);
                        image_jelenlegi_kep.Source = null;
                        termek_kivalasztasa();
                    }

                }
                else
                {
                    MessageBox.Show("Válasszon ki egy Terméket a törléshez!", "Termék törlése", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch

            {
                MessageBox.Show("Ameddig használja a Terméket addig nem törölheti!", "Termék törlése", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void button_kep_kivalaszt_Click(object sender, RoutedEventArgs e) //Kép kiválasztása esemény
        {
            if (comboBox_termek.SelectedItem !=null) //Ha a  termék kiválasztása üres akkor ne lehessen képet kiválasztani
            {
                kep_kivalaszt();
            }
            
        }
    }
}
