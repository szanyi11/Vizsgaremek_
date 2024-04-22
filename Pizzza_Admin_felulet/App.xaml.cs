using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Pizzza_Admin_felulet
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public string beconfig()
        {
            string kapcsolat = "";
            StreamReader sr = new StreamReader("config.ini");
            kapcsolat = "";
            while (!sr.EndOfStream)
            {
                kapcsolat += sr.ReadLine();
            }
            return kapcsolat;
        }
    }
}
