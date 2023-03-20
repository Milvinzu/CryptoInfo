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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CryptoInfo.Model;
using CryptoInfo.Resources;
using CryptoInfo.Theme;
using CryptoInfo.ViewModel;
using Microsoft.Windows.Themes;
using Newtonsoft.Json;

namespace CryptoInfo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }  

        private void Theme_Switch(object sender,RoutedEventArgs e)
        {
            if(Themes.IsChecked == false)
            {
                ThemesController.SetTheme(ThemesController.ThemeTypes.Light);
            }
            else
            {
                ThemesController.SetTheme(ThemesController.ThemeTypes.Dark);
            }
        }

        private void Lang_Switch(object sender, SelectionChangedEventArgs e)
        {
            string selected = Lang.SelectedItem.ToString().Substring(38);
            if (selected == "en-US")
            {
                LangController.SetLang(LangController.LangTypes.en_US);
            }
            else if(selected == "ua-UA")
            {
                LangController.SetLang(LangController.LangTypes.ua_UA);
            }
            else if(selected == "pl-PL")
            {
                LangController.SetLang(LangController.LangTypes.pl_PL);
            }
        }

        public void Close_App(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
