using CryptoInfo.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoInfo.ViewModel
{
    class TopCryptoViewModel : ObservableObject
    {
        private ObservableCollection<Model.Currency> Coins;

        public TopCryptoViewModel()
        {
            LoadCoins();
        }

        private async void LoadCoins()
        {
            CoinInfo coinInfo = new CoinInfo();
            List<Currency> CoinsList = await coinInfo.GetTopTen();
            AvailableCoins = new ObservableCollection<Currency>(CoinsList);
        }

        public ObservableCollection<Model.Currency> AvailableCoins
        {
            get { return Coins; }
            set
            {
                Coins = value;
                OnPropertyChanged();
            }
        }
    }
}
