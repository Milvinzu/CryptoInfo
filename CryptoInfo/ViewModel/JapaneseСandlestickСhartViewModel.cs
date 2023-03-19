using CryptoInfo.Model;
using FancyCandles;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoInfo.ViewModel
{
    internal class JapaneseСandlestickСhartViewModel : ObservableObject
    {
        private CandlesSource candless;
        private List<Currency> Currencies;
        private List<TimePerid> Intervals;
        private List<TimePerid> TimePeroid;
        private string Interval = "4HRS";
        private string SymbolId = "BTC";
        private int Limit = 180;


        public JapaneseСandlestickСhartViewModel() 
        {
            LoadCoins();
            LoadData();
        }

        private void LoadData()
        {
            currencies = new List<Currency> { new Currency { Symbol = "BTC", Name = "Bitcoin"},
                                              new Currency { Symbol = "ETH", Name = "Ethereum"},
                                              new Currency { Symbol = "USDT", Name = "Tether"},
                                              new Currency { Symbol = "BNB", Name = "BNB"},
                                              new Currency { Symbol = "USDC", Name = "USD Coin"},
                                              new Currency { Symbol = "XRP", Name = "XRP"},
                                              new Currency { Symbol = "ADA", Name = "Cardano"},
                                              new Currency { Symbol = "MATIC", Name = "Polygon"},
                                              new Currency { Symbol = "DOGE", Name = "Dogecoin"},
                                              new Currency { Symbol = "SOL", Name = "Solana"}};
            intervals = new List<TimePerid> { new TimePerid{ Period = "5MIN", Time = 5 },
                                          new TimePerid{ Period = "10MIN", Time = 10 },
                                          new TimePerid{ Period = "1HRS", Time = 60 },
                                          new TimePerid{ Period = "2HRS", Time = 120 },
                                          new TimePerid{ Period = "3HRS", Time = 180 },
                                          new TimePerid{ Period = "4HRS", Time = 240 },
                                          new TimePerid{ Period = "1DAY", Time = 1440 }};
            timePeroid = new List<TimePerid> {  new TimePerid{ Period = "1 Day", Time = 1440 },
                                          new TimePerid{ Period = "10 Days", Time = 14400 },
                                          new TimePerid{ Period = "30 Days", Time = 43200 },
                                          new TimePerid{ Period = "Year", Time = 525600 },};
        }

        public void SetCandelSetting(string symbolId, string  interval, string period)
        {
            SymbolId = symbolId;
            Limit =  TimePeroid[FindIndexByPeriodTime(period)].Time / Intervals[FindIndexByPeriodInter(interval)].Time;
            Interval = interval;
            LoadCoins();
        }

        public int FindIndexByPeriodTime(string period)
        {
            for (int i = 0; i < TimePeroid.Count; i++)
            {
                if (TimePeroid[i].Period == period)
                {
                    return i;
                }
            }

            return -1;
        }

        public int FindIndexByPeriodInter(string period)
        {
            for (int i = 0; i < Intervals.Count; i++)
            {
                if (Intervals[i].Period == period)
                {
                    return i;
                }
            }

            return -1;
        }
        public async void LoadCoins()
        {
            CandleInfo candleInfo = new CandleInfo();

            var candles1 = await candleInfo.GetCandleList(SymbolId, Interval, Limit);

            candlesss = candles1;
        }

        public CandlesSource candlesss
        {
            get { return candless; }
            set
            {
                candless = value;
                OnPropertyChanged();
            }
        }

        public List<Currency> currencies
        {
            get { return Currencies; }
            set
            {
                Currencies = value;
                OnPropertyChanged();
            }
        }

        public List<TimePerid> intervals
        {
            get { return Intervals; }
            set
            {
                Intervals = value;
                OnPropertyChanged();
            }
        }

        public List<TimePerid> timePeroid
        {
            get { return TimePeroid; }
            set
            {
                TimePeroid = value;
                OnPropertyChanged();
            }
        }
    }

    class TimePerid
    {
        public string Period { get; set; }
        public int Time { get; set; }
    }


}
