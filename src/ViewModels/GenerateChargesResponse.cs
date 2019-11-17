using System.Collections.Generic;

namespace PlusUltra.StarkBank.ApiClient.ViewModels
{
    public class GenerateChargesResponse
    {
        public List<Charge> Charges { get; set; }
        public string Message { get; set; }
    }

    public class Charge
    {
        public string TaxId { get; set; }
        public List<ChargeDescription> Descriptions { get; set; }
        public decimal Fine { get; set; }
        public System.DateTime DueDate { get; set; }
        public string City { get; set; }
        public string StreetLine2 { get; set; }
        public string District { get; set; }
        public string StreetLine1 { get; set; }
        public string Id { get; set; }
        public string WorkspaceId { get; set; }
        public decimal Interest { get; set; }
        public System.DateTime IssueDate { get; set; }
        public string Status { get; set; }
        public List<string> Tags { get; set; }
        public string ZipCode { get; set; }
        public string Line { get; set; }
        public string Name { get; set; }
        public string BarCode { get; set; }
        public long Amount { get; set; }
        public string StateCode { get; set; }
        public string CustomerId { get; set; }
        public int OverdueLimit { get; set; }
    }

    public class ChargeDescription
    {
        public string Text { get; set; }
        public long Amount { get; set; }
    }
}
