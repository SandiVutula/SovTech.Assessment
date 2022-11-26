using SovTech.Services.Contract;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;
using SovTech.Models;
using Newtonsoft.Json;
using System.Reflection;
using System;
using SovTech.Services.Constants;

namespace SovTech.Services
{
    public class JokeService : IJokeService
    {
        string apiBaseUrl = ApiConstants.API_BASE_URL;
        HttpClient httpClient = new HttpClient();
        public JokeService()
        {
        }

        #region Public Methods 
        public async Task<string> GetCategories()
        {
            try
            {
                httpClient.BaseAddress = new Uri(apiBaseUrl);
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var apiEndPoint = ApiConstants.CATEGORY_ENDPOINT;
                var responseMessage = await httpClient.GetAsync(apiEndPoint);

                responseMessage.EnsureSuccessStatusCode();

                var result = await responseMessage.Content.ReadAsStringAsync();

                return result;
            }
            catch (HttpRequestException httpException)
            {
                throw httpException;
            }
        }

        public async Task<string> GetRandomJokeByCategory(string category)
        {
            try
            {
                httpClient.BaseAddress = new Uri(apiBaseUrl);
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var randomJokeEndPoint = $"jokes/random?category={category}";
                var responseMessage = await httpClient.GetAsync(randomJokeEndPoint);

                responseMessage.EnsureSuccessStatusCode();

                var result = await responseMessage.Content.ReadAsStringAsync();

                return result;
            }
            catch (HttpRequestException httpException)
            {
                throw httpException;
            }
        }

        #endregion
    }
}