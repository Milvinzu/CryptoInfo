using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoInfo.ViewModel
{
    class CoinInfoViewModel : ObservableObject
    {
        private ObservableCollection<Model.CoinInfo> coins;

        public CoinInfoViewModel()
        {
            LoadCoins();
        }

        private async void LoadCoins()
        {
            Model.CoinInfo coinInfo = new Model.CoinInfo();
            Coins = new ObservableCollection<Model.CoinInfo>(await coinInfo.GetCoinList(10));
        }

        public ObservableCollection<Model.CoinInfo> Coins
        {
            get { return coins; }
            set
            {
                coins = value;
                OnPropertyChanged();
            }
        }
    }
}
