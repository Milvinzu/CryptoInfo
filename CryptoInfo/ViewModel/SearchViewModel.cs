using CryptoInfo.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoInfo.ViewModel
{
    class SearchViewModel : ObservableObject
    {
        private ObservableCollection<Model.Currency> FindCoins;
        private string _textValue = "";


        public SearchViewModel()
        {
            InfoTopTen();
        }
        
        public void SetText(string text)
        {
            _textValue = text;
            Search();
        }

        public async void InfoTopTen()
        {
            CoinInfo coinInfo = new CoinInfo();
            List<Currency> coin = await coinInfo.GetMoreInfoTopTen();
            Coins = new ObservableCollection<Currency>(coin);
        }
        public async void Search()
        {
            CoinInfo coinInfo = new CoinInfo();
            List<Currency> coin = await coinInfo.SearchCoin(_textValue);
            if(coin != null && coin.Count > 0 )
            {
                Coins = new ObservableCollection<Currency>(coin);
            }
            else
            {
                Coins = new ObservableCollection<Currency>();
                Coins.Add(new Currency { Name = "NOT FOUND" });
            }
        }

        public ObservableCollection<Model.Currency> Coins
        {
            get { return FindCoins; }
            set
            {
                FindCoins = value;
                OnPropertyChanged();
            }
        }

    }
}
