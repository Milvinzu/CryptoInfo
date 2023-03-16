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

namespace CryptoInfo.Model
{
    internal class CoinCapAPI
    {
        private readonly HttpClient _client = new HttpClient();
        private const string APIKey = "874be4d0-2fad-4bc8-8aa9-64bdb34ff012";
        private const string BaseUrl = "https://api.coincap.io/v2";


        /// <summary>
        /// Creates a new HttpRequestMessage object with the appropriate headers for requests to the CoinCap API.
        /// </summary>
        /// <param name="url">The URL to create the request for.</param>
        /// <returns>A new HttpRequestMessage object with the appropriate headers.</returns>
        private HttpRequestMessage CreateRequest(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", APIKey);
            return request;
        }



        /// <summary>
        /// Gets a list of cryptocurrencies from the CoinCap API.
        /// </summary>
        /// <param name="limit">The maximum number of cryptocurrencies to return.</param>
        /// <returns>A JSON string containing a list of cryptocurrencies.</returns>
        public async Task<string> GetCryptocurrenciesList(int limit)
        {
            try
            {
                var request = CreateRequest($"{BaseUrl}/assets?limit={limit}");
                var response = await _client.SendAsync(request);
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Gets a list of markets for a given cryptocurrency from the CoinCap API.
        /// </summary>
        /// <param name="coinId">The ID of the cryptocurrency to retrieve markets for.</param>
        /// <returns>A string containing a list of markets for the given cryptocurrency.</returns>
        public async Task<string> GetMarketsList(string coinId)
        {
            try
            {
                var request = CreateRequest($"{BaseUrl}/assets/{coinId}/markets");
                var response = await _client.SendAsync(request);
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }
    }
}
