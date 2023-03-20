using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;

namespace CryptoInfo.Model
{
    class CoinInfo
    {
        private readonly CoinCapAPI _coinCapAPI;

        public CoinInfo()
        {
            _coinCapAPI = new CoinCapAPI();
        }
        public async Task<List<Currency>> GetTopTen()
        {
            const int limit = 10;
            List<Currency> coinList = new List<Currency>();

            string coinJson = await _coinCapAPI.GetCryptocurrenciesList(limit);
            dynamic currencies = JsonConvert.DeserializeObject<dynamic>(coinJson);

            foreach (var currency in currencies.data)
            {
                var coin = new Currency
                {
                    Name = currency.name,
                    PriceUsd = decimal.Round((decimal?)currency.priceUsd ?? 0, 3, MidpointRounding.ToEven),
                    ChangePercent24Hr = decimal.Round((decimal?)currency?.changePercent24Hr ?? 0, 2, MidpointRounding.ToEven)
                };

                coinList.Add(coin);
            }

            return coinList;
        }

        public async Task<List<Currency>> GetMoreInfoTopTen()
        {
            const int limit = 10;
            List<Currency> coinList = new List<Currency>();

            string coinJson = await _coinCapAPI.GetCryptocurrenciesList(limit);
            dynamic currencies = JsonConvert.DeserializeObject<dynamic>(coinJson);

            foreach (var currency in currencies.data)
            {
                var currencyMarkets = new List<Market>();

                var marketJson = await _coinCapAPI.GetMarketsList(currency.id.ToString());
                dynamic markets = JsonConvert.DeserializeObject(marketJson);

                var tasks = new List<Task>();
                foreach (var market in markets.data)
                {
                    tasks.Add(Task.Run(async () =>
                    {
                        currencyMarkets.Add(new Market
                        {
                            ExchangeId = market.exchangeId,
                            PriceUsd = decimal.Round((decimal?)market?.priceUsd ?? 0, 3, MidpointRounding.ToEven)
                        });
                    }));
                }

                await Task.WhenAll(tasks);

                var coin = new Currency
                {
                    Name = currency.name,
                    Symbol = currency.symbol,
                    PriceUsd = decimal.Round((decimal?)currency.priceUsd ?? 0, 3, MidpointRounding.ToEven),
                    VolumeUsd24Hr = RoundBigMoney((decimal?)currency.volumeUsd24Hr ?? 0),
                    ChangePercent24Hr = decimal.Round((decimal?)currency?.changePercent24Hr ?? 0, 2, MidpointRounding.ToEven),
                    Market = string.Join(", ", currencyMarkets
                        .Where(m => m != null)
                        .Select(m => $"{m.ExchangeId} - {m.PriceUsd} USD")
                        .Distinct()
                        .OrderBy(m => m))
                };

                coinList.Add(coin);
            }

            return coinList;
        }

        public async Task<List<Currency>> SearchCoin(string coinId)
        {
            if (string.IsNullOrEmpty(coinId)) return null;

            List<Currency> coinList = new List<Currency>();
            List<Market> marketList = new List<Market>();

            string coinJson = await _coinCapAPI.SearchCryptocurrency(coinId);
            dynamic currency = JsonConvert.DeserializeObject<dynamic>(coinJson);


            foreach (var currencies in currency.data)
            {
                var currencyMarkets = new List<Market>();

                var marketJson = await _coinCapAPI.GetMarketsList(currencies.id.ToString());
                dynamic markets = JsonConvert.DeserializeObject(marketJson);

                if (markets?.data != null)
                {
                    var tasks = new List<Task>();
                    foreach (dynamic market in markets.data)
                    {
                        tasks.Add(Task.Run(async () =>
                        {
                            currencyMarkets.Add(new Market
                            {
                                ExchangeId = market.exchangeId,
                                PriceUsd = (decimal?)market?.priceUsd ?? 0
                            });
                        }));
                    }
                    await Task.WhenAll(tasks);

                    var coin = new Currency
                    {
                        Id = coinId,
                        Name = currencies.name,
                        Symbol = currencies.symbol,
                        PriceUsd = (decimal?)currencies.priceUsd ?? 0,
                        VolumeUsd24Hr = RoundBigMoney((decimal?)currency.volumeUsd24Hr ?? 0),
                        ChangePercent24Hr = (decimal?)currencies?.changePercent24Hr ?? 0,
                        Market = string.Join(", ", currencyMarkets
                            .Where(m => m != null)
                            .Select(m => $"{m.ExchangeId} - {m.PriceUsd} USD")
                            .Distinct()
                            .OrderBy(m => m))
                    };
                    coinList.Add(coin);
                }
            }
            return coinList;
        }

        public async Task<List<Currency>> SearchName(string coinId)
        {
            if (string.IsNullOrEmpty(coinId)) return null;

            List<Currency> coinList = new List<Currency>();

            string coinJson = await _coinCapAPI.SearchCryptocurrency(coinId);
            dynamic currency = JsonConvert.DeserializeObject<dynamic>(coinJson);


            foreach (var currencies in currency.data)
            {

                
                    var coin = new Currency
                    {
                        Id = currencies.id,
                        Name = currencies.name
                    };
                    coinList.Add(coin);
                
            }
            return coinList;
        }


        public string RoundBigMoney(decimal amount)
        {
            decimal roundedAmount = Math.Round(amount, 2); 
            if (roundedAmount >= 1000000000)
            {
                return Math.Round(roundedAmount / 1000000000, 2) + "b"; 
            }
            else if (roundedAmount >= 1000000)
            {
                return Math.Round(roundedAmount / 1000000, 2) + "m"; 
            }
            else if (roundedAmount < 1000000)
            {
                return Math.Round(roundedAmount / 1000, 2) + "k";
            }
            else
            {
                return roundedAmount.ToString(); 
            }
        }

    }
}

