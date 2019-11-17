using System.Collections.Generic;

namespace PlusUltra.StarkBank.ApiClient.ViewModels
{
    public class CreateCustomerResponse
    {
        public string Message { get; set; }
        public List<Customer> Customers { get; set; }
    }

    public class Customer
    {
        public string Phone { get; set; }
        public string TaxId { get; set; }
        public string Name { get; set; }
        public List<string> Tags { get; set; }
        public ChargeCount ChargeCount { get; set; }
        public CustomerAddress Address { get; set; }
        public string Id { get; private set; }
        public string Email { get; set; }
    }

    public class ChargeCount
    {
        public int Pending { get; set; }
        public int Overdue { get; set; }
    }
}
