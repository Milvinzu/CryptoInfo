﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CryptoInfo.Model
{
    class ConvertCurrency
    {
        private string FirstCurrency { get; }
        private string SecondCurrency { get; }

        public ConvertCurrency(string firstCurrency, string secondCurrency)
        {
            FirstCurrency = firstCurrency;
            SecondCurrency = secondCurrency;
        }

        public async Task<decimal> Convert(decimal CountCurrency)
        {
            if (String.IsNullOrEmpty(FirstCurrency) || String.IsNullOrEmpty(SecondCurrency)) return 0;
            decimal result = 0;
            decimal FirstRateUsd = 0;
            decimal SecondRateUsd = 0;
            CoinCapApi coinCapAPI = new CoinCapApi();

            List<Task<string>> RateList = await coinCapAPI.GetReteForConvert(FirstCurrency, SecondCurrency);

            dynamic FirstRateJson = JsonConvert.DeserializeObject(RateList[0].Result.ToString());
            dynamic SecondRateJson = JsonConvert.DeserializeObject(RateList[1].Result.ToString());

            if (FirstRateJson.data == null || SecondRateJson.data == null) return -1;

            FirstRateUsd = (decimal)FirstRateJson.data.priceUsd;
            SecondRateUsd = (decimal)SecondRateJson.data.priceUsd;

            result = (CountCurrency * FirstRateUsd) / SecondRateUsd;
            result = decimal.Round(result, 2, MidpointRounding.ToEven);
            return result;
        }
    }
}
