using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
using System.Net;
using System.Configuration;
using System.IO;

namespace CryptoInfo.Model
{
    internal class CoinCapAPI
    {
        private readonly HttpClient _client;
        private readonly string _apiKey;
        private readonly string _baseUrl;
        //B:\repos\CryptoInfo\CryptoInfo
        public CoinCapAPI()
        {
            string[] lines = File.ReadAllLines("B:/repos/CryptoInfo/CryptoInfo/configuration.txt");

            foreach (string line in lines)
            {
                if (line.StartsWith("APIKey:"))
                {
                    _apiKey = line.Substring(8).Trim();
                }
                else if (line.StartsWith("BaseUrl:"))
                {
                    _baseUrl = line.Substring(9).Trim();
                }
            }
            _client = new HttpClient();
        }

        private HttpRequestMessage CreateRequest(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
            return request;
        }

        public async Task<string> GetCryptocurrenciesList(int limit)
        {
            try
            {
                var request = CreateRequest($"{_baseUrl}/assets?limit={limit}");
                var response = await _client.SendAsync(request);
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }

        public async Task<string> GetMarketsList(string coinId)
        {
            try
            {
                var request = CreateRequest($"{_baseUrl}/assets/{coinId}/markets");
                var response = await _client.SendAsync(request);
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }

        public async Task<string> SearchCryptocurrency(string coinId)
        {
            if (coinId == null) return null;
            try
            {
                var request = CreateRequest($"{_baseUrl}/assets?search={coinId}");
                var response = await _client.SendAsync(request);
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }

        public async Task<List<Task<string>>> GetReteForConvert(string FirstId, string SecondId)
        {
            try
            {
                List<Task<string>> result = new List<Task<string>>();
                var FirstRequest = CreateRequest($"{_baseUrl}/assets/{FirstId}");
                var SecondRequest = CreateRequest($"{_baseUrl}/assets/{SecondId}");

                var FirstResponse = await _client.SendAsync(FirstRequest);
                var SecondResponse = await _client.SendAsync(SecondRequest);

                result.Add(FirstResponse.Content.ReadAsStringAsync());
                result.Add(SecondResponse.Content.ReadAsStringAsync());

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }
    }
}
