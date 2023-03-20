using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;

namespace CryptoInfo.Model
{
    internal class CoinCapApi
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly string _apiKey = "874be4d0-2fad-4bc8-8aa9-64bdb34ff012";
        private readonly string _baseUrl = "https://api.coincap.io/v2";


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
                var response = await _httpClient.SendAsync(request);
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
                var response = await _httpClient.SendAsync(request);
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
            if (string.IsNullOrEmpty(coinId)) return null;
            try
            {
                var request = CreateRequest($"{_baseUrl}/assets?search={coinId}");
                var response = await _httpClient.SendAsync(request);
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

                var FirstResponse = await _httpClient.SendAsync(FirstRequest);
                var SecondResponse = await _httpClient.SendAsync(SecondRequest);

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
