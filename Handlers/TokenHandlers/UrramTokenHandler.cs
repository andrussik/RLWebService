using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using IdentityServerClient;

namespace Handlers.TokenHandlers
{
    public class UrramTokenHandler : DelegatingHandler
    {
        private readonly IIdentityServerClient _identityServerClient;

        public UrramTokenHandler(
            IIdentityServerClient identityServerClient)
        {
            _identityServerClient = identityServerClient;
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, 
            CancellationToken cancellationToken)
        {
            // use existing token
            var accessToken = _identityServerClient.GetUrramAccessToken();
            
            // set the bearer token to the outgoing request
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            
            var response = await base.SendAsync(request, cancellationToken);

            // request new token on 401
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                // request the access token
                accessToken = await _identityServerClient.RequestUrramTokenAsync();

                // set the bearer token to the outgoing request
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}