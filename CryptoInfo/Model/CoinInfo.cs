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
        public async Task<List<Currency>> GetCoinList(int limit)
        {
            List<Currency> coinList = new List<Currency>();
            List<Market> marketass = new List<Market>();

            CoinCapAPI coinCapAPI = new CoinCapAPI();

            string coinJson = await coinCapAPI.GetCryptocurrenciesList(limit);
            dynamic currencies = JsonConvert.DeserializeObject<dynamic>(coinJson);

            foreach (var currency in currencies.data)
            {
                List<Market> currencyMarkets = new List<Market>();

                string marketJson = await coinCapAPI.GetMarketsList((currency.id).ToString());
                dynamic markets = JsonConvert.DeserializeObject(marketJson);


                List<Task> tasks = new List<Task>();
                foreach (dynamic market in markets.data)
                {
                    tasks.Add(Task.Run(async () =>
                    {

                        currencyMarkets.Add(new Market
                        {
                            ExchangeId = market.exchangeId,
                            BaseSymbol = market.baseSymbol,
                            QuoteSymbol = market.quoteSymbol,
                            PriceUsd = Convert.ToDecimal(market.PriceUsd),
                            VolumeUsd24Hr = Convert.ToDecimal(market.volumeUsd24Hr)
                        });
                    }));
                }
                await Task.WhenAll(tasks);


                var uniqueMarkets = currencyMarkets.Select(m => m.ExchangeId).Distinct().OrderBy(m => m);

                var coin = new Currency
                {
                    Name = currency.name,
                    Symbol = currency.symbol,
                    PriceUsd = currency.priceUsd,
                    VolumeUsd24Hr = currency.volumeUsd24Hr,
                    ChangePercent24Hr = currency.changePercent24Hr,
                    Market = string.Join(", ", uniqueMarkets)
                };

                coinList.Add(coin);
            }

            return coinList;
        }
    }
}

