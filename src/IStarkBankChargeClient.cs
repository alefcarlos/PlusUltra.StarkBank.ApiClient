using System.Threading.Tasks;
using PlusUltra.StarkBank.ApiClient.ViewModels;
using Refit;

namespace PlusUltra.StarkBank.ApiClient
{
    public interface IStarkBankChargeClient
    {
        [Post("/charge")]
        Task<GenerateChargeResponse> GenerateChargeAsync([Body]GenerateChargeRequest request);

        [Post("/charge/customer")]
        Task<CreateCustomerResponse> CreateCustomerAsync([Body]CreateCustomerRequest request);
    }
}