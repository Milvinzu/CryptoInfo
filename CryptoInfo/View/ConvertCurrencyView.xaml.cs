using CryptoInfo.ViewModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CryptoInfo.View
{
    /// <summary>
    /// Логика взаимодействия для ConvertCurrencyView.xaml
    /// </summary>
    public partial class ConvertCurrencyView : UserControl
    {
        public ConvertCurrencyView()
        {
            InitializeComponent();
        }

        private void ComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            var ComboBox = (ComboBox)sender;
            ComboBox.IsDropDownOpen = false;
            if (e.Key == Key.Enter)
            {
                var viewModel = (ConvertCurrencyViewModel)DataContext;
                viewModel.SearchListForComboBox(ComboBox);
                ComboBox.IsDropDownOpen = true;
            }
        }

        private void ConvertCoin(object sender, RoutedEventArgs e)
        {
            var textBox = CountTextBox;
            var FirstComboBox = FirstCombo;
            var SecondComboBox = SecondCombo;
            dynamic items = FirstComboBox.SelectedItem;
            dynamic it = SecondComboBox.SelectedItem;
            if (string.IsNullOrEmpty(textBox.Text) || items == null || it == null)
            {
                Error.Content = "Fill All Text Fields";
                return;
            }
            Error.Content = "";
            var viewModel = (ConvertCurrencyViewModel)DataContext;
            viewModel.SetCurrencies(items.Id, it.Id, Convert.ToDecimal(textBox.Text));
        }
    }
}
