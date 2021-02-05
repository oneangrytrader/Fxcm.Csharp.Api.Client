using System;
using System.Net;
using System.Net.Http;
using Fxcm.Api.Client.Rest.Enum;
using Newtonsoft.Json;

namespace Fxcm.Api.Client.Rest
{
    public class FxcmRestApiClient : IRestApiClient
    {
        private string _token;
        private string _baseUri;
        private const string INSTRUMENTS_URI = "/trading/get_instruments";

        public FxcmRestApiClient(Env env, string token)
        {
            _token = token;
            _baseUri = env == Env.Real ? "https:\\api.fxcm.com" : "https:\\api-demo.fxcm.com";
        }
        private T GetApiResponse<T>(string query)
        {
            using var client = new HttpClient();
            client.DefaultRequestVersion = HttpVersion.Version11;
            client.BaseAddress = new Uri(_baseUri);
            client.DefaultRequestHeaders.Add("User-Agent", "request");
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Content-Type", "application/x-www-form-urlencoded");
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_token}");

            var result = client.GetStringAsync(new Uri(query)).Result;
            return JsonConvert.DeserializeObject<T>(result);
        }

        public string GetInstruments()
        {
            return GetApiResponse<string>(INSTRUMENTS_URI);
        }
    }
}
