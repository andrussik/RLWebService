using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using DTO.Sierra;

namespace IdentityServerClient
{
    public class IdentityServerClient : IIdentityServerClient
    {
        private readonly HttpClient _sierraTokenHttpClient;
        private readonly HttpClient _riksTokenHttpClient;
        private readonly HttpClient _urramTokenHttpClient;
        private TokenResponse? SierraToken { get; set; }
        private TokenResponse? RiksToken { get; set; }
        private TokenResponse? UrramToken { get; set; }

        public IdentityServerClient(IHttpClientFactory clientFactory)
        {
            _sierraTokenHttpClient = clientFactory.CreateClient("sierraToken");
            _riksTokenHttpClient = clientFactory.CreateClient("riksToken");
            _urramTokenHttpClient = clientFactory.CreateClient("urramToken");
        }

        public async Task<string> RequestSierraTokenAsync()
        {
            // request the access token
            var response = await _sierraTokenHttpClient.PostAsync("", null!);
            var token = await response.Content.ReadFromJsonAsync<TokenResponse>();
            SierraToken = token;

            return token?.AccessToken ?? "unknown";
        }

        public Task<string> RequestRiksTokenAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> RequestUrramTokenAsync()
        {
            throw new NotImplementedException();
        }

        public string GetSierraAccessToken()
        {
            return SierraToken?.AccessToken ?? "unknown";
        }

        public string GetRiksAccessToken()
        {
            return RiksToken?.AccessToken ?? "unknown";
        }

        public string GetUrramAccessToken()
        {
            return UrramToken?.AccessToken ?? "unknown";
        }
    }
}