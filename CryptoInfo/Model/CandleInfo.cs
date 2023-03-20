using System;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CryptoInfo.Model
{
    internal class CandleInfo
    {
        public async Task<CandlesSource> GetCandleList(string coinId, string interval, int limit)
        {
            CoinApi coinApi = new CoinApi();

            var CandleJson = await coinApi.GetCandleList($"BITSTAMP_SPOT_{coinId}_USD", interval, limit);
            if (string.IsNullOrEmpty(CandleJson)) return null;
            dynamic Candles = JsonConvert.DeserializeObject<dynamic>(CandleJson);

            FancyCandles.TimeFrame timeFrame = FancyCandles.TimeFrame.H1;
            CandlesSource candleList = new CandlesSource(timeFrame);

            int iMax = 0;
            foreach (var candle in Candles) 
            {
                iMax++;
            }

            for (int i = iMax - 1; i >= 0; i--)
            {
                candleList.Add(new Candle(
                    (DateTime)Candles[i].time_period_start,
                    (double)Candles[i].price_open,
                    (double)Candles[i].price_high,
                    (double)Candles[i].price_low,
                    (double)Candles[i].price_close,
                    (double)Candles[i].volume_traded
                    ));
            }      

            return candleList;
        }
    }
}
