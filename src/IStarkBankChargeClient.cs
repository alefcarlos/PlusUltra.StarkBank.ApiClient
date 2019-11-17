using System.Threading.Tasks;
using PlusUltra.StarkBank.ApiClient.ViewModels;
using Refit;

namespace PlusUltra.StarkBank.ApiClient
{
    public interface IStarkBankChargeClient
    {
        [Post("/v1/charge")]
        Task<GenerateChargesResponse> GenerateChargesAsync([Body]GenerateChargesRequest request);

        [Post("/v1/charge/customer")]
        Task<CreateCustomersResponse> CreateCustomersAsync([Body]CreateCustomersRequest request);
    }
}