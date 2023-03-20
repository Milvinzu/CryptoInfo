using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows;

namespace CryptoInfo.Model
{
    internal class CoinApi
    {
        
        private readonly string _apiKey = "8A7E6233-0CC5-4589-BB18-9CC2941E94C7";
        private readonly string _baseUrl = "https://rest.coinapi.io/v1";

        public async Task<string> GetCandleList(string symbolId, string periodId, int limit)
        {
            try
            {
                var request = WebRequest.Create($"{_baseUrl}/ohlcv/{symbolId}/latest?period_id={periodId}&limit={limit}&include_empty_items=false") as HttpWebRequest;
                request.Method = "GET";
                request.Headers.Add("X-CoinAPI-Key", _apiKey);
                string responseJson;

                using (var response = request.GetResponse() as HttpWebResponse)
                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    responseJson = streamReader.ReadToEnd();
                }
                return responseJson;
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }


    }
}
