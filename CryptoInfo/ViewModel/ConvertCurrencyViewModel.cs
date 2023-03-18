using CryptoInfo.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CryptoInfo.ViewModel
{
    class ConvertCurrencyViewModel : ObservableObject
    {
        private decimal ConvertedCurrency;
        private string FirstCurrency;
        private string SecondCurrency;
        private decimal CountCurrency;
        private ObservableCollection<Model.Currency> FindNamesFirstComboBox;
        private ObservableCollection<Model.Currency> FindNamesSecondComboBox;
        private string _textValue = "";

        public ConvertCurrencyViewModel()
        {
            LoadCoins();
        }
        public async void SearchListForComboBox(ComboBox comboBox)
        {
            CoinInfo coinInfo = new CoinInfo();
            List<Currency> ListName = await coinInfo.SearchName(comboBox.Text);
            if (comboBox.Name == "FirstCombo")
            {
                findNamesFirstComboBox = new ObservableCollection<Currency>(ListName);
            }
            else if (comboBox.Name == "SecondCombo")
            {
                findNamesSecondComboBox = new ObservableCollection<Currency>(ListName);
            }
        }
        public void SetCurrencies(string firstCurrency, string secondCurrency, decimal countCurrency)
        {
            FirstCurrency = firstCurrency;
            SecondCurrency = secondCurrency;
            CountCurrency = countCurrency;
            LoadCoins();
        }
        private async void LoadCoins()
        {
            ConvertCurrency convertCurrency = new ConvertCurrency(FirstCurrency, SecondCurrency);
            decimal convertedCurrency = await convertCurrency.Convert(CountCurrency);
            ConvertCurrency = convertedCurrency;
        }

        public decimal ConvertCurrency
        {
            get { return ConvertedCurrency; }
            set
            {
                ConvertedCurrency = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Model.Currency> findNamesFirstComboBox
        {
            get { return FindNamesFirstComboBox; }
            set
            {
                FindNamesFirstComboBox = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Model.Currency> findNamesSecondComboBox
        {
            get { return FindNamesSecondComboBox; }
            set
            {
                FindNamesSecondComboBox = value;
                OnPropertyChanged();
            }
        }
    }
}
