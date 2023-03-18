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
            if (e.Key == Key.Enter)
            {
                var ComboBox = (ComboBox)sender;
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
            var viewModel = (ConvertCurrencyViewModel)DataContext;
            viewModel.SetCurrencies(items.Id, it.Id, Convert.ToDecimal(textBox.Text));
        }
    }
}
