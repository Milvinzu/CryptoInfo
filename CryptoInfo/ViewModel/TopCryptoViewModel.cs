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
        private ObservableCollection<Model.Currency> Coinsa;

        public TopCryptoViewModel()
        {
            LoadCoins();
        }

        private async void LoadCoins()
        {
            CoinInfo coinInfo = new CoinInfo();
            List<Currency> coins = await coinInfo.GetCoinList(10);
            Coins = new ObservableCollection<Currency>(coins);
        }

        public ObservableCollection<Model.Currency> Coins
        {
            get { return Coinsa; }
            set
            {
                Coinsa = value;
                OnPropertyChanged();
            }
        }
    }
}
