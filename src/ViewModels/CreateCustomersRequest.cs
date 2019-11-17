using System.Collections.Generic;

namespace PlusUltra.StarkBank.ApiClient.ViewModels
{
    public class CreateCustomersRequest
    {
        public List<CreateCustomerRequest> Customers { get; set; } = new List<CreateCustomerRequest>();
    }
}
