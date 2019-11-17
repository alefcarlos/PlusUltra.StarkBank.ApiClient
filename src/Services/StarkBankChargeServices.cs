using System.Linq;
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

        public async Task<GenerateChargeResponse> GenerateCharge(GenerateChargeRequest generateCharge)
        {
            var body = new GenerateChargesRequest();
            body.Charges.Add(generateCharge);

            var response = await GenerateCharges(body);

            return new GenerateChargeResponse
            {
                Message = response.Message,
                Charge = response.Charges.FirstOrDefault()
            };
        }

        public async Task<CreateCustomerResponse> CreateCustomer(CreateCustomerRequest customer)
        {
            var body = new CreateCustomersRequest();
            body.Customers.Add(customer);

            var response = await CreateCustomers(body);

            return new CreateCustomerResponse
            {
                Message = response.Message,
                Customer = response.Customers.FirstOrDefault()
            };
        }

        public async Task<GenerateChargesResponse> GenerateCharges(GenerateChargesRequest generateCharges)
        {
            try
            {
                return await starkBankChargeClient.GenerateChargesAsync(generateCharges);
            }
            catch (ApiException ex)
            {
                using (logger.BeginScope($"Geracao de boleto"))
                {
                    logger.LogCritical(ex, "Ocorreu erro ao tentar gerar boleto.");
                    logger.LogError($"Resposta do StarkBank: {ex.Content}");
                };

                throw;
            }
        }

        public async Task<CreateCustomersResponse> CreateCustomers(CreateCustomersRequest customers)
        {
            try
            {
                return await starkBankChargeClient.CreateCustomersAsync(customers);
            }
            catch (ApiException ex)
            {
                using (logger.BeginScope($"Criar cliente"))
                {
                    logger.LogCritical(ex, "Ocorreu erro ao tentar criar cliente.");
                    logger.LogError($"Resposta do StarkBank: {ex.Content}");
                };

                throw;
            }
        }
    }
}