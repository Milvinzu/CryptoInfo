using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoInfo.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public RelayCommand TopCryptoViewCommand { get; set; }

        public TopCrypto topCrypto { get; set; }

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
            topCrypto = new TopCrypto();

            CurrentView = topCrypto;
            CoinInfoViewModel viewModel = new CoinInfoViewModel();

            TopCryptoViewCommand = new RelayCommand(o =>
            {
                CurrentView = topCrypto;
            });
        }
    }
}
