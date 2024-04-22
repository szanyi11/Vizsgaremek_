using Microsoft.Win32;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
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
using static System.Net.Mime.MediaTypeNames;



namespace Pizzza_Admin_felulet.Etlap_menu
{
    /// <summary>
    /// Interaction logic for Etlap_menu_ujtermek.xaml
    /// </summary>
    public partial class Etlap_menu_ujtermek : Window
    {
        string cel = "";
        string kepneve;
        string kapcsolat = (App.Current as App).beconfig(); //SQL Elérése a config fájlból!
        public Etlap_menu_ujtermek()
        {
            InitializeComponent();
            termek_tipusa_lekerdez();
            textBox_termekneve.Focus(); // Amikor az oldal elindul a fókusz legyen az elemen.
            

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
                image_kivalasztott.Source = bitmap;
                if (image_kivalasztott.Source != null && textBox_termekneve.Text != "" && textBox_termekara.Text != "" && textBox_termekleiras.Text != "" && comboBox_termektipusa.SelectedIndex !=-1) button_feltoltes.IsEnabled = true;
                else button_feltoltes.IsEnabled = false;
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
                    comboBox_termektipusa.Items.Add(tipusnev);
                    comboBox_termektipusa.SelectedIndex = 0;

                }
            }

            msdr.Close();
            con.Close();
        }
        
        void etlap_elemei_feltolt()  //Termék elemeinek feltöltése
        {

                cel = cel.Split('/').Last();
                string tipus = comboBox_termektipusa.SelectedItem.ToString();
                MySqlConnection con = new MySqlConnection(kapcsolat);
                con.Open();
                string sql = $"INSERT INTO `etlap` (`etlap2_nev`, `etlap2_kep`, `tipus`, `etlap2_ar`,`etlap2_leiras`) VALUES (@TermekNev,@Kep, @Tipus, @TermekAra,@TermekLeiras)";
                MySqlCommand msqlc = new MySqlCommand(sql, con);
                msqlc.Parameters.AddWithValue("@TermekNev", textBox_termekneve.Text);
                msqlc.Parameters.AddWithValue("@TermekAra", textBox_termekara.Text);
                msqlc.Parameters.AddWithValue("@Tipus", tipus);
                msqlc.Parameters.AddWithValue("@TermekLeiras", textBox_termekleiras.Text);
                msqlc.Parameters.AddWithValue("@Kep", cel);
                msqlc.ExecuteNonQuery();
                con.Close(); 

        }
        private void button_bezar_Click(object sender, RoutedEventArgs e) // Az egész program bezárása.
        {
            if (MessageBox.Show("Biztos, hogy bezárja a programot?", "Adminisztrációs felület bezárása", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
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

        private void button_kismeret_Click(object sender, RoutedEventArgs e)  //Kis Méretezés a tálcára
        {
            this.WindowState = WindowState.Minimized;

        }

        private void textBox_haures(object sender, TextChangedEventArgs e) //Ha üresek a textboxok akkor ne lehessen feltölteni az új terméket
        {
            if (image_kivalasztott.Source != null && textBox_termekneve.Text != "" && textBox_termekara.Text != "" && textBox_termekleiras.Text !="") button_feltoltes.IsEnabled = true;
            else button_feltoltes.IsEnabled = false;
        }

        private void comboBox_termektipusa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {   
        }

        

        private void Window_MouseDown(object sender, MouseButtonEventArgs e) //Étlap menü_Újtermék ablakának mozgatása
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
                
            }
        }

        private void button_feltoltes_Click(object sender, RoutedEventArgs e) //Feltölti a terméket az adatbázisba
        {
            Random random = new Random(); 
            int randomszam = random.Next(1, 99999); //Random szám mely a kép duplikációja miatt van 

            if (MessageBox.Show("Biztos, hogy hozzáadja az új terméket?", "Új termék hozzáadása", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                string forras = kepneve;
                FileInfo info = new FileInfo(forras);
                cel = @"upload_images/"+ $"{randomszam}"+ System.IO.Path.GetFileName(forras);
                info.CopyTo(cel);
                etlap_elemei_feltolt();
                if (MessageBox.Show("A termék feltöltve!", "Új termék hozzáadása", MessageBoxButton.OK, MessageBoxImage.Information) == MessageBoxResult.OK)
                {
                    textBox_termekneve.Text = "";
                    textBox_termekara.Text = "";
                    textBox_termekleiras.Text = "";
                    textBox_termekneve.Focus();
                }

            }
            image_kivalasztott.Source = null;  //A kép feltöltése után és másolása után a image_kivalasztott legyen üres!
        }

        private void kep_talloz_Click(object sender, RoutedEventArgs e) //Kép Kiválasztása
        {
            kep_kivalaszt();
        }

        private void button_alaphelyzet_Click(object sender, RoutedEventArgs e) //Alapértelmezetten üresre állítja a mezőket!
        {
            textBox_termekneve.Text = "";
            textBox_termekara.Text = "";
            textBox_termekleiras.Text = "";
            image_kivalasztott.Source = null;
        }
    }
}
