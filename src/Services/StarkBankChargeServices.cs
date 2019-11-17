using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PlusUltra.StarkBank.ApiClient.ViewModels;
using Refit;

namespace PlusUltra.StarkBank.ApiClient.Services
{
    public class StarkBankChargeServices
    {
        public StarkBankChargeServices(ILogger<StarkBankChargeServices> logger, IStarkBankChargeClient starkBankChargeClient)
        {
            this.starkBankChargeClient = starkBankChargeClient;
            this.logger = logger;
        }

        private readonly IStarkBankChargeClient starkBankChargeClient;
        private readonly ILogger logger;

        public async Task<GenerateChargeResponse> GenerateCharge(long amount, System.DateTime dueDate, string customerId)
        {
            var form = new GenerateChargeRequest
            {
                Amount = amount,
                CustomerId = customerId,
                DueDate = dueDate
            };

            try
            {
                return await starkBankChargeClient.GenerateChargeAsync(form);
            }
            catch (ApiException ex)
            {
                using (logger.BeginScope($"Geracao de boleto para {customerId}"))
                {
                    logger.LogCritical(ex, "Ocorreu erro ao tentar gerar boleto.");
                    logger.LogError($"Resposta do StarkBank: {ex.Content}");
                };

                throw;
            }
        }

        public async Task<CreateCustomerResponse> CreateCustomer(CreateCustomerRequest createCustomer)
        {
            try
            {
                return await starkBankChargeClient.CreateCustomerAsync(createCustomer);
            }
            catch (ApiException ex)
            {
                using (logger.BeginScope($"Criar cliente {createCustomer?.TaxId}"))
                {
                    logger.LogCritical(ex, "Ocorreu erro ao tentar criar cliente.");
                    logger.LogError($"Resposta do StarkBank: {ex.Content}");
                };

                throw;
            }
        }
    }
}