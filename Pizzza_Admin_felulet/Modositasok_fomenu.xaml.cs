using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace Pizzza_Admin_felulet
{
    /// <summary>
    /// Interaction logic for Modositasok_fomenu.xaml
    /// </summary>
    public partial class Modositasok_fomenu : Window
    {
        string kapcsolat = (App.Current as App).beconfig(); //SQL Elérése a config fájlból!
        public Modositasok_fomenu()
        {
            InitializeComponent();
            nyilvantartas_lekerdez_napok();
            //if (listBox_napok.SelectedIndex ==0)
            //{
            //    nyilvantartas_lekerdez_Hetfo();
            //}

            nyilvantartas_lekerdez_hetfo();
            nyilvantartas_lekerdez_kedd();
            nyilvantartas_lekerdez_szerda();
            nyilvantartas_lekerdez_csutortok();
            nyilvantartas_lekerdez_pentek();
            nyilvantartas_lekerdez_szombat();
            nyilvantartas_lekerdez_vasarnap(); 
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e) //Modositasok_fomenu ablakának mozgatása
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();

            }
        }


        // Gombok Elrejtése //Gombok Meghívása // Gombok Tiltása
        void telefon_elrejt_old()   //Telefon felületeihez tartozo elemek elrejtése/Gombok engedélyezése
        {
            label_telefonszam.Visibility = Visibility.Hidden;
            label_ujtelefonszam.Visibility = Visibility.Hidden;
            label_meglevotelefonszam.Visibility = Visibility.Hidden;
            textBox_meglevotelszam.Visibility = Visibility.Hidden;
            textBox_ujtelefonszam.Visibility = Visibility.Hidden;
            t_szam_keret_kicsi.Visibility = Visibility.Hidden;
            tszam_keret.Visibility = Visibility.Hidden;
            button_tszam_becsuk.Visibility = Visibility.Hidden;
            button_modosit.Visibility = Visibility.Hidden;
            fedes.Visibility = Visibility.Hidden;
            button_telefonszam.IsEnabled = true;
            button_email.IsEnabled = true;
            button_cim.IsEnabled = true;
            button_rolunk.IsEnabled = true;
            button_akciok.IsEnabled = true;
            button_nyitvatartas.IsEnabled = true;
            button_informaciok.IsEnabled = true;
            button_aszf.IsEnabled = true;
            button_biztonsagi_beallitasok.IsEnabled = true;
            button_felhasznalo_letrehozasa.IsEnabled = true;
            button_fomenube.IsEnabled = true;

        }
        void telefon_megjelenit_tilt() //Telefon felületeihez tartozo elemek megjelenítése/Gombok tiltása
        {
            label_telefonszam.Visibility = Visibility.Visible;
            label_ujtelefonszam.Visibility = Visibility.Visible;
            label_meglevotelefonszam.Visibility = Visibility.Visible;
            textBox_meglevotelszam.Visibility = Visibility.Visible;
            textBox_ujtelefonszam.Visibility = Visibility.Visible;
            t_szam_keret_kicsi.Visibility = Visibility.Visible;
            tszam_keret.Visibility = Visibility.Visible;
            button_tszam_becsuk.Visibility = Visibility.Visible;
            button_modosit.Visibility= Visibility.Visible;
            fedes.Visibility = Visibility.Visible;
            button_telefonszam.IsEnabled = false;
            button_email.IsEnabled = false;
            button_cim.IsEnabled = false;
            button_rolunk.IsEnabled = false;
            button_akciok.IsEnabled = false;
            button_nyitvatartas.IsEnabled = false;
            button_informaciok.IsEnabled = false;
            button_aszf.IsEnabled = false;
            button_biztonsagi_beallitasok.IsEnabled = false;
            button_felhasznalo_letrehozasa.IsEnabled = false;
            button_fomenube.IsEnabled = false;

            textBox_ujtelefonszam.Focus();

        }
        void email_elrejt_old() //Email felületeihez tartozo elemek elrejtése/Gombok Engedélyezése
        {
            email_keret.Visibility = Visibility.Hidden;
            email_keret_kicsi.Visibility = Visibility.Hidden;
            label_email.Visibility = Visibility.Hidden;
            label_meglevotelefonszam.Visibility = Visibility.Hidden;
            label_meglevoemail.Visibility = Visibility.Hidden;
            label_ujemail.Visibility = Visibility.Hidden;
            textBox_email.Visibility = Visibility.Hidden;
            textBox_ujemail.Visibility = Visibility.Hidden;
            tszam_keret.Visibility = Visibility.Hidden;
            button_e_modosit.Visibility = Visibility.Hidden;
            button_email_becsuk.Visibility = Visibility.Hidden;
            fedes.Visibility = Visibility.Hidden;
            button_telefonszam.IsEnabled = true;
            button_email.IsEnabled = true;
            button_cim.IsEnabled = true;
            button_rolunk.IsEnabled = true;
            button_akciok.IsEnabled = true;
            button_nyitvatartas.IsEnabled = true;
            button_informaciok.IsEnabled = true;
            button_aszf.IsEnabled = true;
            button_biztonsagi_beallitasok.IsEnabled = true;
            button_felhasznalo_letrehozasa.IsEnabled = true;
            button_fomenube.IsEnabled = true;
        }   
        void email_megjelenit_tilt() //Email felületeihez tartozo elemek megjelenítése/Gombok tiltása
        {
            email_keret.Visibility = Visibility.Visible;
            email_keret_kicsi.Visibility = Visibility.Visible;
            label_email.Visibility = Visibility.Visible;
            label_meglevotelefonszam.Visibility = Visibility.Visible;
            label_ujemail.Visibility = Visibility.Visible;
            label_meglevoemail.Visibility = Visibility.Visible;
            textBox_email.Visibility = Visibility.Visible;
            textBox_ujemail.Visibility = Visibility.Visible;
            tszam_keret.Visibility = Visibility.Visible;
            button_e_modosit.Visibility = Visibility.Visible;
            button_email_becsuk.Visibility = Visibility.Visible;
            fedes.Visibility = Visibility.Visible;
            button_telefonszam.IsEnabled = false;
            button_email.IsEnabled = false;
            button_cim.IsEnabled = false;
            button_rolunk.IsEnabled = false;
            button_akciok.IsEnabled = false;
            button_nyitvatartas.IsEnabled = false;
            button_informaciok.IsEnabled = false;
            button_aszf.IsEnabled = false;
            button_biztonsagi_beallitasok.IsEnabled = false;
            button_felhasznalo_letrehozasa.IsEnabled = false;
            button_fomenube.IsEnabled = false;

            textBox_ujemail.Focus();
        }
        void cim_elrejt_old() //Cím felületeihez tartozo elemek elrejtése/Gombok Engedélyezése
        {
            label_cim.Visibility = Visibility.Hidden;
            label_ujcim.Visibility = Visibility.Hidden;
            label_meglevocim.Visibility = Visibility.Hidden;
            textBox_cim.Visibility = Visibility.Hidden;
            textBox_ujcim.Visibility = Visibility.Hidden;
            cim_keret_kicsi.Visibility = Visibility.Hidden;
            cim_keret.Visibility = Visibility.Hidden;
            button_cim_becsuk.Visibility = Visibility.Hidden;
            button_cim_modosit.Visibility = Visibility.Hidden;
            fedes.Visibility = Visibility.Hidden;
            button_telefonszam.IsEnabled = true;
            button_email.IsEnabled = true;
            button_cim.IsEnabled = true;
            button_rolunk.IsEnabled = true;
            button_akciok.IsEnabled = true;
            button_nyitvatartas.IsEnabled = true;
            button_informaciok.IsEnabled = true;
            button_aszf.IsEnabled = true;
            button_biztonsagi_beallitasok.IsEnabled = true;
            button_felhasznalo_letrehozasa.IsEnabled = true;
            button_fomenube.IsEnabled = true;
        } 
        void cim_megjelenit_tilt() //Cím felületeihez tartozo elemek megjelenítése/Gombok tiltása
        {
            label_cim.Visibility = Visibility.Visible;
            label_ujcim.Visibility = Visibility.Visible;
            label_meglevocim.Visibility = Visibility.Visible;
            textBox_cim.Visibility = Visibility.Visible;
            textBox_ujcim.Visibility = Visibility.Visible;
            cim_keret_kicsi.Visibility = Visibility.Visible;
            cim_keret.Visibility = Visibility.Visible;
            button_cim_becsuk.Visibility = Visibility.Visible;
            button_cim_modosit.Visibility = Visibility.Visible;
            fedes.Visibility = Visibility.Visible;
            button_telefonszam.IsEnabled = false;
            button_email.IsEnabled = false;
            button_cim.IsEnabled = false;
            button_rolunk.IsEnabled = false;
            button_akciok.IsEnabled = false;
            button_nyitvatartas.IsEnabled = false;
            button_informaciok.IsEnabled = false;
            button_aszf.IsEnabled = false;
            button_biztonsagi_beallitasok.IsEnabled = false;
            button_felhasznalo_letrehozasa.IsEnabled = false;
            button_fomenube.IsEnabled = false;

            textBox_ujcim.Focus();
        }   
        void rolunk_elrejt_old()    //Rólunk felületeihez tartozo elemek elrejtése/Gombok Engedélyezése
        {

            label_rolunk.Visibility = Visibility.Hidden;
            label_jelenlegikiiras_rolunk.Visibility = Visibility.Hidden;
            label_ujkiiras_rolunk.Visibility = Visibility.Hidden;
            textBox_rolunk.Visibility = Visibility.Hidden;
            textBox_ujrolunk.Visibility = Visibility.Hidden;
            rolunk_keret_kicsi.Visibility = Visibility.Hidden;
            rolunk_keret.Visibility = Visibility.Hidden;
            button_rolunk_becsuk.Visibility = Visibility.Hidden;
            button_rolunk_modosit.Visibility = Visibility.Hidden;
            fedes.Visibility = Visibility.Hidden;
            button_telefonszam.IsEnabled = true;
            button_email.IsEnabled = true;
            button_cim.IsEnabled = true;
            button_rolunk.IsEnabled = true;
            button_akciok.IsEnabled = true;
            button_nyitvatartas.IsEnabled = true;
            button_informaciok.IsEnabled = true;
            button_aszf.IsEnabled = true;
            button_biztonsagi_beallitasok.IsEnabled = true;
            button_felhasznalo_letrehozasa.IsEnabled = true;
            button_fomenube.IsEnabled = true;
        }
        void rolunk_megjelenit_tilt() //Rólunk felületeihez tartozo elemek megjelenítése/Gombok tiltása
        {
            label_rolunk.Visibility = Visibility.Visible;
            label_jelenlegikiiras_rolunk.Visibility = Visibility.Visible;
            label_ujkiiras_rolunk.Visibility = Visibility.Visible;
            textBox_rolunk.Visibility = Visibility.Visible;
            textBox_ujrolunk.Visibility = Visibility.Visible;
            rolunk_keret_kicsi.Visibility = Visibility.Visible;
            rolunk_keret.Visibility = Visibility.Visible;
            button_rolunk_becsuk.Visibility = Visibility.Visible;
            button_rolunk_modosit.Visibility = Visibility.Visible;
            fedes.Visibility = Visibility.Visible;
            button_telefonszam.IsEnabled = false;
            button_email.IsEnabled = false;
            button_cim.IsEnabled = false;
            button_rolunk.IsEnabled = false;
            button_akciok.IsEnabled = false;
            button_nyitvatartas.IsEnabled = false;
            button_informaciok.IsEnabled = false;
            button_aszf.IsEnabled = false;
            button_biztonsagi_beallitasok.IsEnabled = false;
            button_felhasznalo_letrehozasa.IsEnabled = false;
            button_fomenube.IsEnabled = false;

            textBox_ujrolunk.Focus();
        }
        void felhasznalo_letrehozasa_elrejt_old() //A felhasznalo_letrehozasa felületeihez tartozo elemek elrejtése/Gombok Engedélyezése
        {
            fnev_keret.Visibility = Visibility.Hidden;
            fnev_keret_kicsi.Visibility = Visibility.Hidden;
            label_fnev.Visibility = Visibility.Hidden;
            label_felh_megadasa.Visibility = Visibility.Hidden;
            label_jelszo.Visibility = Visibility.Hidden;
            label_jelszo_ismet.Visibility = Visibility.Hidden;
            label_email_megadasa.Visibility = Visibility.Hidden;
            textBox_fnev.Visibility = Visibility.Hidden;
            passwordBox_jelszo.Visibility = Visibility.Hidden;
            passwordBox_jelszo_ismet.Visibility = Visibility.Hidden;
            textBox_email_megadasa.Visibility = Visibility.Hidden;
            button_felh_modosit.Visibility = Visibility.Hidden;
            button_felh_becsuk.Visibility = Visibility.Hidden;
            fedes.Visibility = Visibility.Hidden;
            button_telefonszam.IsEnabled = true;
            button_email.IsEnabled = true;
            button_cim.IsEnabled = true;
            button_rolunk.IsEnabled = true;
            button_akciok.IsEnabled = true;
            button_nyitvatartas.IsEnabled = true;
            button_informaciok.IsEnabled = true;
            button_aszf.IsEnabled = true;
            button_biztonsagi_beallitasok.IsEnabled = true;
            button_felhasznalo_letrehozasa.IsEnabled = true;
            button_fomenube.IsEnabled = true;
        }
        void felhasznalo_letrehozasa_megjelenit_tilt() //A felhasznalo_letrehozasa felületeihez tartozo elemek megjelenítése/Gombok tiltása.
        {
            fnev_keret.Visibility = Visibility.Visible;
            fnev_keret_kicsi.Visibility = Visibility.Visible;
            label_fnev.Visibility = Visibility.Visible;
            label_felh_megadasa.Visibility = Visibility.Visible;
            label_jelszo.Visibility = Visibility.Visible;
            label_jelszo_ismet.Visibility = Visibility.Visible;
            label_email_megadasa.Visibility = Visibility.Visible;
            textBox_fnev.Visibility = Visibility.Visible;
            passwordBox_jelszo.Visibility = Visibility.Visible;
            passwordBox_jelszo_ismet.Visibility = Visibility.Visible;
            textBox_email_megadasa.Visibility = Visibility.Visible;
            button_felh_modosit.Visibility = Visibility.Visible;
            button_felh_becsuk.Visibility = Visibility.Visible;
            fedes.Visibility = Visibility.Visible;
            button_telefonszam.IsEnabled = false;
            button_email.IsEnabled = false;
            button_cim.IsEnabled = false;
            button_rolunk.IsEnabled = false;
            button_akciok.IsEnabled = false;
            button_nyitvatartas.IsEnabled = false;
            button_informaciok.IsEnabled = false;
            button_aszf.IsEnabled = false;
            button_biztonsagi_beallitasok.IsEnabled = false;
            button_felhasznalo_letrehozasa.IsEnabled = false;
            button_fomenube.IsEnabled = false;


        }
        void akciok_elrejt_old() //Akciók felületeihez tartozo elemek elrejtése/Gombok Engedélyezése
        {
            
            label_akciok.Visibility = Visibility.Hidden;
            label_jelenlegiakcio.Visibility = Visibility.Hidden;
            label_ujkiiras_akciok.Visibility = Visibility.Hidden;
            textBox_akciok.Visibility = Visibility.Hidden;
            textBox_ujakciok.Visibility = Visibility.Hidden;
            akciok_keret_kicsi.Visibility = Visibility.Hidden;
            akciok_keret.Visibility = Visibility.Hidden;
            button_akciok_becsuk.Visibility = Visibility.Hidden;
            button_akciok_modosit.Visibility = Visibility.Hidden;
            fedes.Visibility = Visibility.Hidden;

            button_telefonszam.IsEnabled = true;
            button_email.IsEnabled = true;
            button_cim.IsEnabled = true;
            button_rolunk.IsEnabled = true;
            button_akciok.IsEnabled = true;
            button_nyitvatartas.IsEnabled = true;
            button_informaciok.IsEnabled = true;
            button_aszf.IsEnabled = true;
            button_biztonsagi_beallitasok.IsEnabled = true;
            button_felhasznalo_letrehozasa.IsEnabled = true;
            button_fomenube.IsEnabled = true;
        }
        void akciok_megjelenit_tilt() //Akciók felületeihez tartozo elemek megjelenítése/Gombok tiltása
        {
            label_akciok.Visibility = Visibility.Visible;
            label_jelenlegiakcio.Visibility = Visibility.Visible;
            label_ujkiiras_akciok.Visibility = Visibility.Visible;
            textBox_akciok.Visibility = Visibility.Visible;
            textBox_ujakciok.Visibility = Visibility.Visible;
            akciok_keret_kicsi.Visibility = Visibility.Visible;
            akciok_keret.Visibility = Visibility.Visible;
            button_akciok_becsuk.Visibility = Visibility.Visible;
            button_akciok_modosit.Visibility = Visibility.Visible;
            fedes.Visibility = Visibility.Visible;

            button_telefonszam.IsEnabled = false;   
            button_email.IsEnabled = false;              
            button_cim.IsEnabled = false;
            button_rolunk.IsEnabled = false;
            button_akciok.IsEnabled = false;
            button_nyitvatartas.IsEnabled = false;
            button_informaciok.IsEnabled = false;
            button_aszf.IsEnabled = false;
            button_biztonsagi_beallitasok.IsEnabled = false;
            button_felhasznalo_letrehozasa.IsEnabled = false;
            button_fomenube.IsEnabled = false;

            textBox_ujakciok.Focus();
        }
        void nyitvatartas_elrejt_old() //Nyitvatartás felületeihez tartozo elemek elrejtése/Gombok Engedélyezése
        {

            nyitvatartas_keret.Visibility = Visibility.Hidden;
            nyitvatartas_keret_kicsi.Visibility = Visibility.Hidden;
            label_nyitvatartas.Visibility = Visibility.Hidden;
            label_jelenleginyitvatartas.Visibility = Visibility.Hidden;
            label_ujkiiras_nyitvatartas.Visibility = Visibility.Hidden;
            button_nyitvatartas_modosit.Visibility = Visibility.Hidden;
            button_nyitvatartas_megsem.Visibility = Visibility.Hidden;
            button_nyitvatartas_becsuk.Visibility = Visibility.Hidden;
            label_nap.Visibility = Visibility.Hidden;
            label_idoszak.Visibility = Visibility.Hidden;
            label_ora_tol.Visibility = Visibility.Hidden;
            label_ora_ig.Visibility = Visibility.Hidden;
            label_perc_tol.Visibility = Visibility.Hidden;
            label_perc_ig.Visibility = Visibility.Hidden;
            border_nyitvatartas.Visibility = Visibility.Hidden;
            border_nyitvatartas2.Visibility = Visibility.Hidden;
            listBox_napok.Visibility = Visibility.Hidden;
            textBox_oratol.Visibility = Visibility.Hidden;
            textBox_oraig.Visibility = Visibility.Hidden;
            textBox_perctol.Visibility = Visibility.Hidden;
            textBox_percig.Visibility = Visibility.Hidden;
            label_hetfo.Visibility = Visibility.Hidden;
            label_kedd.Visibility = Visibility.Hidden;
            label_szerda.Visibility = Visibility.Hidden;
            label_csutortok.Visibility = Visibility.Hidden;
            label_pentek.Visibility = Visibility.Hidden;
            label_szombat.Visibility = Visibility.Hidden;
            label_vasarnap.Visibility = Visibility.Hidden;
            textbox_hetfo_mettolora.Visibility = Visibility.Hidden;
            textbox_kedd_mettolora.Visibility = Visibility.Hidden;
            textbox_szerda_mettolora.Visibility = Visibility.Hidden;
            textbox_csutortok_mettolora.Visibility = Visibility.Hidden;
            textbox_pentek_mettolora.Visibility = Visibility.Hidden;
            textbox_szombat_mettolora.Visibility = Visibility.Hidden;
            textbox_vasarnap_mettolora.Visibility = Visibility.Hidden;
            label_hetfo_kettospont.Visibility = Visibility.Hidden;
            label_kedd_kettospont.Visibility = Visibility.Hidden;
            label_szerda_kettospont.Visibility = Visibility.Hidden;
            label_csutortok_kettospont.Visibility = Visibility.Hidden;
            label_pentek_kettospont.Visibility = Visibility.Hidden;
            label_szombat_kettospont.Visibility = Visibility.Hidden;
            label_vasarnap_kettospont.Visibility = Visibility.Hidden;
            textbox_hetfo_mettolperc.Visibility = Visibility.Hidden;
            textbox_kedd_mettolperc.Visibility = Visibility.Hidden;
            textbox_szerda_mettolperc.Visibility = Visibility.Hidden;
            textbox_csutortok_mettolperc.Visibility = Visibility.Hidden;
            textbox_pentek_mettolperc.Visibility = Visibility.Hidden;
            textbox_szombat_mettolperc.Visibility = Visibility.Hidden;
            textbox_vasarnap_mettolperc.Visibility = Visibility.Hidden;
            label_hetfo_kotojel.Visibility = Visibility.Hidden;
            label_kedd_kotojel.Visibility = Visibility.Hidden;
            label_szerda_kotojel.Visibility = Visibility.Hidden;
            label_csutortok_kotojel.Visibility = Visibility.Hidden;
            label_pentek_kotojel.Visibility = Visibility.Hidden;
            label_szombat_kotojel.Visibility = Visibility.Hidden;
            label_vasarnap_kotojel.Visibility = Visibility.Hidden;
            textbox_hetfo_meddigora.Visibility = Visibility.Hidden;
            textbox_kedd_meddigora.Visibility = Visibility.Hidden;
            textbox_szerda_meddigora.Visibility = Visibility.Hidden;
            textbox_csutortok_meddigora.Visibility = Visibility.Hidden;
            textbox_pentek_meddigora.Visibility = Visibility.Hidden;
            textbox_szombat_meddigora.Visibility = Visibility.Hidden;
            textbox_vasarnap_meddigora.Visibility = Visibility.Hidden;
            label_hetfo_kettospont2.Visibility = Visibility.Hidden;
            label_kedd_kettospont2.Visibility = Visibility.Hidden;
            label_szerda_kettospont2.Visibility = Visibility.Hidden;
            label_csutortok_kettospont2.Visibility = Visibility.Hidden;
            label_pentek_kettospont2.Visibility = Visibility.Hidden;
            label_szombat_kettospont2.Visibility = Visibility.Hidden;
            label_vasarnap_kettospont2.Visibility = Visibility.Hidden;
            textbox_hetfo_meddigperc.Visibility = Visibility.Hidden;
            textbox_kedd_meddigperc.Visibility = Visibility.Hidden;
            textbox_szerda_meddigperc.Visibility = Visibility.Hidden;
            textbox_csutortok_meddigperc.Visibility = Visibility.Hidden;
            textbox_pentek_meddigperc.Visibility = Visibility.Hidden;
            textbox_szombat_meddigperc.Visibility = Visibility.Hidden;
            textbox_vasarnap_meddigperc.Visibility = Visibility.Hidden;
            button_nyitvatartas_idoszak_uresre.Visibility = Visibility.Hidden;



            fedes.Visibility = Visibility.Hidden;

            
            button_telefonszam.IsEnabled = true;
            button_email.IsEnabled = true;
            button_cim.IsEnabled = true;
            button_rolunk.IsEnabled = true;
            button_akciok.IsEnabled = true;
            button_nyitvatartas.IsEnabled = true;
            button_informaciok.IsEnabled = true;
            button_aszf.IsEnabled = true;
            button_biztonsagi_beallitasok.IsEnabled = true;
            button_felhasznalo_letrehozasa.IsEnabled = true;
            button_fomenube.IsEnabled = true;
        }
        void nyitvatartas_megjelenit_tilt() //Nyitvatartás felületeihez tartozo elemek megjelenítése/Gombok tiltása
        {
            nyitvatartas_keret.Visibility = Visibility.Visible;
            nyitvatartas_keret_kicsi.Visibility = Visibility.Visible;
            label_nyitvatartas.Visibility = Visibility.Visible;
            label_jelenleginyitvatartas.Visibility = Visibility.Visible;
            label_ujkiiras_nyitvatartas.Visibility = Visibility.Visible;
            button_nyitvatartas_modosit.Visibility = Visibility.Visible;
            button_nyitvatartas_megsem.Visibility = Visibility.Visible;
            button_nyitvatartas_becsuk.Visibility = Visibility.Visible;
            label_nap.Visibility = Visibility.Visible;
            label_idoszak.Visibility = Visibility.Visible;
            label_ora_tol.Visibility = Visibility.Visible;
            label_ora_ig.Visibility = Visibility.Visible;
            label_perc_tol.Visibility = Visibility.Visible;
            label_perc_ig.Visibility = Visibility.Visible;
            border_nyitvatartas.Visibility = Visibility.Visible;
            border_nyitvatartas2.Visibility = Visibility.Visible;
            listBox_napok.Visibility = Visibility.Visible;
            textBox_oratol.Visibility = Visibility.Visible;
            textBox_oraig.Visibility = Visibility.Visible;
            textBox_perctol.Visibility = Visibility.Visible;
            textBox_percig.Visibility = Visibility.Visible;
            label_hetfo.Visibility = Visibility.Visible;
            label_kedd.Visibility = Visibility.Visible;
            label_szerda.Visibility = Visibility.Visible;
            label_csutortok.Visibility = Visibility.Visible;
            label_pentek.Visibility = Visibility.Visible;
            label_szombat.Visibility = Visibility.Visible;
            label_vasarnap.Visibility = Visibility.Visible;
            textbox_hetfo_mettolora.Visibility = Visibility.Visible;
            textbox_kedd_mettolora.Visibility = Visibility.Visible;
            textbox_szerda_mettolora.Visibility = Visibility.Visible;
            textbox_csutortok_mettolora.Visibility = Visibility.Visible;
            textbox_pentek_mettolora.Visibility = Visibility.Visible;
            textbox_szombat_mettolora.Visibility = Visibility.Visible;
            textbox_vasarnap_mettolora.Visibility = Visibility.Visible;
            label_hetfo_kettospont.Visibility = Visibility.Visible;
            label_kedd_kettospont.Visibility = Visibility.Visible;
            label_szerda_kettospont.Visibility = Visibility.Visible;
            label_csutortok_kettospont.Visibility = Visibility.Visible;
            label_pentek_kettospont.Visibility = Visibility.Visible;
            label_szombat_kettospont.Visibility = Visibility.Visible;
            label_vasarnap_kettospont.Visibility = Visibility.Visible;
            textbox_hetfo_mettolperc.Visibility = Visibility.Visible;
            textbox_kedd_mettolperc.Visibility = Visibility.Visible;
            textbox_szerda_mettolperc.Visibility = Visibility.Visible;
            textbox_csutortok_mettolperc.Visibility = Visibility.Visible;
            textbox_pentek_mettolperc.Visibility = Visibility.Visible;
            textbox_szombat_mettolperc.Visibility = Visibility.Visible;
            textbox_vasarnap_mettolperc.Visibility = Visibility.Visible;
            label_hetfo_kotojel.Visibility = Visibility.Visible;
            label_kedd_kotojel.Visibility = Visibility.Visible;
            label_szerda_kotojel.Visibility = Visibility.Visible;
            label_csutortok_kotojel.Visibility = Visibility.Visible;
            label_pentek_kotojel.Visibility = Visibility.Visible;
            label_szombat_kotojel.Visibility = Visibility.Visible;
            label_vasarnap_kotojel.Visibility = Visibility.Visible;
            textbox_hetfo_meddigora.Visibility = Visibility.Visible;
            textbox_kedd_meddigora.Visibility = Visibility.Visible;
            textbox_szerda_meddigora.Visibility = Visibility.Visible;
            textbox_csutortok_meddigora.Visibility = Visibility.Visible;
            textbox_pentek_meddigora.Visibility = Visibility.Visible;
            textbox_szombat_meddigora.Visibility = Visibility.Visible;
            textbox_vasarnap_meddigora.Visibility = Visibility.Visible;
            label_hetfo_kettospont2.Visibility = Visibility.Visible;
            label_kedd_kettospont2.Visibility = Visibility.Visible;
            label_szerda_kettospont2.Visibility = Visibility.Visible;
            label_csutortok_kettospont2.Visibility = Visibility.Visible;
            label_pentek_kettospont2.Visibility = Visibility.Visible;
            label_szombat_kettospont2.Visibility = Visibility.Visible;
            label_vasarnap_kettospont2.Visibility = Visibility.Visible;
            textbox_hetfo_meddigperc.Visibility = Visibility.Visible;
            textbox_kedd_meddigperc.Visibility = Visibility.Visible;
            textbox_szerda_meddigperc.Visibility = Visibility.Visible;
            textbox_csutortok_meddigperc.Visibility = Visibility.Visible;
            textbox_pentek_meddigperc.Visibility = Visibility.Visible;
            textbox_szombat_meddigperc.Visibility = Visibility.Visible;
            textbox_vasarnap_meddigperc.Visibility = Visibility.Visible;
            button_nyitvatartas_idoszak_uresre.Visibility = Visibility.Visible;

            fedes.Visibility = Visibility.Visible;

            button_telefonszam.IsEnabled = false;
            button_email.IsEnabled = false;
            button_cim.IsEnabled = false;
            button_rolunk.IsEnabled = false;
            button_akciok.IsEnabled = false;
            button_nyitvatartas.IsEnabled = false;
            button_informaciok.IsEnabled = false;
            button_aszf.IsEnabled = false;
            button_biztonsagi_beallitasok.IsEnabled = false;
            button_felhasznalo_letrehozasa.IsEnabled = false;
            button_fomenube.IsEnabled = false;
        }
        void informaciok_elrejt_old() //Információk felületeihez tartozo elemek elrejtése/Gombok Engedélyezése.
        {

            label_informacio.Visibility = Visibility.Hidden;
            label_jelenlegiinformacio.Visibility = Visibility.Hidden;
            label_ujkiiras_infromacio.Visibility = Visibility.Hidden;
            textBox_informacio.Visibility = Visibility.Hidden;
            textBox_ujinfromacio.Visibility = Visibility.Hidden;
            informacio_keret_kicsi.Visibility = Visibility.Hidden;
            informacio_keret.Visibility = Visibility.Hidden;
            button_informacio_becsuk.Visibility = Visibility.Hidden;
            button_informacio_modosit.Visibility = Visibility.Hidden;
            fedes.Visibility = Visibility.Hidden;

            button_telefonszam.IsEnabled = true;
            button_email.IsEnabled = true;
            button_cim.IsEnabled = true;
            button_rolunk.IsEnabled = true;
            button_akciok.IsEnabled = true;
            button_nyitvatartas.IsEnabled = true;
            button_informaciok.IsEnabled = true;
            button_aszf.IsEnabled = true;
            button_biztonsagi_beallitasok.IsEnabled = true;
            button_felhasznalo_letrehozasa.IsEnabled = true;
            button_fomenube.IsEnabled = true;
        }
        void informaciok_megjelenit_tilt()  //Információk felületeihez tartozo elemek megjelenítése/Gombok tiltása
        {
            label_informacio.Visibility = Visibility.Visible;
            label_jelenlegiinformacio.Visibility = Visibility.Visible;
            label_ujkiiras_infromacio.Visibility = Visibility.Visible;
            textBox_informacio.Visibility = Visibility.Visible;
            textBox_ujinfromacio.Visibility = Visibility.Visible;
            informacio_keret_kicsi.Visibility = Visibility.Visible;
            informacio_keret.Visibility = Visibility.Visible;
            button_informacio_becsuk.Visibility = Visibility.Visible;
            button_informacio_modosit.Visibility = Visibility.Visible;
            fedes.Visibility = Visibility.Visible;

            button_telefonszam.IsEnabled = false;
            button_email.IsEnabled = false;
            button_cim.IsEnabled = false;
            button_rolunk.IsEnabled = false;
            button_akciok.IsEnabled = false;
            button_nyitvatartas.IsEnabled = false;
            button_informaciok.IsEnabled = false;
            button_aszf.IsEnabled = false;
            button_biztonsagi_beallitasok.IsEnabled = false;
            button_felhasznalo_letrehozasa.IsEnabled = false;
            button_fomenube.IsEnabled = false;

            textBox_ujinfromacio.Focus();
        } 
        void aszf_elrejt_old() //ASZF felületeihez tartozo elemek elrejtése/Gombok Engedélyezése.
        {

            label_aszf.Visibility = Visibility.Hidden;
            label_jelenlegiaszf.Visibility = Visibility.Hidden;
            label_ujkiiras_aszf.Visibility = Visibility.Hidden;
            textBox_aszf.Visibility = Visibility.Hidden;
            textBox_ujaszf.Visibility = Visibility.Hidden;
            aszf_keret_kicsi.Visibility = Visibility.Hidden;
            aszf_keret.Visibility = Visibility.Hidden;
            button_aszf_becsuk.Visibility = Visibility.Hidden;
            button_aszf_modosit.Visibility = Visibility.Hidden;
            fedes.Visibility = Visibility.Hidden;
            button_telefonszam.IsEnabled = true;
            button_email.IsEnabled = true;
            button_cim.IsEnabled = true;
            button_rolunk.IsEnabled = true;
            button_akciok.IsEnabled = true;
            button_nyitvatartas.IsEnabled = true;
            button_informaciok.IsEnabled = true;
            button_aszf.IsEnabled = true;
            button_biztonsagi_beallitasok.IsEnabled = true;
            button_felhasznalo_letrehozasa.IsEnabled = true;
            button_fomenube.IsEnabled = true;
        }
        void aszf_megjelenit_tilt() //ASZF felületeihez tartozo elemek megjelenítése/Gombok tiltása
        {
            label_aszf.Visibility = Visibility.Visible;
            label_jelenlegiaszf.Visibility = Visibility.Visible;
            label_ujkiiras_aszf.Visibility = Visibility.Visible;
            textBox_aszf.Visibility = Visibility.Visible;
            textBox_ujaszf.Visibility = Visibility.Visible;
            aszf_keret_kicsi.Visibility = Visibility.Visible;
            aszf_keret.Visibility = Visibility.Visible;
            button_aszf_becsuk.Visibility = Visibility.Visible;
            button_aszf_modosit.Visibility = Visibility.Visible;
            fedes.Visibility = Visibility.Visible;
            button_telefonszam.IsEnabled = false;
            button_email.IsEnabled = false;
            button_cim.IsEnabled = false;
            button_rolunk.IsEnabled = false;
            button_akciok.IsEnabled = false;
            button_nyitvatartas.IsEnabled = false;
            button_informaciok.IsEnabled = false;
            button_aszf.IsEnabled = false;
            button_biztonsagi_beallitasok.IsEnabled = false;
            button_felhasznalo_letrehozasa.IsEnabled = false;
            button_fomenube.IsEnabled = false;

            textBox_ujaszf.Focus();
        }
        void biztonsagi_beallitasok_elrejt_old()    //Biztonsági Beállítások felületeihez tartozo elemek elrejtése/Gombok Engedélyezése.
        {
            biztb_keret.Visibility = Visibility.Hidden;
            biztb_keret_kicsi.Visibility = Visibility.Hidden;
            label_fnev_focim.Visibility = Visibility.Hidden;
            label_fnev_jelenlegi.Visibility = Visibility.Hidden;
            label_email_jelenlegi.Visibility = Visibility.Hidden;
            label_jelszo_jelenlegi.Visibility = Visibility.Hidden;
            label_jelszo_ujjelszo.Visibility = Visibility.Hidden;
            label_jelszo_ujjelszo_ismet.Visibility = Visibility.Hidden;
            label_email_ujemail.Visibility = Visibility.Hidden;
            label_email_ujemail_ismet.Visibility = Visibility.Hidden;
            label_fnev_kiiras.Visibility = Visibility.Hidden;
            label_email_kiiras.Visibility = Visibility.Hidden;
            passwordBox_jelszo_jelenlegi.Visibility = Visibility.Hidden;
            passwordBox_jelszo_ujjelszo.Visibility = Visibility.Hidden;
            passwordBox_jelszo_ujjelszo_ismet.Visibility = Visibility.Hidden;
            textBox_email_ujemail.Visibility = Visibility.Hidden;
            textBox_email_ujemail_ismet.Visibility = Visibility.Hidden;
            button_biztbeal_modosit.Visibility = Visibility.Hidden;
            button_biztb_becsuk.Visibility = Visibility.Hidden;
            fedes.Visibility = Visibility.Hidden;

            button_telefonszam.IsEnabled = true;
            button_email.IsEnabled = true;
            button_cim.IsEnabled = true;
            button_rolunk.IsEnabled = true;
            button_akciok.IsEnabled = true;
            button_nyitvatartas.IsEnabled = true;
            button_informaciok.IsEnabled = true;
            button_aszf.IsEnabled = true;
            button_biztonsagi_beallitasok.IsEnabled = true;
            button_felhasznalo_letrehozasa.IsEnabled = true;
            button_fomenube.IsEnabled = true;
        }
        void biztonsagi_beallitasok_megjelenit_tilt() //Biztonsági Beállítások felületeihez tartozo elemek megjelenítése/Gombok tiltása
        {
            biztb_keret.Visibility = Visibility.Visible;
            biztb_keret_kicsi.Visibility = Visibility.Visible;
            label_fnev_focim.Visibility = Visibility.Visible;
            label_fnev_jelenlegi.Visibility = Visibility.Visible;
            label_email_jelenlegi.Visibility = Visibility.Visible;
            label_jelszo_jelenlegi.Visibility = Visibility.Visible;
            label_jelszo_ujjelszo.Visibility = Visibility.Visible;
            label_jelszo_ujjelszo_ismet.Visibility = Visibility.Visible;
            label_email_ujemail.Visibility = Visibility.Visible;
            label_email_ujemail_ismet.Visibility = Visibility.Visible;
            label_fnev_kiiras.Visibility = Visibility.Visible;
            label_email_kiiras.Visibility = Visibility.Visible;
            passwordBox_jelszo_jelenlegi.Visibility = Visibility.Visible;
            passwordBox_jelszo_ujjelszo.Visibility = Visibility.Visible;
            passwordBox_jelszo_ujjelszo_ismet.Visibility = Visibility.Visible;
            textBox_email_ujemail.Visibility = Visibility.Visible;
            textBox_email_ujemail_ismet.Visibility = Visibility.Visible;
            button_biztbeal_modosit.Visibility = Visibility.Visible;
            button_biztb_becsuk.Visibility = Visibility.Visible;
            fedes.Visibility = Visibility.Visible;

            button_telefonszam.IsEnabled = false;
            button_email.IsEnabled = false;
            button_cim.IsEnabled = false;
            button_rolunk.IsEnabled = false;
            button_akciok.IsEnabled = false;
            button_nyitvatartas.IsEnabled = false;
            button_informaciok.IsEnabled = false;
            button_aszf.IsEnabled = false;
            button_biztonsagi_beallitasok.IsEnabled = false;
            button_felhasznalo_letrehozasa.IsEnabled = false;
            button_fomenube.IsEnabled = false;
        }
        
        void nyilvantartas_frissit() //Nyilvántartás frissítése az adatbázisban
        {
            string valasztottnap = listBox_napok.SelectedItem.ToString();
            MySqlConnection con = new MySqlConnection(kapcsolat);
            {
                con.Open();
                string sql = $"UPDATE `nyilvantartas` SET `mettol_ora` = @MettolOra, `mettol_perc` = @MettolPerc, `meddig_ora` = @MeddigOra, `meddig_perc` = @MeddigPerc WHERE `napok` = @Valasztottnap";
                MySqlCommand msqlc = new MySqlCommand(sql, con);
                msqlc.Parameters.AddWithValue("@Valasztottnap", valasztottnap);
                msqlc.Parameters.AddWithValue("@MettolOra", textBox_oratol.Text);
                msqlc.Parameters.AddWithValue("@MettolPerc", textBox_perctol.Text);
                msqlc.Parameters.AddWithValue("@MeddigOra", textBox_oraig.Text);
                msqlc.Parameters.AddWithValue("@MeddigPerc", textBox_percig.Text);
                msqlc.ExecuteNonQuery();
            }
            con.Close();
        }

       
        void nyilvantartas_lekerdez_hetfo()    //Hétfő nap nyitvatartásának lekérdezése
        {
            MySqlConnection con = new MySqlConnection(kapcsolat);
            con.Open();
            string sql = "SELECT `mettol_ora`,`mettol_perc`,`meddig_ora`,`meddig_perc` FROM nyilvantartas WHERE napok = 'Hétfő';";
            MySqlCommand msqlc = new MySqlCommand(sql, con);
            MySqlDataReader msdr = msqlc.ExecuteReader();
            while (msdr.Read())
            {
                textBox_oratol.Text = msdr.GetValue(0).ToString();
                textBox_perctol.Text= msdr.GetValue(1).ToString();
                textBox_oraig.Text = msdr.GetValue(2).ToString();
                textBox_percig.Text = msdr.GetValue(3).ToString();

                //Jelenlegi Nyitvatartás, Hétfő megjelenítése. (Képernyő Bal oldala)
                textbox_hetfo_mettolora.Text = msdr.GetValue(0).ToString();
                textbox_hetfo_mettolperc.Text = msdr.GetValue(1).ToString();
                textbox_hetfo_meddigora.Text = msdr.GetValue(2).ToString();
                textbox_hetfo_meddigperc.Text = msdr.GetValue(3).ToString();

            }
            msdr.Close();
            con.Close();
        }
        void nyilvantartas_lekerdez_kedd()  //Keddi nap nyitvatartásának lekérdezése
        {
            MySqlConnection con = new MySqlConnection(kapcsolat);
            con.Open();
            string sql = "SELECT `mettol_ora`,`mettol_perc`,`meddig_ora`,`meddig_perc` FROM nyilvantartas WHERE napok = 'Kedd';";
            MySqlCommand msqlc = new MySqlCommand(sql, con);
            MySqlDataReader msdr = msqlc.ExecuteReader();
            while (msdr.Read())
            {
                textBox_oratol.Text = msdr.GetValue(0).ToString();
                textBox_perctol.Text = msdr.GetValue(1).ToString();
                textBox_oraig.Text = msdr.GetValue(2).ToString();
                textBox_percig.Text = msdr.GetValue(3).ToString();

                //Jelenlegi Nyitvatartás, Kedd megjelenítése. (Képernyő Bal oldala)
                textbox_kedd_mettolora.Text = msdr.GetValue(0).ToString();
                textbox_kedd_mettolperc.Text = msdr.GetValue(1).ToString();
                textbox_kedd_meddigora.Text = msdr.GetValue(2).ToString();
                textbox_kedd_meddigperc.Text = msdr.GetValue(3).ToString();
            }
            msdr.Close();
            con.Close();
        }

        void nyilvantartas_lekerdez_szerda()  //Szerdai nap nyitvatartásának lekérdezése
        {
            MySqlConnection con = new MySqlConnection(kapcsolat);
            con.Open();
            string sql = "SELECT `mettol_ora`,`mettol_perc`,`meddig_ora`,`meddig_perc` FROM nyilvantartas WHERE napok = 'Szerda';";
            MySqlCommand msqlc = new MySqlCommand(sql, con);
            MySqlDataReader msdr = msqlc.ExecuteReader();
            while (msdr.Read())
            {
                textBox_oratol.Text = msdr.GetValue(0).ToString();
                textBox_perctol.Text = msdr.GetValue(1).ToString();
                textBox_oraig.Text = msdr.GetValue(2).ToString();
                textBox_percig.Text = msdr.GetValue(3).ToString();

                //Jelenlegi Nyitvatartás, Szerda megjelenítése. (Képernyő Bal oldala)
                textbox_szerda_mettolora.Text = msdr.GetValue(0).ToString();
                textbox_szerda_mettolperc.Text = msdr.GetValue(1).ToString();
                textbox_szerda_meddigora.Text = msdr.GetValue(2).ToString();
                textbox_szerda_meddigperc.Text = msdr.GetValue(3).ToString();

            }
            msdr.Close();
            con.Close();
        }

        void nyilvantartas_lekerdez_csutortok()  //Csütörtöki nap nyitvatartásának lekérdezése
        {
            MySqlConnection con = new MySqlConnection(kapcsolat);
            con.Open();
            string sql = "SELECT `mettol_ora`,`mettol_perc`,`meddig_ora`,`meddig_perc` FROM nyilvantartas WHERE napok = 'Csütörtök';";
            MySqlCommand msqlc = new MySqlCommand(sql, con);
            MySqlDataReader msdr = msqlc.ExecuteReader();
            while (msdr.Read())
            {
                textBox_oratol.Text = msdr.GetValue(0).ToString();
                textBox_perctol.Text = msdr.GetValue(1).ToString();
                textBox_oraig.Text = msdr.GetValue(2).ToString();
                textBox_percig.Text = msdr.GetValue(3).ToString();
                
                //Jelenlegi Nyitvatartás, Csütörtök megjelenítése. (Képernyő Bal oldala)
                textbox_csutortok_mettolora.Text = msdr.GetValue(0).ToString();
                textbox_csutortok_mettolperc.Text = msdr.GetValue(1).ToString();
                textbox_csutortok_meddigora.Text = msdr.GetValue(2).ToString();
                textbox_csutortok_meddigperc.Text = msdr.GetValue(3).ToString();

            }
            msdr.Close();
            con.Close();

        }

        void nyilvantartas_lekerdez_pentek()  //Pénteki nap nyitvatartásának lekérdezése
        {
            MySqlConnection con = new MySqlConnection(kapcsolat);
            con.Open();
            string sql = "SELECT `mettol_ora`,`mettol_perc`,`meddig_ora`,`meddig_perc` FROM nyilvantartas WHERE napok = 'Péntek';";
            MySqlCommand msqlc = new MySqlCommand(sql, con);
            MySqlDataReader msdr = msqlc.ExecuteReader();
            while (msdr.Read())
            {
                textBox_oratol.Text = msdr.GetValue(0).ToString();
                textBox_perctol.Text = msdr.GetValue(1).ToString();
                textBox_oraig.Text = msdr.GetValue(2).ToString();
                textBox_percig.Text = msdr.GetValue(3).ToString();

                //Jelenlegi Nyitvatartás, Péntek megjelenítése. (Képernyő Bal oldala)
                textbox_pentek_mettolora.Text = msdr.GetValue(0).ToString();
                textbox_pentek_mettolperc.Text = msdr.GetValue(1).ToString();
                textbox_pentek_meddigora.Text = msdr.GetValue(2).ToString();
                textbox_pentek_meddigperc.Text = msdr.GetValue(3).ToString();


            }
            msdr.Close();
            con.Close();

        }
        void nyilvantartas_lekerdez_szombat() //Szombati nap nyitvatartásának lekérdezése
        {
            MySqlConnection con = new MySqlConnection(kapcsolat);
            con.Open();
            string sql = "SELECT `mettol_ora`,`mettol_perc`,`meddig_ora`,`meddig_perc` FROM nyilvantartas WHERE napok = 'Szombat';";
            MySqlCommand msqlc = new MySqlCommand(sql, con);
            MySqlDataReader msdr = msqlc.ExecuteReader();
            while (msdr.Read())
            {
                textBox_oratol.Text = msdr.GetValue(0).ToString();
                textBox_perctol.Text = msdr.GetValue(1).ToString();
                textBox_oraig.Text = msdr.GetValue(2).ToString();
                textBox_percig.Text = msdr.GetValue(3).ToString();

                //Jelenlegi Nyitvatartás, Szombat megjelenítése. (Képernyő Bal oldala)
                textbox_szombat_mettolora.Text = msdr.GetValue(0).ToString();
                textbox_szombat_mettolperc.Text = msdr.GetValue(1).ToString();
                textbox_szombat_meddigora.Text = msdr.GetValue(2).ToString();
                textbox_szombat_meddigperc.Text = msdr.GetValue(3).ToString();
            }
            msdr.Close();
            con.Close();
        }

        void nyilvantartas_lekerdez_vasarnap() //Vasárnapi nap nyitvatartásának lekérdezése
        {
            MySqlConnection con = new MySqlConnection(kapcsolat);
            con.Open();
            string sql = "SELECT `mettol_ora`,`mettol_perc`,`meddig_ora`,`meddig_perc` FROM nyilvantartas WHERE napok = 'Vasárnap';";
            MySqlCommand msqlc = new MySqlCommand(sql, con);
            MySqlDataReader msdr = msqlc.ExecuteReader();
            while (msdr.Read())
            {
                textBox_oratol.Text = msdr.GetValue(0).ToString();
                textBox_perctol.Text = msdr.GetValue(1).ToString();
                textBox_oraig.Text = msdr.GetValue(2).ToString();
                textBox_percig.Text = msdr.GetValue(3).ToString();

                //Jelenlegi Nyitvatartás, Vasárnap megjelenítése. (Képernyő Bal oldala)
                textbox_vasarnap_mettolora.Text = msdr.GetValue(0).ToString();
                textbox_vasarnap_mettolperc.Text = msdr.GetValue(1).ToString();
                textbox_vasarnap_meddigora.Text = msdr.GetValue(2).ToString();
                textbox_vasarnap_meddigperc.Text = msdr.GetValue(3).ToString();
            }
            msdr.Close();
            con.Close();
        }

        //Napok lekerdezése ^

        void nyilvantartas_lekerdez_napok()   //Napok lekérdezése az adatbázisból
        {
            MySqlConnection con = new MySqlConnection(kapcsolat);
            con.Open();
            string sql = "SELECT `napok` FROM `nyilvantartas` WHERE `napok` IS NOT NULL;";
            MySqlCommand msqlc = new MySqlCommand(sql, con);
            MySqlDataReader msdr = msqlc.ExecuteReader();
            while (msdr.Read())
            {
                string napok = msdr["napok"].ToString();
                if (!string.IsNullOrWhiteSpace(napok))
                {
                    listBox_napok.Items.Add(napok);
                    listBox_napok.SelectedIndex = 0;
                }       
            }
            msdr.Close();
            con.Close();
        }

            void lekerdez_telefonszam() //Telefonszám lekérdezése az adatbázisból
        {           
            MySqlConnection con = new MySqlConnection(kapcsolat);
            con.Open();
            string sql = "SELECT `telefonszam` FROM `pizzeria` WHERE 1";
            MySqlCommand msqlc = new MySqlCommand(sql, con);
            MySqlDataReader msdr = msqlc.ExecuteReader();
            while (msdr.Read())
            {
                string telefonszam = msdr["telefonszam"].ToString();
                if (!string.IsNullOrEmpty(telefonszam))
                {
                    textBox_meglevotelszam.Text = telefonszam;
                    break;
                }
            }
            msdr.Close();
            con.Close();
        }
        void telefonszam_modositasa() //Telefonszám módosítása a adatbázisól
        {

            string ujTelefonszam = textBox_ujtelefonszam.Text;
            MySqlConnection con = new MySqlConnection(kapcsolat);
            con.Open();
            string sql = $"UPDATE pizzeria SET telefonszam = @UjTelefonszam";
            MySqlCommand msqlc = new MySqlCommand(sql, con);
            msqlc.Parameters.AddWithValue("@UjTelefonszam", ujTelefonszam);
            msqlc.ExecuteNonQuery();

            con.Close();

        }
        void lekerdez_email() //E-mail lekérdezése az adatbázisból
        {
            MySqlConnection con = new MySqlConnection(kapcsolat);
            con.Open();
            string sql = "SELECT `email` FROM `pizzeria` WHERE 1";
            MySqlCommand msqlc = new MySqlCommand(sql, con);
            MySqlDataReader msdr = msqlc.ExecuteReader();
            while (msdr.Read())
            {
                string email = msdr["email"].ToString();
                if (!string.IsNullOrEmpty(email))
                {
                    textBox_email.Text = email;
                    break;
                }
            }
            msdr.Close();
            con.Close();
        }
        void email_modositasa() //Email módosítása a adatbázisól
        {
            string ujEmail = textBox_ujemail.Text;
            MySqlConnection con = new MySqlConnection(kapcsolat);
            con.Open();
            string sql = $"UPDATE pizzeria SET email = @UjEmail";
            MySqlCommand msqlc = new MySqlCommand(sql, con);
            msqlc.Parameters.AddWithValue("@UjEmail", ujEmail);
            msqlc.ExecuteNonQuery();

            con.Close();
        }
        void lekerdez_cim() //Cím lekérdezése az adatbázisból
        {
            MySqlConnection con = new MySqlConnection(kapcsolat);
            con.Open();
            string sql = "SELECT `telephely` FROM `pizzeria` WHERE 1";
            MySqlCommand msqlc = new MySqlCommand(sql, con);
            MySqlDataReader msdr = msqlc.ExecuteReader();
            while (msdr.Read())
            {
                string cim = msdr["telephely"].ToString();
                if (!string.IsNullOrEmpty(cim))
                {
                    textBox_cim.Text = cim;
                    break;
                }
            }
            msdr.Close();
            con.Close();
        }
        void cim_modositasa() //Cím Módosítása az adatbázisból
        {
            string ujCim = textBox_ujcim.Text;
            MySqlConnection con = new MySqlConnection(kapcsolat);
            con.Open();
            string sql = $"UPDATE pizzeria SET telephely = @UjCim";
            MySqlCommand msqlc = new MySqlCommand(sql, con);
            msqlc.Parameters.AddWithValue("@UjCim",ujCim);
            msqlc.ExecuteNonQuery();
            con.Close();
        }
        void lekerdez_rolunk() //E-mail lekérdezése az adatbázisbó
        {
            MySqlConnection con = new MySqlConnection(kapcsolat);
            con.Open();
            string sql = "SELECT `rolunk` FROM `pizzeria` WHERE 1";
            MySqlCommand msqlc = new MySqlCommand(sql, con);
            MySqlDataReader msdr = msqlc.ExecuteReader();
            while (msdr.Read())
            {
                string rolunk = msdr["rolunk"].ToString();
                if (!string.IsNullOrEmpty(rolunk))
                {
                    textBox_rolunk.Text = rolunk;
                    break;
                }
            }
            msdr.Close();
            con.Close();
        
        }
        void rolunk_modositasa() //Rólunk  Módosítása az adatbázisból
        {
            string ujRolunk = textBox_ujrolunk.Text;
            MySqlConnection con = new MySqlConnection(kapcsolat);
            con.Open();
            string sql = $"UPDATE pizzeria SET rolunk = @UjRolunk";
            MySqlCommand msqlc = new MySqlCommand(sql, con);
            msqlc.Parameters.AddWithValue("@UjRolunk", ujRolunk);
            msqlc.ExecuteNonQuery();
            con.Close();
        }
        //felhasznalo_letrehozasa Kihagyva
        void lekerdez_akciok() //Akciók lekérdezése az adatbázisból
        {
            MySqlConnection con = new MySqlConnection(kapcsolat);
            con.Open();
            string sql = "SELECT `akciok` FROM `pizzeria` WHERE 1";
            MySqlCommand msqlc = new MySqlCommand(sql, con);
            MySqlDataReader msdr = msqlc.ExecuteReader();
            while (msdr.Read())
            {
                string akciok = msdr["akciok"].ToString();
                if (!string.IsNullOrEmpty(akciok))
                {
                    textBox_akciok.Text = akciok;
                    break;
                }
            }
            msdr.Close();
            con.Close();
        }
        void akciok_modositasa() //Akciók  Módosítása az adatbázisból
        {
            string ujAkciok = textBox_ujakciok.Text;
            MySqlConnection con = new MySqlConnection(kapcsolat);
            con.Open();
            string sql = $"UPDATE pizzeria SET akciok = @UjAkciok";
            MySqlCommand msqlc = new MySqlCommand(sql, con);
            msqlc.Parameters.AddWithValue("@UjAkciok", ujAkciok);
            msqlc.ExecuteNonQuery();
            con.Close();
        }
        //Nyitvatartás kihagyva
        void lekerdez_informaciok() //Információk lekérdezése az adatbázisból
        {
            MySqlConnection con = new MySqlConnection(kapcsolat);
            con.Open();
            string sql = "SELECT `informaciok` FROM `pizzeria` WHERE 1";
            MySqlCommand msqlc = new MySqlCommand(sql, con);
            MySqlDataReader msdr = msqlc.ExecuteReader();
            while (msdr.Read())
            {
                string informaciok = msdr["informaciok"].ToString();
                if (!string.IsNullOrEmpty(informaciok))
                {
                    textBox_informacio.Text = informaciok;
                    break;
                }
            }
            msdr.Close();
            con.Close();
        }
        void informaciok_modositasa() //Információk  Módosítása az adatbázisból
        {
            string ujInformaciok = textBox_ujinfromacio.Text;
            MySqlConnection con = new MySqlConnection(kapcsolat);
            con.Open();
            string sql = $"UPDATE pizzeria SET informaciok = @UjInformaciok";
            MySqlCommand msqlc = new MySqlCommand(sql, con);
            msqlc.Parameters.AddWithValue("@UjInformaciok", ujInformaciok);
            msqlc.ExecuteNonQuery();
            con.Close();
        }
        void lekerdez_aszf()    //Aszf lekérdezése az adatbázisból
        {
            MySqlConnection con = new MySqlConnection(kapcsolat);
            con.Open();
            string sql = "SELECT `aszf` FROM `pizzeria` WHERE 1";
            MySqlCommand msqlc = new MySqlCommand(sql, con);
            MySqlDataReader msdr = msqlc.ExecuteReader();
            while (msdr.Read())
            {
                string aszf = msdr["aszf"].ToString();
                if (!string.IsNullOrEmpty(aszf))
                {
                    textBox_aszf.Text = aszf;
                    break;
                }
            }
            msdr.Close();
            con.Close();
        }
        void aszf_modositasa() 
        {
            string ujAszf = textBox_ujaszf.Text;
            MySqlConnection con = new MySqlConnection(kapcsolat);
            con.Open();
            string sql = $"UPDATE pizzeria SET aszf = @UjAszf";
            MySqlCommand msqlc = new MySqlCommand(sql, con);
            msqlc.Parameters.AddWithValue("@UjAszf", ujAszf);
            msqlc.ExecuteNonQuery();
            con.Close();
        }


        //

        //Gombra Kattintás események
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
        private void button_fomenube_Click(object sender, RoutedEventArgs e) //Vissza a Főoldalra!
        {
            Fomenu F_menu = new Fomenu();
            F_menu.Show();
            this.Close();
        }
        private void button_telefonszam_Click(object sender, RoutedEventArgs e) // A telefonszam módositása ablak előhívása.
        {
            telefon_megjelenit_tilt();
            lekerdez_telefonszam(); //Telfonszam gombra kattintva előhívja az adatbázisból az adatokat
        }
        private void button_tszam_becsuk_Click(object sender, RoutedEventArgs e) // A telefonszam módositása ablak becsukása.
        {
            telefon_elrejt_old(); //függvény meghívása
            textBox_ujtelefonszam.Text = ""; //Ablak bezárásakor ne legyen a boxban szöveg


        }
        private void button_email_Click(object sender, RoutedEventArgs e) // Az E-mailmódositása ablak előhívása.
        {
            email_megjelenit_tilt();
            lekerdez_email();                    //Email gombra kattintva előhívja az adatbázisból az adatokat
        }
        private void button_email_becsuk_Click(object sender, RoutedEventArgs e) // Az E-mail módositása ablak becsukása.
        {
            email_elrejt_old();
            textBox_ujemail.Text = ""; //Ablak bezárásakor ne legyen a boxban szöveg

        }
        private void button_cim_Click(object sender, RoutedEventArgs e) // A Cím módositása ablak előhívása
        {
            cim_megjelenit_tilt();
            lekerdez_cim();                     //Email gombra kattintva előhívja az adatbázisból az adatokat
        }
        private void button_cim_becsuk_Click(object sender, RoutedEventArgs e) // A Cím módositása ablak becsukása.
        {
            cim_elrejt_old(); 
            textBox_ujcim.Text = "";                    //Ablak bezárásakor ne legyen a boxban szöveg
        }
        private void button_rolunk_Click(object sender, RoutedEventArgs e) // Az Rólunk módositása ablak előhívása.
        {
            rolunk_megjelenit_tilt();
            lekerdez_rolunk();                               //Rólunk gombra kattintva előhívja az adatbázisból az adatokat
        } 
        private void button_rolunk_becsuk_Click(object sender, RoutedEventArgs e)// A Rólunk módositása ablak becsukása.
        {
            rolunk_elrejt_old();
            textBox_ujrolunk.Text = "";                         //Ablak bezárásakor ne legyen a boxban szöveg

        } 
        private void button_felh_letrehoz_Click(object sender, RoutedEventArgs e) // Az Új felhasználó létrehozása ablak előhívása.
        {
            felhasznalo_letrehozasa_megjelenit_tilt();
        }
        private void button_felh_letrehoz_becsuk_Click(object sender, RoutedEventArgs e) // Az Új felhasználó létrehozása ablak bescsukása.
        {
            felhasznalo_letrehozasa_elrejt_old();
        }
        private void button_akciok_Click(object sender, RoutedEventArgs e) // Az Akciók módositása ablak előhívása.
        {
            akciok_megjelenit_tilt();
            lekerdez_akciok();    //Akciók gombra kattintva előhívja az adatbázisból az adatokat
        }
        private void button_akciok_becsuk_Click(object sender, RoutedEventArgs e) // Az Akciók módositása ablak bescsukása.
        {
            akciok_elrejt_old();
            textBox_ujakciok.Text = "";                    //Ablak bezárásakor ne legyen a boxban szöveg
        }
        private void button_nyitvatartas_Click(object sender, RoutedEventArgs e) // A Nyitvatartás  módositása ablak előhívása.
        {
            nyitvatartas_megjelenit_tilt();
        }
        private void button_nyitvatartas_becsuk_Click(object sender, RoutedEventArgs e) // Az Nyitvartás módositása ablak bescsukása.
        {
            nyitvatartas_elrejt_old();
        }
        private void button_nyitvatartas_megsem_Click(object sender, RoutedEventArgs e) // A Nyitvatartás Beállítások módositása ablak bescsukása.
        {
            nyitvatartas_elrejt_old();
        }
        private void button_informaciok_Click(object sender, RoutedEventArgs e) // Az Információkk módositása ablak előhívása.
        {
            informaciok_megjelenit_tilt();
            lekerdez_informaciok();                              //Információk gombra kattintva előhívja az adatbázisból az adatokat
        }
        private void button_informacio_becsuk_Click(object sender, RoutedEventArgs e) // Az Információk módositása ablak bescsukása.
        {
             informaciok_elrejt_old();
             textBox_ujinfromacio.Text = "";                             //Ablak bezárásakor ne legyen a boxban szöveg
        }
        private void button_aszf_Click(object sender, RoutedEventArgs e) // Az ASZF módositása ablak előhívása.
        {
            aszf_megjelenit_tilt();
            lekerdez_aszf();                    //ASZF gombra kattintva előhívja az adatbázisból az adatokat
        }
        private void button_aszf_becsuk_Click(object sender, RoutedEventArgs e) // Az ASZF módositása ablak bescsukása.
        {

            aszf_elrejt_old();
            textBox_ujaszf.Text = "";                        //Ablak bezárásakor ne legyen a boxban szöveg
        }
        private void button_biztonsagi_beallitasok_Click(object sender, RoutedEventArgs e) // A Biztonsági Beállítások módositása ablak előhívása.
        {
            biztonsagi_beallitasok_megjelenit_tilt();
        }
        private void button_bizbeall_becsuk_Click(object sender, RoutedEventArgs e) // A Biztonsági Beállítások módositása ablak bescsukása.
        {
            biztonsagi_beallitasok_elrejt_old();
        }
        //felhasznalo_letrehozasa Kihagyva
        private void button_modosit_Click(object sender, RoutedEventArgs e) //Módosítja a telefonszámot az Adatbázsiból /GOMB/
        {

           if (MessageBox.Show("Biztos,hogy módosítja a telefonszámot?", "Telefonszám Módosítása", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            { 
                if (textBox_ujtelefonszam.Text != "" && textBox_ujtelefonszam.Text.Length == 12 || textBox_ujtelefonszam.Text.Length == 11)
                {
                    telefonszam_modositasa();
                    if (MessageBox.Show("Sikeres Módosítás!", "Telefonszám Módosítása", MessageBoxButton.OK, MessageBoxImage.Information) == MessageBoxResult.OK)
                    {
                        lekerdez_telefonszam();
                        textBox_ujtelefonszam.Text = ""; // A módosított telefonszám után ne maradjanak bent a beírt karakterek.
                    }

                }
                else
                {
                    MessageBox.Show("Sikertelen módosítás! A telefonszámnak 12 karakternek kell lennie! Példa:[+36301234567]", "Telefonszám Módosítása", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            
        }
        private void button_e_modosit_Click(object sender, RoutedEventArgs e) //Módosítja az Emailt az Adatbázsiból /GOMB/
        {

                if (MessageBox.Show("Biztos,hogy módosítja az Új-email címre?", "E-mail Módosítása", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (textBox_ujemail.Text != "")
                    {
                        email_modositasa();
                        if (MessageBox.Show("Sikeres Módosítás!", "E-mail Módosítása", MessageBoxButton.OK, MessageBoxImage.Information) == MessageBoxResult.OK)
                        {
                            lekerdez_email();
                            textBox_ujemail.Text = ""; // A módosított Email után ne maradjanak bent a beírt karakterek.
                        }

                    }
                    else
                    {
                        MessageBox.Show("Sikertelen módosítás!", "E-mail Módosítása", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }        
        }
        private void button_cim_modosit_Click(object sender, RoutedEventArgs e) //Módosítja az Cím az Adatbázsiból /GOMB/
        {
            if (MessageBox.Show("Biztos,hogy módosítja a Címet?","Cím Módosítása", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (textBox_ujcim.Text != "")
                {
                    cim_modositasa();
                    if (MessageBox.Show("Sikeres Módosítás!", "Cím Módosítása", MessageBoxButton.OK, MessageBoxImage.Information) == MessageBoxResult.OK)
                    {
                        lekerdez_cim();
                        textBox_ujcim.Text = ""; // A módosított Cím után ne maradjanak bent a beírt karakterek.
                    }

                }
                else
                {
                    MessageBox.Show("Sikertelen módosítás!", "Cím Módosítása", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private void button_rolunk_modosit_Click(object sender, RoutedEventArgs e) //Módosítja a Rólunk-ot az Adatbázsiból /GOMB/
        {
            if (MessageBox.Show("Biztos,hogy módosítja a Rólunk kiírást?", "Rólunk Módosítása", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (textBox_ujrolunk.Text != "")
                {
                    rolunk_modositasa();
                    if (MessageBox.Show("Sikeres Módosítás!", "Cím Módosítása", MessageBoxButton.OK, MessageBoxImage.Information) == MessageBoxResult.OK)
                    {
                        lekerdez_rolunk();
                        textBox_ujrolunk.Text = ""; // A módosított Rúlunk menüpont után ne maradjanak bent a beírt karakterek.
                    }

                }
                else
                {
                    MessageBox.Show("Sikertelen módosítás!", "Cím Módosítása", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            
        }

        //felhasznalo_letrehozasa Kihagyva

        private void button_akciok_modosit_Click(object sender, RoutedEventArgs e) //Módosítja az Akciók leírását az Adatbázsiból /GOMB/
        {
            if (MessageBox.Show("Biztos,hogy módosítja az Akciókat?", "Akciók Módosítása", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                
                    akciok_modositasa();
                    if (MessageBox.Show("Sikeres Módosítás!", "Akciók Módosítása", MessageBoxButton.OK, MessageBoxImage.Information) == MessageBoxResult.OK)
                    {
                        lekerdez_akciok();
                        textBox_ujakciok.Text = ""; // A módosított Akciók után ne maradjanak bent a beírt karakterek.
                    }

                
                else
                {
                    MessageBox.Show("Sikertelen módosítás!", "Akciók Módosítása", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            
        }


        //Nyitvatartas Kihagyva

        private void button_informacio_modosit_Click(object sender, RoutedEventArgs e) //Módosítja az Információk leírását az Adatbázsiból /GOMB/
        {
            if (MessageBox.Show("Biztos,hogy módosítja az Információkat?", "Információk Módosítása", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {

                informaciok_modositasa();
                if (MessageBox.Show("Sikeres Módosítás!", "Információk Módosítása", MessageBoxButton.OK, MessageBoxImage.Information) == MessageBoxResult.OK)
                {
                    lekerdez_informaciok();
                    textBox_ujinfromacio.Text = ""; // A módosított Információk után ne maradjanak bent a beírt karakterek.
                }


                else
                {
                    MessageBox.Show("Sikertelen módosítás!", "Információk Módosítása", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        } 

        private void button_aszf_modosit_Click(object sender, RoutedEventArgs e) //Módosítja az Ászf leírását az Adatbázsiból /GOMB/
        {
            if (MessageBox.Show("Biztos,hogy módosítja az ÁSZF-t?", "ÁSZF Módosítása", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {

                aszf_modositasa();
                if (MessageBox.Show("Sikeres Módosítás!", "ÁSZF Módosítása", MessageBoxButton.OK, MessageBoxImage.Information) == MessageBoxResult.OK)
                {
                    lekerdez_aszf();
                    textBox_ujaszf.Text = ""; // A módosított ÁSZF-t után ne maradjanak bent a beírt karakterek.
                }


                else
                {
                    MessageBox.Show("Sikertelen módosítás!", "ÁSZF-t Módosítása", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }


        //A Módosít gombok letilátsa ha a textboxok üresek!
        private void textBox_ujtelefonszam_TextChanged(object sender, TextChangedEventArgs e) //UJ_Telefonszám módosítása gomb letiltása ha üres a beviteli mező
        {
            if (textBox_ujtelefonszam.Text != "") button_modosit.IsEnabled = true;
            else button_modosit.IsEnabled = false;
        }
        private void textBox_ujemail_TextChanged(object sender, TextChangedEventArgs e) //UJ_Email módosítása gomb letiltása ha üres a beviteli mező
        {
            if (textBox_ujemail.Text != "") button_e_modosit.IsEnabled = true;
            else button_e_modosit.IsEnabled = false;
        }
        private void textBox_ujcim_TextChanged(object sender, TextChangedEventArgs e) //Új Cím módosítása gomb letiltása ha üres a beviteli mező
        {
            if(textBox_ujcim.Text != "") button_cim_modosit.IsEnabled = true;
            else button_cim_modosit.IsEnabled = false;
        }
        private void textBox_ujrolunk_TextChanged(object sender, TextChangedEventArgs e) //Új Rólunk módosítása gomb letiltása ha üres a beviteli mező
        {
            if (textBox_ujrolunk.Text != "") button_rolunk_modosit.IsEnabled = true;
            else button_rolunk_modosit.IsEnabled = false;
        }
        //Textbox_felhasznalo_letrehozasa Kihagyva
        private void textBox_ujakciok_TextChanged(object sender, TextChangedEventArgs e) //Új Akciók módosítása gomb letiltása ha üres a beviteli mező
        {
            if (textBox_ujakciok.Text != "") button_akciok_modosit.IsEnabled = true;
            else button_akciok_modosit.IsEnabled = false;
        }
        //Nyitvatartás hiányzik
        private void textBox_ujinfromacio_TextChanged(object sender, TextChangedEventArgs e) //Új Inforámáció módosítása gomb letiltása ha üres a beviteli mező
        {
            if (textBox_ujinfromacio.Text != "") button_informacio_modosit.IsEnabled = true;
            else button_informacio_modosit.IsEnabled = false;
        }

        private void textBox_ujaszf_TextChanged(object sender, TextChangedEventArgs e) //Új ASZF módosítása gomb letiltása ha üres a beviteli mező
        {
            if (textBox_ujaszf.Text != "") button_aszf_modosit.IsEnabled = true;
            else button_aszf_modosit.IsEnabled = false;
        }





        private void listBox_napok_SelectionChanged(object sender, SelectionChangedEventArgs e) // listbox nap kiválasztása  és a napok a texboxban való megjelenítése (NYITVATARTÁS)
        {
            if (listBox_napok.SelectedIndex == 0) //Hétfő Kiválasztása
            {
                nyilvantartas_lekerdez_hetfo();
            }

            if (listBox_napok.SelectedIndex == 1) //Kedd Kiválasztása
            {
                nyilvantartas_lekerdez_kedd();
            }

            if (listBox_napok.SelectedIndex == 2) //Szerda Kiválasztása
            {
                nyilvantartas_lekerdez_szerda();
            }
            if (listBox_napok.SelectedIndex == 3) //Csütörtök Kiválasztása
            {
                nyilvantartas_lekerdez_csutortok();
            }
            if (listBox_napok.SelectedIndex == 4) //Péntek Kiválasztása
            {
                nyilvantartas_lekerdez_pentek();
            }
            if (listBox_napok.SelectedIndex == 5) //Szombat Kiválasztása
            {
                nyilvantartas_lekerdez_szombat();
            }
            if (listBox_napok.SelectedIndex == 6) //Vasárnap Kiválasztása
            {
                nyilvantartas_lekerdez_vasarnap();
            }
        }

        private void button_kismeret_Click(object sender, RoutedEventArgs e)            //Kis Méretezés a tálcára
        {
            this.WindowState = WindowState.Minimized;
        }

        //Dupla Kattintáskor törli a mező értékét (Nyilvántartás)
        private void textBox_perctol_MouseDoubleClick(object sender, MouseButtonEventArgs e) //Dupla kattintáskor üresre írja vissza a texbox_perctol mezőjét
        {           
            textBox_perctol.Text = "";
        }

        private void textBox_oratol_MouseDoubleClick(object sender, MouseButtonEventArgs e) //Dupla kattintáskor üresre írja vissza a texbox_orától mezőjét
        {
            textBox_oratol.Text = "";
        }

        private void textBox_oraig_MouseDoubleClick(object sender, MouseButtonEventArgs e)//Dupla kattintáskor üresre írja vissza a texbox_oraig mezőjét
        {
            textBox_oraig.Text = "";
        }

        private void textBox_percig_MouseDoubleClick(object sender, MouseButtonEventArgs e) //Dupla kattintáskor üresre írja vissza a texbox_percig mezőjét
        {
            textBox_percig.Text = "";
        }
        //
        private void button_nyitvatartas_idoszak_uresre_Click(object sender, RoutedEventArgs e) // Kattintáskor üresen adja vissza az időszak értékeit(Nem módosít)
        {
            textBox_perctol.Text = "";
            textBox_oratol.Text = "";
            textBox_oraig.Text = "";
            textBox_percig.Text = "";
        }

        private void button_nyitvatartas_modosit_Click(object sender, RoutedEventArgs e) //Az adatbázisban módosítja a nyitvatartási időt.
        {
            if (MessageBox.Show("Biztos,hogy módosítja a Nyitvatartást?", "Nyitvatartás Módosítása", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (MessageBox.Show("Sikeres Módosítás!", "A nyitvatartás módosult", MessageBoxButton.OK, MessageBoxImage.Information) == MessageBoxResult.OK)
                {
                    nyilvantartas_frissit();
                    nyilvantartas_lekerdez_hetfo();
                    nyilvantartas_lekerdez_kedd();
                    nyilvantartas_lekerdez_szerda();
                    nyilvantartas_lekerdez_csutortok();
                    nyilvantartas_lekerdez_pentek();
                    nyilvantartas_lekerdez_szombat();
                    nyilvantartas_lekerdez_vasarnap();
                }
            }
            
        }
    }
}
