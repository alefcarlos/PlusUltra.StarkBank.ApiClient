using System.Threading.Tasks;
using PlusUltra.StarkBank.ApiClient.ViewModels;
using Refit;

namespace PlusUltra.StarkBank.ApiClient
{
    internal interface IStarkBankAuthClient
    {
        [Post("/v1/auth/access-token")]
        Task<StarkBankTokenResponse> LoginAsync([Body(BodySerializationMethod.UrlEncoded)]StarkBankAuthRequest request);
    }
}