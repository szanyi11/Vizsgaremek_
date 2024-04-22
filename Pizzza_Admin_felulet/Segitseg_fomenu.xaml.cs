using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

    public partial class Segitseg_fomenu : Window
    {
        string kapcsolat = (App.Current as App).beconfig(); //SQL Elérése a config fájlból!
        private void Window_MouseDown(object sender, MouseButtonEventArgs e) //Segítség_főmenü ablakának mozgatása
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();

            }
        }
        void fomenu_megjelenit_gombok_elrejt() //Segítség Főmenü előhívása,gombok elrejtése,hozzá tartozó elemek megjelenítése.
        {
            

            button_fomenu.Visibility = Visibility.Hidden;
            //button_rendelesek.Visibility = Visibility.Hidden;
            button_modositasok.Visibility = Visibility.Hidden;
            button_etlap.Visibility = Visibility.Hidden;
            button_program_bezarasa.Visibility = Visibility.Hidden;
            button_bekijelentkezes.Visibility = Visibility.Hidden;
            button_visszajelzes.Visibility = Visibility.Hidden;
            button_programrol.Visibility = Visibility.Hidden;
            button_etlapmodositasa.Visibility = Visibility.Hidden;
            button_feltethozzaadasa.Visibility = Visibility.Hidden;
            button_feltetmodositasa.Visibility = Visibility.Hidden;
            button_ujtermek.Visibility = Visibility.Hidden;
            button_segitsegek.Visibility = Visibility.Hidden;
            //button_felhasznalo_letrehozasa.Visibility = Visibility.Hidden;
            //button_biztonsagi_beallitasok.Visibility = Visibility.Hidden;
            button_a_fomenube.Visibility = Visibility.Hidden;

            textBlock_fomenuosszefoglalo.Visibility = Visibility.Visible;
            textBlock_menuleiras.Visibility = Visibility.Visible;
            border_fomenu.Visibility = Visibility.Visible;
            label_afomenu.Visibility = Visibility.Visible;
            button_rendben.Visibility = Visibility.Visible;
            border_takaras.Visibility = Visibility.Visible;
        }
        void fomenu_elrejt_gombok_megjelenit() //Segítség Főmenü elrejtése,gombok meglenítése,hozzá tartozó elemek elrejtése.
        {
            button_fomenu.Visibility = Visibility.Visible;
            //button_rendelesek.Visibility = Visibility.Visible;
            button_modositasok.Visibility = Visibility.Visible;
            button_etlap.Visibility = Visibility.Visible;
            button_program_bezarasa.Visibility = Visibility.Visible;
            button_bekijelentkezes.Visibility = Visibility.Visible;
            button_visszajelzes.Visibility = Visibility.Visible;
            button_programrol.Visibility = Visibility.Visible;
            button_etlapmodositasa.Visibility = Visibility.Visible;
            button_feltethozzaadasa.Visibility = Visibility.Visible;
            button_feltetmodositasa.Visibility = Visibility.Visible;
            button_ujtermek.Visibility = Visibility.Visible;
            button_segitsegek.Visibility = Visibility.Visible;
            //button_felhasznalo_letrehozasa.Visibility = Visibility.Visible;
            //button_biztonsagi_beallitasok.Visibility = Visibility.Visible;
            button_a_fomenube.Visibility = Visibility.Visible;

            label_afomenu.Visibility = Visibility.Hidden;
            textBlock_fomenuosszefoglalo.Visibility = Visibility.Hidden;
            textBlock_menuleiras.Visibility = Visibility.Hidden;
            border_fomenu.Visibility = Visibility.Hidden;
            label_afomenu.Visibility = Visibility.Hidden;
            button_rendben.Visibility = Visibility.Hidden;
            border_takaras.Visibility = Visibility.Hidden;
        }
        void segitsegek_megjelenit_gombok_elrejt() //Segítség A Segítségek előhívása,gombok elrejtése,hozzá tartozó elemek megjelenítése.
        {


            button_fomenu.Visibility = Visibility.Hidden;
            //button_rendelesek.Visibility = Visibility.Hidden;
            button_modositasok.Visibility = Visibility.Hidden;
            button_etlap.Visibility = Visibility.Hidden;
            button_program_bezarasa.Visibility = Visibility.Hidden;
            button_bekijelentkezes.Visibility = Visibility.Hidden;
            button_visszajelzes.Visibility = Visibility.Hidden;
            button_programrol.Visibility = Visibility.Hidden;
            button_etlapmodositasa.Visibility = Visibility.Hidden;
            button_feltethozzaadasa.Visibility = Visibility.Hidden;
            button_feltetmodositasa.Visibility = Visibility.Hidden;
            button_ujtermek.Visibility = Visibility.Hidden;
            button_segitsegek.Visibility = Visibility.Hidden;
            //button_felhasznalo_letrehozasa.Visibility = Visibility.Hidden;
            //button_biztonsagi_beallitasok.Visibility = Visibility.Hidden;
            button_a_fomenube.Visibility = Visibility.Hidden;

            label_segitsegek.Visibility = Visibility.Visible;
            border_segitsegek.Visibility = Visibility.Visible;
            textBlock_menuleiras_segitsegek.Visibility = Visibility.Visible;
            button_rendben.Visibility = Visibility.Visible;
            border_takaras.Visibility = Visibility.Visible;
        }
        void segitsegek_elrejt_gombok_megjelenit()//Segítség A Segítségek elrejtése,gombok meglenítése,hozzá tartozó elemek elrejtése.
        {


            button_fomenu.Visibility = Visibility.Visible;
            //button_rendelesek.Visibility = Visibility.Visible;
            button_modositasok.Visibility = Visibility.Visible;
            button_etlap.Visibility = Visibility.Visible;
            button_program_bezarasa.Visibility = Visibility.Visible;
            button_bekijelentkezes.Visibility = Visibility.Visible;
            button_visszajelzes.Visibility = Visibility.Visible;
            button_programrol.Visibility = Visibility.Visible;
            button_etlapmodositasa.Visibility = Visibility.Visible;
            button_feltethozzaadasa.Visibility = Visibility.Visible;
            button_feltetmodositasa.Visibility = Visibility.Visible;
            button_ujtermek.Visibility = Visibility.Visible;
            button_segitsegek.Visibility = Visibility.Visible;
            //button_felhasznalo_letrehozasa.Visibility = Visibility.Hidden;
            //button_biztonsagi_beallitasok.Visibility = Visibility.Hidden;
            button_a_fomenube.Visibility = Visibility.Visible;

            label_segitsegek.Visibility = Visibility.Hidden;
            border_segitsegek.Visibility = Visibility.Hidden;
            textBlock_menuleiras_segitsegek.Visibility = Visibility.Hidden;
            button_rendben.Visibility = Visibility.Hidden;
            border_takaras.Visibility = Visibility.Hidden;
        }
        //void rendelesek_megjelenit_gombok_elrejt()//Segítség Rendelések előhívása,gombok elrejtése,hozzá tartozó elemek megjelenítése.
        //{
        //    button_fomenu.Visibility = Visibility.Hidden;
        //    button_rendelesek.Visibility = Visibility.Hidden;
        //    button_modositasok.Visibility = Visibility.Hidden;
        //    button_etlap.Visibility = Visibility.Hidden;
        //    button_program_bezarasa.Visibility = Visibility.Hidden;
        //    button_bekijelentkezes.Visibility = Visibility.Hidden;
        //    button_visszajelzes.Visibility = Visibility.Hidden;
        //    button_programrol.Visibility = Visibility.Hidden;
        //    button_etlapmodositasa.Visibility = Visibility.Hidden;
        //    button_feltethozzaadasa.Visibility = Visibility.Hidden;
        //    button_feltetmodositasa.Visibility = Visibility.Hidden;
        //    button_ujtermek.Visibility = Visibility.Hidden;
        //    button_segitsegek.Visibility = Visibility.Hidden;
        //    //button_felhasznalo_letrehozasa.Visibility = Visibility.Hidden;
        //    //button_biztonsagi_beallitasok.Visibility = Visibility.Hidden;
        //    button_a_fomenube.Visibility = Visibility.Hidden;

        //    label_rendelesek.Visibility = Visibility.Visible;
        //    textBlock_menuleiras_rendelsek.Visibility = Visibility.Visible;
        //    border_rendelesek.Visibility = Visibility.Visible;
        //    button_rendben.Visibility = Visibility.Visible;
        //    border_takaras.Visibility = Visibility.Visible;
        //}
        //void rendelesek_elrejt_gombok_megjelenit()//Segítség Rendelések elrejtése,gombok meglenítése,hozzá tartozó elemek elrejtése.
        //{
        //    button_fomenu.Visibility = Visibility.Visible;
        //    button_rendelesek.Visibility = Visibility.Visible;
        //    button_modositasok.Visibility = Visibility.Visible;
        //    button_etlap.Visibility = Visibility.Visible;
        //    button_program_bezarasa.Visibility = Visibility.Visible;
        //    button_bekijelentkezes.Visibility = Visibility.Visible;
        //    button_visszajelzes.Visibility = Visibility.Visible;
        //    button_programrol.Visibility = Visibility.Visible;
        //    button_etlapmodositasa.Visibility = Visibility.Visible;
        //    button_feltethozzaadasa.Visibility = Visibility.Visible;
        //    button_feltetmodositasa.Visibility = Visibility.Visible;
        //    button_ujtermek.Visibility = Visibility.Visible;
        //    button_segitsegek.Visibility = Visibility.Visible;
        //    //button_felhasznalo_letrehozasa.Visibility = Visibility.Visible;
        //    //button_biztonsagi_beallitasok.Visibility = Visibility.Visible;
        //    button_a_fomenube.Visibility = Visibility.Visible;

        //    label_rendelesek.Visibility = Visibility.Hidden;
        //    textBlock_menuleiras_rendelsek.Visibility = Visibility.Hidden;
        //    border_rendelesek.Visibility = Visibility.Hidden;
        //    button_rendben.Visibility = Visibility.Hidden;
        //    border_takaras.Visibility = Visibility.Hidden;
        //}
        void modositasok_megjelenit_gombok_elrejt() //Segítség Módosítáasok előhívása,gombok elrejtése,hozzá tartozó elemek megjelenítése.
        {
            button_fomenu.Visibility = Visibility.Hidden;
            //button_rendelesek.Visibility = Visibility.Hidden;
            button_modositasok.Visibility = Visibility.Hidden;
            button_etlap.Visibility = Visibility.Hidden;
            button_program_bezarasa.Visibility = Visibility.Hidden;
            button_bekijelentkezes.Visibility = Visibility.Hidden;
            button_visszajelzes.Visibility = Visibility.Hidden;
            button_programrol.Visibility = Visibility.Hidden;
            button_etlapmodositasa.Visibility = Visibility.Hidden;
            button_feltethozzaadasa.Visibility = Visibility.Hidden;
            button_feltetmodositasa.Visibility = Visibility.Hidden;
            button_ujtermek.Visibility = Visibility.Hidden;
            button_segitsegek.Visibility = Visibility.Hidden;
            //button_felhasznalo_letrehozasa.Visibility = Visibility.Hidden;
            //button_biztonsagi_beallitasok.Visibility = Visibility.Hidden;
            button_a_fomenube.Visibility = Visibility.Hidden;

            label_modositasok.Visibility = Visibility.Visible;
            textBlock_menuleiras_modositasok.Visibility = Visibility.Visible;
            border_fomenu.Visibility = Visibility.Visible;
            button_rendben.Visibility = Visibility.Visible;
            border_takaras.Visibility = Visibility.Visible;
        }
        void modositasok_elrejt_gombok_megjelenit() //Segítség Módosíások elrejtése,gombok meglenítése,hozzá tartozó elemek elrejtése.
        {
            button_fomenu.Visibility = Visibility.Visible;
            //button_rendelesek.Visibility = Visibility.Visible;
            button_modositasok.Visibility = Visibility.Visible;
            button_etlap.Visibility = Visibility.Visible;
            button_program_bezarasa.Visibility = Visibility.Visible;
            button_bekijelentkezes.Visibility = Visibility.Visible;
            button_visszajelzes.Visibility = Visibility.Visible;
            button_programrol.Visibility = Visibility.Visible;
            button_etlapmodositasa.Visibility = Visibility.Visible;
            button_feltethozzaadasa.Visibility = Visibility.Visible;
            button_feltetmodositasa.Visibility = Visibility.Visible;
            button_ujtermek.Visibility = Visibility.Visible;
            button_segitsegek.Visibility = Visibility.Visible;
            //button_felhasznalo_letrehozasa.Visibility = Visibility.Visible;
            //button_biztonsagi_beallitasok.Visibility = Visibility.Visible;
            button_a_fomenube.Visibility = Visibility.Visible;

            label_modositasok.Visibility = Visibility.Hidden;
            textBlock_menuleiras_modositasok.Visibility = Visibility.Hidden;
            border_fomenu.Visibility = Visibility.Hidden;
            button_rendben.Visibility = Visibility.Hidden;
            border_takaras.Visibility = Visibility.Hidden;
        }
        void etlap_megjelenit_gombok_elrejt()//Segítség az Étlap bezárásának előhívása,gombok elrejtése, hozzá tartozó elemek megjelenítése.
        {
            button_fomenu.Visibility = Visibility.Hidden;
            //button_rendelesek.Visibility = Visibility.Hidden;
            button_modositasok.Visibility = Visibility.Hidden;
            button_etlap.Visibility = Visibility.Hidden;
            button_program_bezarasa.Visibility = Visibility.Hidden;
            button_bekijelentkezes.Visibility = Visibility.Hidden;
            button_visszajelzes.Visibility = Visibility.Hidden;
            button_programrol.Visibility = Visibility.Hidden;
            button_etlapmodositasa.Visibility = Visibility.Hidden;
            button_feltethozzaadasa.Visibility = Visibility.Hidden;
            button_feltetmodositasa.Visibility = Visibility.Hidden;
            button_ujtermek.Visibility = Visibility.Hidden;
            button_segitsegek.Visibility = Visibility.Hidden;
            //button_felhasznalo_letrehozasa.Visibility = Visibility.Hidden;
            //button_biztonsagi_beallitasok.Visibility = Visibility.Hidden;
            button_a_fomenube.Visibility = Visibility.Hidden;

            label_etlap.Visibility = Visibility.Visible;
            textBlock_menuleiras_etlap.Visibility = Visibility.Visible;
            border_etlap.Visibility = Visibility.Visible;
            border_etlap2.Visibility = Visibility.Visible;
            textBlock_ttsz.Visibility = Visibility.Visible;
            textBlock_emsz.Visibility = Visibility.Visible;
            textBlock_utfc.Visibility = Visibility.Visible;
            textBlock_ttc.Visibility = Visibility.Visible;
            textBlock_emc.Visibility = Visibility.Visible;
            label_fomenui.Visibility = Visibility.Visible;
            textBlock_fhm.Visibility = Visibility.Visible;
            textBlock_fsz.Visibility = Visibility.Visible;

            button_rendben.Visibility = Visibility.Visible;
            border_takaras.Visibility = Visibility.Visible;
        }
        void etlap_elrejt_gombok_megjelenit()//Segítség az Étlap elrejtése,gombok meglenítése,hozzá tartozó elemek elrejtése.
        {
            button_fomenu.Visibility = Visibility.Visible;
            //button_rendelesek.Visibility = Visibility.Visible;
            button_modositasok.Visibility = Visibility.Visible;
            button_etlap.Visibility = Visibility.Visible;
            button_program_bezarasa.Visibility = Visibility.Visible;
            button_bekijelentkezes.Visibility = Visibility.Visible;
            button_visszajelzes.Visibility = Visibility.Visible;
            button_programrol.Visibility = Visibility.Visible;
            button_etlapmodositasa.Visibility = Visibility.Visible;
            button_feltethozzaadasa.Visibility = Visibility.Visible;
            button_feltetmodositasa.Visibility = Visibility.Visible;
            button_ujtermek.Visibility = Visibility.Visible;
            button_segitsegek.Visibility = Visibility.Visible;
            //button_felhasznalo_letrehozasa.Visibility = Visibility.Visible;
            //button_biztonsagi_beallitasok.Visibility = Visibility.Visible;
            button_a_fomenube.Visibility = Visibility.Visible;

            label_etlap.Visibility = Visibility.Hidden;
            textBlock_menuleiras_etlap.Visibility = Visibility.Hidden;
            border_etlap.Visibility = Visibility.Hidden;
            border_etlap2.Visibility = Visibility.Hidden;
            textBlock_ttsz.Visibility = Visibility.Hidden;
            textBlock_emsz.Visibility = Visibility.Hidden;
            textBlock_utfc.Visibility = Visibility.Hidden;
            textBlock_ttc.Visibility = Visibility.Hidden;
            textBlock_emc.Visibility = Visibility.Hidden;
            label_fomenui.Visibility = Visibility.Hidden;
            textBlock_fhm.Visibility = Visibility.Hidden;
            textBlock_fsz.Visibility = Visibility.Hidden;

            button_rendben.Visibility = Visibility.Hidden;
            border_takaras.Visibility = Visibility.Hidden;
        } 
        void programbezar_megjelenit_gombok_elrejt() //Segítség /Program bezár/ előhívása, gombok elrejtése, hozzá tartozó elemek megjelenítése.
        {
            button_fomenu.Visibility = Visibility.Hidden;
            //button_rendelesek.Visibility = Visibility.Hidden;
            button_modositasok.Visibility = Visibility.Hidden;
            button_etlap.Visibility = Visibility.Hidden;
            button_program_bezarasa.Visibility = Visibility.Hidden;
            button_bekijelentkezes.Visibility = Visibility.Hidden;
            button_visszajelzes.Visibility = Visibility.Hidden;
            button_programrol.Visibility = Visibility.Hidden;
            button_etlapmodositasa.Visibility = Visibility.Hidden;
            button_feltethozzaadasa.Visibility = Visibility.Hidden;
            button_feltetmodositasa.Visibility = Visibility.Hidden;
            button_ujtermek.Visibility = Visibility.Hidden;
            button_segitsegek.Visibility = Visibility.Hidden;
            //button_felhasznalo_letrehozasa.Visibility = Visibility.Hidden;
            //button_biztonsagi_beallitasok.Visibility = Visibility.Hidden;
            button_a_fomenube.Visibility = Visibility.Hidden;

            label_pbezaras.Visibility = Visibility.Visible;
            border_pbezaras.Visibility = Visibility.Visible;
            border_pbezaras2.Visibility = Visibility.Visible;
            textBlock_pbezaras.Visibility = Visibility.Visible; 

            button_rendben.Visibility = Visibility.Visible;
            border_takaras.Visibility = Visibility.Visible;
        }    
        void programbezar_elrejt_gombok_elrejt()//Segítség a Program  bezár/ elrejtése,gombok meglenítése,hozzá tartozó elemek elrejtése.
        {
            button_fomenu.Visibility = Visibility.Visible;
            //button_rendelesek.Visibility = Visibility.Visible;
            button_modositasok.Visibility = Visibility.Visible;
            button_etlap.Visibility = Visibility.Visible;
            button_program_bezarasa.Visibility = Visibility.Visible;
            button_bekijelentkezes.Visibility = Visibility.Visible;
            button_visszajelzes.Visibility = Visibility.Visible;
            button_programrol.Visibility = Visibility.Visible;
            button_etlapmodositasa.Visibility = Visibility.Visible;
            button_feltethozzaadasa.Visibility = Visibility.Visible;
            button_feltetmodositasa.Visibility = Visibility.Visible;
            button_ujtermek.Visibility = Visibility.Visible;
            button_segitsegek.Visibility = Visibility.Visible;
            //button_felhasznalo_letrehozasa.Visibility = Visibility.Visible;
            //button_biztonsagi_beallitasok.Visibility = Visibility.Visible;
            button_a_fomenube.Visibility = Visibility.Visible;

            label_pbezaras.Visibility = Visibility.Hidden;
            border_pbezaras.Visibility = Visibility.Hidden;
            border_pbezaras2.Visibility = Visibility.Hidden;
            textBlock_pbezaras.Visibility = Visibility.Hidden;

            button_rendben.Visibility = Visibility.Hidden;
            border_takaras.Visibility = Visibility.Hidden;
        }
        //void felhasznaloletrehoz_megjelenit_gombok_elrejt() //Segítség Felhasználó Létrehozása előhívása, gombok elrejtése, hozzá tartozó elemek megjelenítése.
        //{
        //    button_fomenu.Visibility = Visibility.Hidden;
        //    button_rendelesek.Visibility = Visibility.Hidden;
        //    button_modositasok.Visibility = Visibility.Hidden;
        //    button_etlap.Visibility = Visibility.Hidden;
        //    button_program_bezarasa.Visibility = Visibility.Hidden;
        //    button_bekijelentkezes.Visibility = Visibility.Hidden;
        //    button_visszajelzes.Visibility = Visibility.Hidden;
        //    button_programrol.Visibility = Visibility.Hidden;
        //    button_felhasznalo_letrehozasa.Visibility = Visibility.Hidden;
        //    button_biztonsagi_beallitasok.Visibility = Visibility.Hidden;
        //    button_a_fomenube.Visibility = Visibility.Hidden;

        //    label_fnev.Visibility = Visibility.Visible;
        //    border_fnev.Visibility = Visibility.Visible;
        //    border_fnev2.Visibility = Visibility.Visible;
        //    textBlock_fnev.Visibility = Visibility.Visible;

        //    button_rendben.Visibility = Visibility.Visible;
        //    border_takaras.Visibility = Visibility.Visible;
        //}
        //void felhasznaloletrehoz_gombok_elrejt()//Segítség a Felhasználó Létrehozása elrejtése,gombok meglenítése,hozzá tartozó elemek elrejtése.
        //{
        //    button_fomenu.Visibility = Visibility.Visible;
        //    button_rendelesek.Visibility = Visibility.Visible;
        //    button_modositasok.Visibility = Visibility.Visible;
        //    button_etlap.Visibility = Visibility.Visible;
        //    button_program_bezarasa.Visibility = Visibility.Visible;
        //    button_bekijelentkezes.Visibility = Visibility.Visible;
        //    button_visszajelzes.Visibility = Visibility.Visible;
        //    button_programrol.Visibility = Visibility.Visible;
        //    button_felhasznalo_letrehozasa.Visibility = Visibility.Visible;
        //    button_biztonsagi_beallitasok.Visibility = Visibility.Visible;
        //    button_a_fomenube.Visibility = Visibility.Visible;

        //    label_fnev.Visibility = Visibility.Hidden;
        //    border_fnev.Visibility = Visibility.Hidden;
        //    border_fnev2.Visibility = Visibility.Hidden;
        //    textBlock_fnev.Visibility = Visibility.Hidden;

        //    button_rendben.Visibility = Visibility.Hidden;
        //    border_takaras.Visibility = Visibility.Hidden;
        //}
        void visszajelzes_megjelenit_gombok_elrejt() //Segítség Visszajelzés előhívása,gombok elrejtése,hozzá tartozó elemek megjelenítése.
        {

            button_fomenu.Visibility = Visibility.Hidden;
            //button_rendelesek.Visibility = Visibility.Hidden;
            button_modositasok.Visibility = Visibility.Hidden;
            button_etlap.Visibility = Visibility.Hidden;
            button_program_bezarasa.Visibility = Visibility.Hidden;
            button_bekijelentkezes.Visibility = Visibility.Hidden;
            button_visszajelzes.Visibility = Visibility.Hidden;
            button_programrol.Visibility = Visibility.Hidden;
            button_etlapmodositasa.Visibility = Visibility.Hidden;
            button_feltethozzaadasa.Visibility = Visibility.Hidden;
            button_feltetmodositasa.Visibility = Visibility.Hidden;
            button_ujtermek.Visibility = Visibility.Hidden;
            button_segitsegek.Visibility = Visibility.Hidden;
            //button_felhasznalo_letrehozasa.Visibility = Visibility.Hidden;
            //button_biztonsagi_beallitasok.Visibility = Visibility.Hidden;
            button_a_fomenube.Visibility = Visibility.Hidden;

            label_visszajelzes.Visibility = Visibility.Visible;
            border_visszajelzes.Visibility = Visibility.Visible;
            border_visszajelzes2.Visibility = Visibility.Visible;
            textBlock_visszajelzes.Visibility = Visibility.Visible;
            textBlock_visszajelzes2.Visibility = Visibility.Visible;
            //textBox_visszajelzesbox.Visibility = Visibility.Visible;
            button_rendben.Visibility = Visibility.Visible;
            //button_kuldes.Visibility = Visibility.Visible;

            border_takaras.Visibility = Visibility.Visible;
        }
        void visszajelzes_elrejt_gombok_megjelenit() //Segítség Visszajelzés elrejtése,gombok meglenítése,hozzá tartozó elemek elrejtése.
        {
            button_fomenu.Visibility = Visibility.Visible;
            //button_rendelesek.Visibility = Visibility.Visible;
            button_modositasok.Visibility = Visibility.Visible;
            button_etlap.Visibility = Visibility.Visible;
            button_program_bezarasa.Visibility = Visibility.Visible;
            button_bekijelentkezes.Visibility = Visibility.Visible;
            button_visszajelzes.Visibility = Visibility.Visible;
            button_programrol.Visibility = Visibility.Visible;
            button_segitsegek.Visibility = Visibility.Visible;
            //button_felhasznalo_letrehozasa.Visibility = Visibility.Visible;
            //button_biztonsagi_beallitasok.Visibility = Visibility.Visible;
            button_a_fomenube.Visibility = Visibility.Visible;
            button_etlapmodositasa.Visibility = Visibility.Visible;
            button_feltethozzaadasa.Visibility = Visibility.Visible;
            button_feltetmodositasa.Visibility = Visibility.Visible;
            button_ujtermek.Visibility = Visibility.Visible;


            label_visszajelzes.Visibility = Visibility.Hidden;
            border_visszajelzes.Visibility = Visibility.Hidden;
            border_visszajelzes2.Visibility = Visibility.Hidden;
            textBlock_visszajelzes.Visibility = Visibility.Hidden;
            textBlock_visszajelzes2.Visibility = Visibility.Hidden;
            //textBox_visszajelzesbox.Visibility = Visibility.Hidden;
            button_rendben.Visibility = Visibility.Hidden;
            //button_kuldes.Visibility = Visibility.Hidden;

            border_takaras.Visibility = Visibility.Hidden;
        }
        void bekijelentkezes_megjelenit_gombok_elrejt() //Segítség Bejelentkezés előhívása,gombok elrejtése,hozzá tartozó elemek megjelenítése.
        {
            button_fomenu.Visibility = Visibility.Hidden;
            //button_rendelesek.Visibility = Visibility.Hidden;
            button_modositasok.Visibility = Visibility.Hidden;
            button_etlap.Visibility = Visibility.Hidden;
            button_program_bezarasa.Visibility = Visibility.Hidden;
            button_visszajelzes.Visibility = Visibility.Hidden;
            button_programrol.Visibility = Visibility.Hidden;
            button_bekijelentkezes.Visibility = Visibility.Hidden;
            button_etlapmodositasa.Visibility = Visibility.Hidden;
            button_feltethozzaadasa.Visibility = Visibility.Hidden;
            button_feltetmodositasa.Visibility = Visibility.Hidden;
            button_ujtermek.Visibility = Visibility.Hidden;
            button_segitsegek.Visibility = Visibility.Hidden;
            //button_felhasznalo_letrehozasa.Visibility = Visibility.Hidden;
            //button_biztonsagi_beallitasok.Visibility = Visibility.Hidden;
            button_a_fomenube.Visibility = Visibility.Hidden;


            label_be_kijelentkezes.Visibility = Visibility.Visible;
            label_bejelentkezes.Visibility = Visibility.Visible;
            label_kijelentkezes.Visibility = Visibility.Visible;
            label_bejelentkezes.Visibility = Visibility.Visible;
            border_bejelentkezes.Visibility = Visibility.Visible;
            border_bejelentkezes2.Visibility = Visibility.Visible;
            textBlock_bejelentkezes.Visibility = Visibility.Visible;
            textBlock_kijelentkezes.Visibility = Visibility.Visible;

            button_rendben.Visibility = Visibility.Visible;
            border_takaras.Visibility = Visibility.Visible;
        }
        void bekijelentkezes_elrejt_gombok_megjelenit() //Segítség bejelentkezés elrejtése,gombok meglenítése,hozzá tartozó elemek elrejtése.
        {
            button_fomenu.Visibility = Visibility.Visible;
            //button_rendelesek.Visibility = Visibility.Visible;
            button_modositasok.Visibility = Visibility.Visible;
            button_etlap.Visibility = Visibility.Visible;
            button_program_bezarasa.Visibility = Visibility.Visible;
            button_bekijelentkezes.Visibility = Visibility.Visible;
            button_visszajelzes.Visibility = Visibility.Visible;
            button_programrol.Visibility = Visibility.Visible;
            button_etlapmodositasa.Visibility = Visibility.Visible;
            button_feltethozzaadasa.Visibility = Visibility.Visible;
            button_feltetmodositasa.Visibility = Visibility.Visible;
            button_ujtermek.Visibility = Visibility.Visible;
            button_segitsegek.Visibility = Visibility.Visible;
            //button_felhasznalo_letrehozasa.Visibility = Visibility.Visible;
            //button_biztonsagi_beallitasok.Visibility = Visibility.Visible;
            button_a_fomenube.Visibility = Visibility.Visible;



            label_be_kijelentkezes.Visibility = Visibility.Hidden;
            label_bejelentkezes.Visibility = Visibility.Hidden;
            label_kijelentkezes.Visibility = Visibility.Hidden;          
            border_bejelentkezes.Visibility = Visibility.Hidden;
            border_bejelentkezes2.Visibility = Visibility.Hidden;
            textBlock_bejelentkezes.Visibility = Visibility.Hidden;
            textBlock_kijelentkezes.Visibility = Visibility.Hidden;

            button_rendben.Visibility = Visibility.Hidden;
            border_takaras.Visibility = Visibility.Hidden;
        }
        
        void aprogramrol_megjelenit_gombok_elrejt() //Segítség A programról előhívása,gombok elrejtése,hozzá tartozó elemek megjelenítése.
        {
            button_fomenu.Visibility = Visibility.Hidden;
            //button_rendelesek.Visibility = Visibility.Hidden;
            button_modositasok.Visibility = Visibility.Hidden;
            button_etlap.Visibility = Visibility.Hidden;
            button_program_bezarasa.Visibility = Visibility.Hidden;
            button_bekijelentkezes.Visibility = Visibility.Hidden;
            button_visszajelzes.Visibility = Visibility.Hidden;
            button_programrol.Visibility = Visibility.Hidden;
            //button_felhasznalo_letrehozasa.Visibility = Visibility.Hidden;
            //button_biztonsagi_beallitasok.Visibility = Visibility.Hidden;
            button_a_fomenube.Visibility = Visibility.Hidden;
            button_segitsegek.Visibility = Visibility.Hidden;
            button_etlapmodositasa.Visibility = Visibility.Hidden;
            button_feltethozzaadasa.Visibility = Visibility.Hidden;
            button_feltetmodositasa.Visibility = Visibility.Hidden;
            button_ujtermek.Visibility = Visibility.Hidden;


            button_rendben.Visibility = Visibility.Visible;

            label_pbezar.Visibility = Visibility.Visible;
            border_pbezar.Visibility = Visibility.Visible;
            border_pbezar2.Visibility = Visibility.Visible;
            textBlock_pbezar.Visibility = Visibility.Visible;
            textBlock_pbezar2.Visibility = Visibility.Visible;          


            border_takaras.Visibility = Visibility.Visible;
        }
        void aprogramrol_elrejt_gombok_megjelenit() //Segítség A programról elrejtése,gombok meglenítése,hozzá tartozó elemek elrejtése.
        {
            button_fomenu.Visibility = Visibility.Visible;
            //button_rendelesek.Visibility = Visibility.Visible;
            button_modositasok.Visibility = Visibility.Visible;
            button_etlap.Visibility = Visibility.Visible;
            button_program_bezarasa.Visibility = Visibility.Visible;
            button_bekijelentkezes.Visibility = Visibility.Visible;
            button_visszajelzes.Visibility = Visibility.Visible;
            button_programrol.Visibility = Visibility.Visible;
            //button_felhasznalo_letrehozasa.Visibility = Visibility.Visible;
            //button_biztonsagi_beallitasok.Visibility = Visibility.Visible;
            button_a_fomenube.Visibility = Visibility.Visible;
            button_etlapmodositasa.Visibility = Visibility.Hidden;
            button_feltethozzaadasa.Visibility = Visibility.Hidden;
            button_feltetmodositasa.Visibility = Visibility.Hidden;
            button_ujtermek.Visibility = Visibility.Hidden;
            button_rendben.Visibility = Visibility.Hidden;
            button_segitsegek.Visibility = Visibility.Hidden;

            label_pbezar.Visibility = Visibility.Hidden;
            border_pbezar.Visibility = Visibility.Hidden;
            border_pbezar2.Visibility = Visibility.Hidden;
            textBlock_pbezar.Visibility = Visibility.Hidden;
            textBlock_pbezar2.Visibility = Visibility.Hidden;


            border_takaras.Visibility = Visibility.Hidden;
        }
        void ujtermek_megjelenit_gombok_elrejt() //Segítség Az Új Termék előhívása,gombok elrejtése,hozzá tartozó elemek megjelenítése.
        {
            button_fomenu.Visibility = Visibility.Hidden;
            //button_rendelesek.Visibility = Visibility.Hidden;
            button_modositasok.Visibility = Visibility.Hidden;
            button_etlap.Visibility = Visibility.Hidden;
            button_program_bezarasa.Visibility = Visibility.Hidden;
            button_bekijelentkezes.Visibility = Visibility.Hidden;
            button_visszajelzes.Visibility = Visibility.Hidden;
            button_programrol.Visibility = Visibility.Hidden;
            //button_felhasznalo_letrehozasa.Visibility = Visibility.Hidden;
            //button_biztonsagi_beallitasok.Visibility = Visibility.Hidden;
            button_a_fomenube.Visibility = Visibility.Hidden;
            button_etlapmodositasa.Visibility = Visibility.Hidden;
            button_feltethozzaadasa.Visibility = Visibility.Hidden;
            button_feltetmodositasa.Visibility = Visibility.Hidden;
            button_ujtermek.Visibility = Visibility.Hidden;
            button_segitsegek.Visibility = Visibility.Hidden;

            button_rendben.Visibility = Visibility.Visible;

            label_ujtermek.Visibility = Visibility.Visible;
            border_ujtermek.Visibility = Visibility.Visible;
            border_ujtermek2.Visibility = Visibility.Visible;
            textBlock_ujtermek.Visibility = Visibility.Visible;
            textBlock_ujtermek2.Visibility = Visibility.Visible;


            border_takaras.Visibility = Visibility.Visible;
        }

        void ujtermek_elrejt_gombok_megjelenit() //Segítség Az Újtermék elrejtése,gombok meglenítése,hozzá tartozó elemek elrejtése.
        {
            button_fomenu.Visibility = Visibility.Visible;
            //button_rendelesek.Visibility = Visibility.Visible;
            button_modositasok.Visibility = Visibility.Visible;
            button_etlap.Visibility = Visibility.Visible;
            button_program_bezarasa.Visibility = Visibility.Visible;
            button_bekijelentkezes.Visibility = Visibility.Visible;
            button_visszajelzes.Visibility = Visibility.Visible;
            button_programrol.Visibility = Visibility.Visible;
            //button_felhasznalo_letrehozasa.Visibility = Visibility.Visible;
            //button_biztonsagi_beallitasok.Visibility = Visibility.Visible;
            button_a_fomenube.Visibility = Visibility.Visible;
            button_etlapmodositasa.Visibility = Visibility.Visible;
            button_feltethozzaadasa.Visibility = Visibility.Visible;
            button_feltetmodositasa.Visibility = Visibility.Visible;
            button_ujtermek.Visibility = Visibility.Visible;
            button_segitsegek.Visibility = Visibility.Visible;



            button_rendben.Visibility = Visibility.Hidden;

            label_ujtermek.Visibility = Visibility.Hidden;
            border_ujtermek.Visibility = Visibility.Hidden;
            border_ujtermek2.Visibility = Visibility.Hidden;
            textBlock_ujtermek.Visibility = Visibility.Hidden;
            textBlock_ujtermek2.Visibility = Visibility.Hidden;


            border_takaras.Visibility = Visibility.Hidden;
        }
        void etlapmodositasa_megjelenit_gombok_elrejt() //Segítség Az Étlap Módosításának előhívása,gombok elrejtése,hozzá tartozó elemek megjelenítése.
        {
            button_fomenu.Visibility = Visibility.Hidden;
            //button_rendelesek.Visibility = Visibility.Hidden;
            button_modositasok.Visibility = Visibility.Hidden;
            button_etlap.Visibility = Visibility.Hidden;
            button_program_bezarasa.Visibility = Visibility.Hidden;
            button_bekijelentkezes.Visibility = Visibility.Hidden;
            button_visszajelzes.Visibility = Visibility.Hidden;
            button_programrol.Visibility = Visibility.Hidden;
            //button_felhasznalo_letrehozasa.Visibility = Visibility.Hidden;
            //button_biztonsagi_beallitasok.Visibility = Visibility.Hidden;
            button_a_fomenube.Visibility = Visibility.Hidden;
            button_etlapmodositasa.Visibility = Visibility.Hidden;
            button_feltethozzaadasa.Visibility = Visibility.Hidden;
            button_feltetmodositasa.Visibility = Visibility.Hidden;
            button_ujtermek.Visibility = Visibility.Hidden;
            button_segitsegek.Visibility = Visibility.Hidden;




            button_rendben.Visibility = Visibility.Visible;


            label_etlapmodositas.Visibility = Visibility.Visible;
            border_etlapmodositas.Visibility = Visibility.Visible;
            border_etlapmodositas2.Visibility = Visibility.Visible;
            textBlock_etlapmodositas.Visibility = Visibility.Visible;
            textBlock_etlapmodositas2.Visibility = Visibility.Visible;


            border_takaras.Visibility = Visibility.Visible;
        }

        void etlapmodositasa_elrejt_gombok_megjelenit() //Segítség Az ÉtlapMódosítása elrejtése,gombok meglenítése,hozzá tartozó elemek elrejtése.
        {
            button_fomenu.Visibility = Visibility.Visible;
            //button_rendelesek.Visibility = Visibility.Visible;
            button_modositasok.Visibility = Visibility.Visible;
            button_etlap.Visibility = Visibility.Visible;
            button_program_bezarasa.Visibility = Visibility.Visible;
            button_bekijelentkezes.Visibility = Visibility.Visible;
            button_visszajelzes.Visibility = Visibility.Visible;
            button_programrol.Visibility = Visibility.Visible;
            //button_felhasznalo_letrehozasa.Visibility = Visibility.Visible;
            //button_biztonsagi_beallitasok.Visibility = Visibility.Visible;
            button_a_fomenube.Visibility = Visibility.Visible;
            button_etlapmodositasa.Visibility = Visibility.Visible;
            button_feltethozzaadasa.Visibility = Visibility.Visible;
            button_feltetmodositasa.Visibility = Visibility.Visible;
            button_segitsegek.Visibility = Visibility.Visible;
            button_ujtermek.Visibility = Visibility.Visible;



            button_rendben.Visibility = Visibility.Hidden;

            label_etlapmodositas.Visibility = Visibility.Hidden;
            border_etlapmodositas.Visibility = Visibility.Hidden;
            border_etlapmodositas2.Visibility = Visibility.Hidden;
            textBlock_etlapmodositas.Visibility = Visibility.Hidden;
            textBlock_etlapmodositas2.Visibility = Visibility.Hidden;


            border_takaras.Visibility = Visibility.Hidden;
        }
        //void biztonsagibeallitasok_megjelenit_gombok_elrejt() //Segítség Biztonsági Beállítások előhívása,gombok elrejtése,hozzá tartozó elemek megjelenítése.
        //{
        //    button_fomenu.Visibility = Visibility.Hidden;
        //    button_rendelesek.Visibility = Visibility.Hidden;
        //    button_modositasok.Visibility = Visibility.Hidden;
        //    button_etlap.Visibility = Visibility.Hidden;
        //    button_program_bezarasa.Visibility = Visibility.Hidden;
        //    button_bekijelentkezes.Visibility = Visibility.Hidden;
        //    button_visszajelzes.Visibility = Visibility.Hidden;
        //    button_programrol.Visibility = Visibility.Hidden;
        //    button_felhasznalo_letrehozasa.Visibility = Visibility.Hidden;
        //    button_biztonsagi_beallitasok.Visibility = Visibility.Hidden;
        //    button_a_fomenube.Visibility = Visibility.Hidden;

        //    button_rendben.Visibility = Visibility.Visible;
        //    border_takaras.Visibility = Visibility.Visible;


        //    label_biztbeal.Visibility = Visibility.Visible;
        //    border_biztbeal.Visibility = Visibility.Visible;
        //    border_biztbeal2.Visibility = Visibility.Visible;
        //    textBlock_biztbeal.Visibility = Visibility.Visible;
        //}
        //void biztonsagibeallitasok_elrejt_gombok_megjelenit() //Segítség Biztonsági Beállítások elrejtése,gombok meglenítése,hozzá tartozó elemek elrejtése.
        //{
        //    button_fomenu.Visibility = Visibility.Visible; 
        //    button_rendelesek.Visibility = Visibility.Visible;
        //    button_modositasok.Visibility = Visibility.Visible;
        //    button_etlap.Visibility = Visibility.Visible;
        //    button_program_bezarasa.Visibility = Visibility.Visible;
        //    button_bekijelentkezes.Visibility = Visibility.Visible;
        //    button_visszajelzes.Visibility = Visibility.Visible;
        //    button_programrol.Visibility = Visibility.Visible;
        //    button_felhasznalo_letrehozasa.Visibility = Visibility.Visible;
        //    button_biztonsagi_beallitasok.Visibility = Visibility.Visible;
        //    button_a_fomenube.Visibility = Visibility.Visible;

        //    button_rendben.Visibility = Visibility.Hidden;
        //    border_takaras.Visibility = Visibility.Hidden;


        //    label_biztbeal.Visibility = Visibility.Hidden;
        //    border_biztbeal.Visibility = Visibility.Hidden;
        //    border_biztbeal2.Visibility = Visibility.Hidden;
        //    textBlock_biztbeal.Visibility = Visibility.Hidden;
        //}
        void feltethozzaadasa_megjelenit_gombok_elrejt() //Segítség A Feltét Hozzáadásának előhívása,gombok elrejtése,hozzá tartozó elemek megjelenítése.
        {
            button_fomenu.Visibility = Visibility.Hidden;
            //button_rendelesek.Visibility = Visibility.Hidden;
            button_modositasok.Visibility = Visibility.Hidden;
            button_etlap.Visibility = Visibility.Hidden;
            button_program_bezarasa.Visibility = Visibility.Hidden;
            button_visszajelzes.Visibility = Visibility.Hidden;
            button_bekijelentkezes.Visibility = Visibility.Hidden;
            button_programrol.Visibility = Visibility.Hidden;
            button_ujtermek.Visibility = Visibility.Hidden;
            button_segitsegek.Visibility = Visibility.Hidden;
            button_etlapmodositasa.Visibility = Visibility.Hidden;
            button_feltethozzaadasa.Visibility = Visibility.Hidden;
            button_feltetmodositasa.Visibility = Visibility.Hidden;
            button_a_fomenube.Visibility = Visibility.Hidden;
            //button_felhasznalo_letrehozasa.Visibility = Visibility.Hidden;
            //button_biztonsagi_beallitasok.Visibility = Visibility.Hidden;



            button_rendben.Visibility = Visibility.Visible;

            label_feltethozzadasa.Visibility = Visibility.Visible;
            border_feltethozzadasa.Visibility = Visibility.Visible;
            border_feltethozzadasa2.Visibility = Visibility.Visible;
            textBlock_feltethozzadasa.Visibility = Visibility.Visible;
            textBlock_feltethozzadasa2.Visibility = Visibility.Visible;


            border_takaras.Visibility = Visibility.Visible;
        }

        void feltethozzaadasa_elrejt_gombok_megjelenit() //Segítség A Feltét Hozzáadásának elrejtése,gombok meglenítése,hozzá tartozó elemek elrejtése.
        {
            button_fomenu.Visibility = Visibility.Visible;
            //button_rendelesek.Visibility = Visibility.Visible;
            button_modositasok.Visibility = Visibility.Visible;
            button_etlap.Visibility = Visibility.Visible;
            button_program_bezarasa.Visibility = Visibility.Visible;
            button_visszajelzes.Visibility = Visibility.Visible;
            button_bekijelentkezes.Visibility = Visibility.Visible;
            button_programrol.Visibility = Visibility.Visible;
            button_ujtermek.Visibility = Visibility.Visible;
            button_etlapmodositasa.Visibility = Visibility.Visible;
            button_feltethozzaadasa.Visibility = Visibility.Visible;
            button_feltetmodositasa.Visibility = Visibility.Visible;
            button_segitsegek.Visibility = Visibility.Visible;
            button_a_fomenube.Visibility = Visibility.Visible;
            //button_felhasznalo_letrehozasa.Visibility = Visibility.Hidden;
            //button_biztonsagi_beallitasok.Visibility = Visibility.Hidden;



            button_rendben.Visibility = Visibility.Hidden;

            label_feltethozzadasa.Visibility = Visibility.Hidden;
            border_feltethozzadasa.Visibility = Visibility.Hidden;
            border_feltethozzadasa2.Visibility = Visibility.Hidden;
            textBlock_feltethozzadasa.Visibility = Visibility.Hidden;
            textBlock_feltethozzadasa2.Visibility = Visibility.Hidden;


            border_takaras.Visibility = Visibility.Hidden;
        }

        void feltetmodositasa_megjelenit_gombok_elrejt() //Segítség A Feltét módosításának előhívása,gombok elrejtése,hozzá tartozó elemek megjelenítése.
        {
            button_fomenu.Visibility = Visibility.Hidden;
            //button_rendelesek.Visibility = Visibility.Hidden;
            button_modositasok.Visibility = Visibility.Hidden;
            button_etlap.Visibility = Visibility.Hidden;
            button_program_bezarasa.Visibility = Visibility.Hidden;
            button_visszajelzes.Visibility = Visibility.Hidden;
            button_bekijelentkezes.Visibility = Visibility.Hidden;
            button_programrol.Visibility = Visibility.Hidden;
            button_ujtermek.Visibility = Visibility.Hidden;
            button_etlapmodositasa.Visibility = Visibility.Hidden;
            button_feltethozzaadasa.Visibility = Visibility.Hidden;
            button_feltetmodositasa.Visibility = Visibility.Hidden;
            button_segitsegek.Visibility = Visibility.Hidden;
            button_a_fomenube.Visibility = Visibility.Hidden;
            //button_felhasznalo_letrehozasa.Visibility = Visibility.Hidden;
            //button_biztonsagi_beallitasok.Visibility = Visibility.Hidden;



            button_rendben.Visibility = Visibility.Visible;

            label_feltetmodositasa.Visibility = Visibility.Visible;
            border_feltetmodositasa.Visibility = Visibility.Visible;
            border_feltetmodositasa2.Visibility = Visibility.Visible;
            textBlock_feltetmodositasa.Visibility = Visibility.Visible;
            textBlock_feltetmodositasa2.Visibility = Visibility.Visible;


            border_takaras.Visibility = Visibility.Visible;
        }
        void feltetmodositasa_elrejt_gombok_megjelenit() //Segítség A Feltét módosításának elrejtése,gombok meglenítése,hozzá tartozó elemek elrejtése.
        {
            button_fomenu.Visibility = Visibility.Visible;
            //button_rendelesek.Visibility = Visibility.Visible;
            button_modositasok.Visibility = Visibility.Visible;
            button_etlap.Visibility = Visibility.Visible;
            button_program_bezarasa.Visibility = Visibility.Visible;
            button_visszajelzes.Visibility = Visibility.Visible;
            button_bekijelentkezes.Visibility = Visibility.Visible;
            button_programrol.Visibility = Visibility.Visible;
            button_a_fomenube.Visibility = Visibility.Visible;
            button_ujtermek.Visibility = Visibility.Visible;
            button_etlapmodositasa.Visibility = Visibility.Visible;
            button_feltethozzaadasa.Visibility = Visibility.Visible;
            button_feltetmodositasa.Visibility = Visibility.Visible;
            button_segitsegek.Visibility = Visibility.Visible;
            //button_felhasznalo_letrehozasa.Visibility = Visibility.Hidden;
            //button_biztonsagi_beallitasok.Visibility = Visibility.Hidden;



            button_rendben.Visibility = Visibility.Hidden;

            label_feltetmodositasa.Visibility = Visibility.Hidden;
            border_feltetmodositasa.Visibility = Visibility.Hidden;
            border_feltetmodositasa2.Visibility = Visibility.Hidden;
            textBlock_feltetmodositasa.Visibility = Visibility.Hidden;
            textBlock_feltetmodositasa2.Visibility = Visibility.Hidden;


            border_takaras.Visibility = Visibility.Hidden;
        }
        public Segitseg_fomenu()
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

        private void button_a_fomenube_Click(object sender, RoutedEventArgs e) //Vissza a Főoldalra!
        {
            Fomenu F_menu = new Fomenu();
            F_menu.Show();
            this.Close();
        }

        private void button_fomenu_Click(object sender, RoutedEventArgs e) //Segítség Főmenü megjelenítése
        {
            fomenu_megjelenit_gombok_elrejt();
        }
        private void button_segitsegek_Click(object sender, RoutedEventArgs e) //Segítség A Segítségek megjelenítése
        {
            segitsegek_megjelenit_gombok_elrejt();
        }
        //private void button_rendelesek_Click(object sender, RoutedEventArgs e) //Segítség Rendelések menü megjelenítése
        //{
        //    rendelesek_megjelenit_gombok_elrejt();
        //}

        private void button_modositasok_Click(object sender, RoutedEventArgs e) //Segítség Módosítáasok menü megjelenítése
        {
            modositasok_megjelenit_gombok_elrejt();
        } 
        private void button_etlap_Click(object sender, RoutedEventArgs e)//Segítség Étlap menü megjelenítése
        {
            etlap_megjelenit_gombok_elrejt();
        }
        private void button_program_bezarasa_Click(object sender, RoutedEventArgs e)//Segítség /program bezárása/ menü megjelenítése
        {
            programbezar_megjelenit_gombok_elrejt();
        }
        private void button_felhasznalo_letrehozasa_Click(object sender, RoutedEventArgs e) //Segítség Felhasználó létrehozása menü megjelenítése
        {
            //felhasznaloletrehoz_megjelenit_gombok_elrejt();
        }
        private void button_bekijelentkezes_Click(object sender, RoutedEventArgs e)//Segítésg a be-kijelentkezés menü megjelenítése.
        {
            bekijelentkezes_megjelenit_gombok_elrejt();
        }
        private void button_visszajelzes_Click(object sender, RoutedEventArgs e) //Segítség Visszajelzes menü megjelnítése.
        {
            visszajelzes_megjelenit_gombok_elrejt();
        }
        private void button_programrol_Click(object sender, RoutedEventArgs e)  //Segítség /A/ programról menü megjelnítése.
        {
            aprogramrol_megjelenit_gombok_elrejt();
        }
        private void button_ujtermek_Click(object sender, RoutedEventArgs e) //Segítség az Új Termék menü megjelnítése.
        {
            ujtermek_megjelenit_gombok_elrejt();
        }
        private void button_etlapmodositasa_Click(object sender, RoutedEventArgs e) //Segítség az ÉtlapMódsítása menü megjelnítése.
        {
            etlapmodositasa_megjelenit_gombok_elrejt();
        }
        private void button_feltethozzaadasa_Click(object sender, RoutedEventArgs e) //Segítség a Feltét Hozzáadása menü megjelnítése.
        {
            feltethozzaadasa_megjelenit_gombok_elrejt();
        }
        private void button_feltetmodositasa_Click(object sender, RoutedEventArgs e) //Segítség az Feltét Módosítása menü megjelnítése.
        {
            feltetmodositasa_megjelenit_gombok_elrejt();
        }
        //private void button_biztonsagi_beallitasok_Click(object sender, RoutedEventArgs e) //Segítség Biztonsági Beállítások menü megjelnítése.
        //{
        //    biztonsagibeallitasok_megjelenit_gombok_elrejt();
        //} 
        private void button_rendben_minden_Click(object sender, RoutedEventArgs e) //Elrejt a gomb megnyomasakor a felugro almenük nagy részét(fomenu,rendelesek,modositasok,etlap,
                                                                                   //programbezarasa,visszajelzes,felhasznalonevletrehoz,bekijelentkezes,aprogramrol,ujtermek,etlapmodositasa,feltethozzaadasa,biztonsagibeallitasok)
        {
            fomenu_elrejt_gombok_megjelenit();
            modositasok_elrejt_gombok_megjelenit();
            //rendelesek_elrejt_gombok_megjelenit();
            etlap_elrejt_gombok_megjelenit();
            programbezar_elrejt_gombok_elrejt();
            visszajelzes_elrejt_gombok_megjelenit();
            //felhasznaloletrehoz_gombok_elrejt();
            bekijelentkezes_elrejt_gombok_megjelenit();
            aprogramrol_elrejt_gombok_megjelenit();
            ujtermek_elrejt_gombok_megjelenit();
            etlapmodositasa_elrejt_gombok_megjelenit();
            feltethozzaadasa_elrejt_gombok_megjelenit();
            feltetmodositasa_elrejt_gombok_megjelenit();
            segitsegek_elrejt_gombok_megjelenit();


            //biztonsagibeallitasok_elrejt_gombok_megjelenit();
        }

        private void button_megsem_Click(object sender, RoutedEventArgs e) // Visszajelzés fül eltüntetése ->Vissza a Segítség menübe.
        {
            visszajelzes_elrejt_gombok_megjelenit();
        }

        private void button_kismeret_Click(object sender, RoutedEventArgs e)  //Kis Méretezés a tálcára
        {
            this.WindowState = WindowState.Minimized;

        } 
    }
}
