using System.Collections.Generic;

namespace PlusUltra.StarkBank.ApiClient.ViewModels
{
    public class CreateCustomerRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string TaxId { get; set; }
        public string Phone { get; set; }
        public List<string> Tags { get; set; } = new List<string>();
        public CustomerAddress Address { get; set; }
    }
}
