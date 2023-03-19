using CryptoInfo.Model;
using CryptoInfo.ViewModel;
using FancyCandles;
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
    /// Логика взаимодействия для JapaneseСandlestickСhartView.xaml
    /// </summary>
    public partial class JapaneseСandlestickСhartView : UserControl
    {


        public JapaneseСandlestickСhartView()
        {
            InitializeComponent();
        }

        public void Set_Candle_Setting(object sender, RoutedEventArgs e)
        {
            var currencyComboBox = CurrencyComboBox;
            var intervalComboBox = IntervalComboBox;
            var timeComboBox = TimeComboBox;
            dynamic items = currencyComboBox.SelectedItem;
            dynamic it = intervalComboBox.SelectedItem;
            dynamic tima = timeComboBox.SelectedItem;
            var viewModel = (JapaneseСandlestickСhartViewModel)DataContext;
            viewModel.SetCandelSetting(items.Symbol, it.Period, tima.Period);
        }
    }

}

