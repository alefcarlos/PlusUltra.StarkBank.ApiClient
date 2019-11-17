using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using PlusUltra.StarkBank.ApiClient.ViewModels;

namespace PlusUltra.StarkBank.ApiClient.MessageHandlers
{
    internal class StarkBankAuthenticationHeaderHandler : DelegatingHandler
    {
        public StarkBankAuthenticationHeaderHandler(IStarkBankAuthClient authClient, IOptions<StarkBankSettings> settings)
        {
            this.authClient = authClient;
            this.settings = settings.Value;
        }

        private readonly IStarkBankAuthClient authClient;
        private readonly StarkBankSettings settings;

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var form = new StarkBankAuthRequest
            {
                Email = settings.Email,
                Password = settings.Password,
                Workspace = settings.Workspace
            };

            var token = await authClient.LoginAsync(form);

            request.Headers.Authorization = new AuthenticationHeaderValue(token.AccessToken);

            return await base.SendAsync(request, cancellationToken);
        }
    }
}