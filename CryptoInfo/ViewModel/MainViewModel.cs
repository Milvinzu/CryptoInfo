using CryptoInfo.Model;
using CryptoInfo.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CryptoInfo.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public RelayCommand TopCryptoViewCommand { get; set; }
        public RelayCommand SearchViewCommand { get; set; }
        public RelayCommand ConvertCurrencyViewCommand { get; set; }
        public RelayCommand JapaneseСandlestickСhartViewCommand { get; set; }

        public TopCryptoViewModel TopCryptoVM { get; set; }
        public SearchViewModel SearchlVM { get; set; }
        public ConvertCurrencyViewModel ConvertCurrencyVM { get; set; }
        public JapaneseСandlestickСhartViewModel JapaneseСandlestickСhartVM { get; set; }
        

        private object _currentView;

        public object  CurrentView
        {
            get { return _currentView; }
            set 
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        

        public MainViewModel() 
        {
            TopCryptoVM = new TopCryptoViewModel();
            SearchlVM = new SearchViewModel();
            ConvertCurrencyVM = new ConvertCurrencyViewModel();
            JapaneseСandlestickСhartVM = new JapaneseСandlestickСhartViewModel();

            CurrentView = TopCryptoVM;
            TopCryptoViewModel viewModel = new TopCryptoViewModel();

            TopCryptoViewCommand = new RelayCommand(o =>
            {
                CurrentView = TopCryptoVM;
            });

            SearchViewCommand= new RelayCommand(o =>
            {
                CurrentView = SearchlVM;
            });

            ConvertCurrencyViewCommand = new RelayCommand(o =>
            {
                CurrentView = ConvertCurrencyVM;
            });

            JapaneseСandlestickСhartViewCommand = new RelayCommand(o =>
            {
                CurrentView = JapaneseСandlestickСhartVM;
            });
        }
    }
}
