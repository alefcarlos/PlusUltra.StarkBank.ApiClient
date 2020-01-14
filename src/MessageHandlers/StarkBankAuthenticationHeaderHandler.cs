using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using PlusUltra.DistributedCache;
using PlusUltra.StarkBank.ApiClient.ViewModels;

namespace PlusUltra.StarkBank.ApiClient.MessageHandlers
{
    internal class StarkBankAuthenticationHeaderHandler : DelegatingHandler
    {
        public StarkBankAuthenticationHeaderHandler(IStarkBankAuthClient authClient, IOptions<StarkBankSettings> settings, IDistributedCache cache)
        {
            this.authClient = authClient;
            this.settings = settings.Value;
            this.cache = cache;
        }

        private readonly IStarkBankAuthClient authClient;
        private readonly StarkBankSettings settings;
        private readonly IDistributedCache cache;

        const string CACHE_KEY = "stark_bank_key";

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var form = new StarkBankAuthRequest
            {
                Email = settings.Email,
                Password = settings.Password,
                Workspace = settings.Workspace
            };

            //Tentar obter token do cache, senão realizar request
            var token = await cache.GetObjectAsync<StarkBankTokenResponse>(CACHE_KEY);

            if (token is null)
            {
                //fazer request  do token e salvar no cache
                token = await authClient.LoginAsync(form);
                await cache.SetObjectAsync(CACHE_KEY, token, TimeSpan.FromDays(1));
            }
            
            request.Headers.TryAddWithoutValidation("Access-Token", token.AccessToken);

            return await base.SendAsync(request, cancellationToken);
        }
    }
}