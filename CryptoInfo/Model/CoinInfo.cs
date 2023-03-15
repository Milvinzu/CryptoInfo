using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CryptoInfo.Model
{
    class CoinInfo
    {
        public string name { get; set; }
        public string symbol { get; set; }
        public string price { get; set; }
        public string volume { get; set; }
        public string priceChangePrecent { get; set; }
        public string marketsAndPrice { get; set; }

        public async Task<List<CoinInfo>> GetCoinList(int limit)
        {
            List<CoinInfo> coinList = new List<CoinInfo>();
            CoinCapAPI coinCapAPI = new CoinCapAPI();
            string strJson = await coinCapAPI.GetCryptocurrenciesList(limit);
            dynamic coin = JsonConvert.DeserializeObject<dynamic>(strJson);

            for (int i = 0; i < limit; i++)
            {
                coinList.Add(new CoinInfo
                {
                    name = coin.data[i].name,
                    symbol = coin.data[i].symbol,
                    price = coin.data[i].priceUsd,
                    volume = coin.data[i].volumeUsd24Hr,
                    priceChangePrecent = coin.data[i].changePercent24Hr
                });
            }

            return coinList;
        }
    }
}

